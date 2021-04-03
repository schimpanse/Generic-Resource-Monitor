using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;
using System.Management;
using Echevil;
namespace processmonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PerformanceCounter _cpuUsage;
        private double CpuUsage() => Math.Round(_cpuUsage.NextValue(), 2);
        private double MemoryUsage() => Math.Round(GetMemoryUsage(), 2);
        static int _loops = 0;
        private NetworkAdapter[] adapters;
        private NetworkMonitor monitor;
        private ContextMenu context = new ContextMenu();
        private ListBox netlist = new ListBox();

        private Brush _cpuColour;
        private Brush _memColour;
        public MainWindow()
        {
            InitializeComponent();

            SettingsReader.SetValues();
            Brush panelColour = SettingsReader.PanelColour.Clone();
            panelColour.Opacity = SettingsReader.PanelOpacity;
            Brush backColour = SettingsReader.BackgroundColour.Clone();
            backColour.Opacity = SettingsReader.BackgroundOpacity;
            cpupanel.Background = panelColour;
            memorypanel.Background = panelColour;
            netpanel.Background = panelColour;
            mainpanel.Background = backColour;
            _cpuColour = SettingsReader.CPUColour.Clone();
            _memColour = SettingsReader.RAMColour.Clone();
            lbl.Foreground = SettingsReader.MainTextColour.Clone();
            memlbl.Foreground = SettingsReader.MainTextColour.Clone();
            lbl_download.Foreground = SettingsReader.NetTextColour.Clone();
            lbl_upload.Foreground = SettingsReader.NetTextColour.Clone();

            // CONTEXT MENU SETUP
            MenuItem m_close = new MenuItem(); m_close.Header = "Close";
            MenuItem m_topmost = new MenuItem(); m_topmost.Header = "Topmost";
            MenuItem m_shownet = new MenuItem(); m_shownet.Header = "Show Network Activity";
            MenuItem m_openconfig = new MenuItem(); m_openconfig.Header = "Open Config";
            m_shownet.IsCheckable = true; m_shownet.IsChecked = true;
            m_shownet.Checked += M_shownet_Checked; m_shownet.Unchecked += M_shownet_Unchecked;
            m_topmost.IsCheckable = true; m_topmost.IsChecked = true;
            m_topmost.Checked += context_topmost_Checked;
            m_openconfig.Click += M_openconfig_Click;
            m_topmost.Unchecked += context_topmost_Unchecked;
            m_close.Click += MenuItem_Click;
            Label m_adapters = new Label(); m_adapters.Content = "Network Adapters";
            netlist.SelectionChanged += Netlist_SelectionChanged;
            context.Items.Add(m_close);
            context.Items.Add(m_topmost);
            context.Items.Add(m_shownet);
            context.Items.Add(m_openconfig);
            context.Items.Add(m_adapters);
            context.Items.Add(netlist);

            monitor = new NetworkMonitor();
            adapters = monitor.Adapters;
            foreach(var adapter in adapters)
            {
                netlist.Items.Add(adapter);
            }
            _cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _mainTimer.Tick += new EventHandler(mainTimer_Tick);
            _mainTimer.Interval = new TimeSpan(0, 0, 0, 0, SettingsReader.RefreshRate);
            _mainTimer.Start();
        }

        private void M_openconfig_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", "Settings.xml");
        }

        private void M_shownet_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl_download.Visibility = Visibility.Hidden;
            lbl_upload.Visibility = Visibility.Hidden;
            netpanel.Visibility = Visibility.Hidden;
            mainpanel.Width -= 105;
            monitor.StopMonitoring();
        }

        private void M_shownet_Checked(object sender, RoutedEventArgs e)
        {
            lbl_download.Visibility = Visibility.Visible;
            lbl_upload.Visibility = Visibility.Visible;
            netpanel.Visibility = Visibility.Visible;
            mainpanel.Width += 105;
            if (netlist.SelectedItem != null)
                monitor.StartMonitoring(adapters[netlist.SelectedIndex]);
        }

        private void Netlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            monitor.StopMonitoring();
            monitor.StartMonitoring(adapters[netlist.SelectedIndex]);
        }

        DispatcherTimer _mainTimer = new DispatcherTimer();
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            UpdateAll();
            _loops++;
            if(_loops == 150)
            {
                _loops = 0;
                GC.Collect();
            }
        }
        private void UpdateAll()
        {
            double usage = CpuUsage();
            lbl.Content = usage + "%";
            UpdateCpuGraph(usage);

            double musage = MemoryUsage();
            memlbl.Content = musage + "%";
            UpdateMemGraph(musage);

            NetworkAdapter adapter = adapters[0];
            lbl_download.Content = string.Format("▼ {0:n} KB/s", adapter.DownloadSpeedKbps);
            lbl_upload.Content = string.Format("▲ {0:n} KB/s", adapter.UploadSpeedKbps);
        }
        private int _procItems = 0;
        private int _memItems = 0;
        private void UpdateCpuGraph(double pbval)
        {
            double usage = pbval;
            if (_procItems >= 50)
            {
                cpupanel.Children.RemoveAt(0);
                _procItems--;
            }
            Rectangle bar = new Rectangle();
            bar.Width = 2; bar.Height = usage * 0.36;
            _cpuColour.Opacity = 0.75; bar.Stroke = _cpuColour;
            bar.VerticalAlignment = VerticalAlignment.Bottom;
            cpupanel.Children.Add(bar);
            _procItems++;
        }
        private void UpdateMemGraph(double pbval)
        {
            double usage = pbval;
            if (_memItems >= 50)
            {
                memorypanel.Children.RemoveAt(0);
                _memItems--;
            }
            Rectangle bar = new Rectangle();
            bar.Width = 2; bar.Height = usage * 0.36;
            _memColour.Opacity = 0.75; bar.Stroke = _memColour;
            bar.VerticalAlignment = VerticalAlignment.Bottom;
            memorypanel.Children.Add(bar);
            _memItems++;
        }
        private void lbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private double GetMemoryUsage()
        {
            double mpercent = 0;
            var wmiObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new {
                FreePhysicalMemory = Double.Parse(mo["FreePhysicalMemory"].ToString()),
                TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
            }).FirstOrDefault();

            if (memoryValues != null)
            {
                mpercent = ((memoryValues.TotalVisibleMemorySize - memoryValues.FreePhysicalMemory) / memoryValues.TotalVisibleMemorySize) * 100;
            }
            return mpercent;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainTimer.Stop();
            monitor.StopMonitoring();
            Close();
        }

        private void lbl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            context.PlacementTarget = sender as Button;
            context.IsOpen = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainTimer.Stop();
            monitor.StopMonitoring();
        }

        private void context_topmost_Checked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        private void context_topmost_Unchecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
        }
    }
}
