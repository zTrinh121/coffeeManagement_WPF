   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ LoginWindow��5
   	   $	��450��6   $	��800��6*    � 	Resources 5         ValidationErrorTemplate ��Name��%�   &	        �� 5   
   .R�5      �� .+�5      �� $ textBox��6,   �� 5      ��6   �� ��5      �� 5      .R�5      �� 
���  ����6(   �� 69   5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��3* �6   .+�5"   
   �� $1��+pack://application:,,,/Images/bg-coffee.jpg��6   $��UniformToFill=�6E   $��0��6]   $��2��6m   $��-30,0,389,0q�6�   �� 5%   
   $��1��6   $��Center=�6%   $��Center=�6@   
�������$	��300��6p   $	��350��6|   $��20q�6�   .+�5&      �� $��Đăng Nhập��5(      $��24(�6"   $
��Bold"�60   $��10q�6B   $��Center=�6N   �� 5)      $��Tài khoản��6   $��
10,20,10,5q�6)   �� 5*      -   5         ��Name$ txtUserName��5,      $��
10,5,10,10q�6&   $��30��6:   ��5+      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��5,   :   �� 5.      $��Mật khẩu��6   $��
10,10,10,5q�6(   G� 5/      -   5         G�Name$ txtPassword��52         WpfApp.PasswordHelper	   Attach$
	 True��50      $��
10,5,10,10q�52   &   $��30��6:   
   Password
 51      �� *
Password+ �� Mode$ TwoWay=�$
 True��$ PropertyChanged=�52   :   �� 58       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��10,20,10,10q�6O   .+�59      �� -   5         ��Name$ btnLogin��59      $��Đăng nhập��6B   $	��108��6V   $��40��6b   $��5q�6n   ���	#FFC6A48A
�������
�������6�   �� 5:      -   5        $ 	CancelBtn��5:      $��Thoát��6D   $	��100��6T   
�������$��40��6t   $��5q�6�   
�������
�������6�   5;       =� ErrorTemplate 5<      �� 5=      .R�5>      �� .+�5?      �� $ textBox��64   �� 5@      ��6'   �� ��5A      �� 5B   "   .R�5C   &   �� 
���  ����60   �� *ErrorContent+6N   5D   #   5F      5G      5H      5K      5N      5O      