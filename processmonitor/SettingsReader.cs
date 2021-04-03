using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace processmonitor
{
    class SettingsReader
    {
        private static string SettingsFile = "Settings.xml";

        public static Brush CPUColour = Brushes.Yellow;
        public static Brush RAMColour = Brushes.Cyan;
        public static Brush PanelColour = Brushes.Black;
        public static Brush BackgroundColour = Brushes.Black;
        public static Brush MainTextColour = Brushes.Gray;
        public static Brush NetTextColour = Brushes.White;

        public static double BackgroundOpacity = 0.5;
        public static double PanelOpacity = 0.75;

        public static int RefreshRate = 1200;

        private static XDocument ConfigFile;
        public static void SetValues()
        {
            ConfigFile = XDocument.Load(SettingsFile);

            string cpuc = ConfigFile.Descendants("CPUColour").First().Value;
            string ramc = ConfigFile.Descendants("RAMColour").First().Value;
            string panelc = ConfigFile.Descendants("PanelColour").First().Value;
            string bgc = ConfigFile.Descendants("BackgroundColour").First().Value;
            string netc = ConfigFile.Descendants("NetTextColour").First().Value;
            string mainc = ConfigFile.Descendants("MainTextColour").First().Value;

            string bgop = ConfigFile.Descendants("BackgroundOpacity").First().Value;
            string panop = ConfigFile.Descendants("PanelOpacity").First().Value;

            string refrate = ConfigFile.Descendants("RefreshRate").First().Value;

            SetColour("CPUColour", cpuc);
            SetColour("RAMColour", ramc);
            SetColour("PanelColour", panelc);
            SetColour("NetTextColour", netc);
            SetColour("MainTextColour", mainc);
            SetColour("BackgroundColour", bgc);

            SetOther("BackgroundOpacity", bgop);
            SetOther("PanelOpacity", panop);
            SetOther("RefreshRate", refrate);
        }
        private static void SetOther(string inp, string setval)
        {
            try
            {
                switch (inp)
                {
                    case "BackgroundOpacity":
                        BackgroundOpacity = Convert.ToDouble(setval);
                        return;
                    case "PanelOpacity":
                        PanelOpacity = Convert.ToDouble(setval);
                        return;
                    case "RefreshRate":
                        RefreshRate = Convert.ToInt32(setval);
                        return;
                }
            }
            catch
            {
            }
        }
        private static void SetColour(string inp, string setval)
        {
            try
            {
                switch (inp)
                {
                    case "CPUColour":
                        CPUColour = new BrushConverter().ConvertFromString(setval) as SolidColorBrush;
                        return;
                    case "RAMColour":
                        RAMColour = new BrushConverter().ConvertFromString(setval) as SolidColorBrush;
                        return;
                    case "PanelColour":
                        PanelColour = new BrushConverter().ConvertFromString(setval) as SolidColorBrush;
                        return;
                    case "BackgroundColour":
                        BackgroundColour = new BrushConverter().ConvertFromString(setval) as SolidColorBrush;
                        return;
                    case "NetTextColour":
                        NetTextColour = new BrushConverter().ConvertFromString(setval) as SolidColorBrush;
                        return;
                    case "MainTextColour":
                        MainTextColour = new BrushConverter().ConvertFromString(setval) as SolidColorBrush;
                        return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
