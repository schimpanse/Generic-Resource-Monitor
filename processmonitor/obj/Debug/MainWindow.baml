   M S B A M L   `   `   `  ����D  @GenericRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:processmonitorprocessmonitor  5   	       processmonitor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:processmonitor     5   	   -   5          � Title$  
MainWindow��5   	   $
��57.2��6   $��329.2��6*    � AllowsTransparency .  � WindowStyle$
 None=�6R   
������  � Topmost .  � ShowInTaskbar .  .��5	      � .+�5   
   �� -   5         ��Name$ 	mainpanel��5      $
��Left=�6T   $��46��6o   $��5,5,0,0q�6{   $	��Top=�6�   $	��320��6�   ���	#33000000 J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      5      �� 5   
   -   5        $ netpanel��5      $
��Left=�6S   $��36��6n   $��
220,10,0,0q�6z   $	��Top=�6�   $	��100��6�   ���	#BF0000006�   ]� 5   
   -   5         ]�Name$ cpupanel��5   T    � ToolTip$ 	CPU Usage��6@   $
��Left=�6f   $��36��6�   ��.  $��	10,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ���	#BF0000006�   ]� 5   
   -   5        $ memorypanel��5   T   $ 	RAM Usage��6@   $
��Left=�6i   $��36��6�   ��.  $��
115,10,0,0q�6�   $	��Top=�6�   $	��100��6�   ���	#BF0000006�   �� 5   
   -   5        	 ��Name$		 lbl��5   <   $��0%��6I   $
��Left=�6V   $��	10,10,0,0q�6q   $	��Top=�6�   ���	#FF515151$��36��6�   $��Center=�6�   $��Center=�6  $	��100��65  $��Consolas)�6A  ��6�   Z� 6A  �� 5   
   -   5        $	 
lbl_upload��5   <   $��▲ 0.0 kb/s��6P   $
��Left=�6e   $��	220,9,0,0q�6�   $	��Top=�6�   $��21��6�   $��Center=�6�   $	��100��6�   ���	#FF898989
 � Cursor$
  ��6�   $��10(�6  $��Center=�6  $��Consolas)�6R  �� 5   
   -   5        $	 lbl_download��5   <   $��▼ 0.0 kb/s��6R   $
��Left=�6g   $��
220,24,0,0q�6�   $	��Top=�6�   $��22��6�   $��Center=�6�   $	��100��6�   ���	#FF898989$��10(�6�   $��Center=�6  $��Consolas)�6K  �� 5   
   -	   5        $	 memlbl��5   <   $��0%��6L   $
��Left=�6Y   $��
115,10,0,0q�6t   $	��Top=�6�   ���	#FF515151$��36��6�   $��Center=�6�   $��Center=�6  $	��100��69  $��Consolas)�6E  ��6�   Z� 6E  5      5      