   M S B A M L   `   `   `  ���� D  @GenericRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:processmonitorprocessmonitor      processmonitor.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:processmonitor     -     � Title$  
MainWindow��$
��57.2��$��329.2�� � AllowsTransparency .  � WindowStyle$
 None=�
������  � Topmost .  � ShowInTaskbar .  .��� .+��� -    ��Name$ 	mainpanel��$
��Left=�$��46��$��5,5,0,0q�$	��Top=�$	��320�����	#33000000 J� Effect -  'System.Windows.Media.Effects.BlurEffect  �� -   $ netpanel��$
��Left=�$��36��$��
220,10,0,0q�$	��Top=�$	��100�����	#BF000000]� -    ]�Name$ cpupanel�� � ToolTip$ 	CPU Usage��$
��Left=�$��36����.  $��	10,10,0,0q�$	��Top=�$	��100�����	#BF000000]� -   $ memorypanel��$ 	RAM Usage��$
��Left=�$��36����.  $��
115,10,0,0q�$	��Top=�$	��100�����	#BF000000�� -   	 ��Name$		 lbl��$��0%��$
��Left=�$��	10,10,0,0q�$	��Top=����	#FF515151$��36��$��Center=�$��Center=�$	��100��$��Consolas)���Z� �� -   $	 
lbl_upload��$��▲ 0.0 kb/s��$
��Left=�$��	220,9,0,0q�$	��Top=�$��21��$��Center=�$	��100�����	#FF898989
 � Cursor$
  ��$��10(�$��Center=�$��Consolas)��� -   $	 lbl_download��$��▼ 0.0 kb/s��$
��Left=�$��
220,24,0,0q�$	��Top=�$��22��$��Center=�$	��100�����	#FF898989$��10(�$��Center=�$��Consolas)��� -	   $	 memlbl��$��0%��$
��Left=�$��
115,10,0,0q�$	��Top=����	#FF515151$��36��$��Center=�$��Center=�$	��100��$��Consolas)���Z� 