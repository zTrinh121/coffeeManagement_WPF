   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.EmployeeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  EmployeeWindow��5   	    � WindowStartupLocation$ CenterScreen=�6'   $	��720��5	   	   $
��1080��6    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � AllowsTransparency$
 True��62    #  MaterialDesign.Brush.Foreground#���   5   	   
�������$��Medium"�5   	   $��14(�5   	   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  J� OpacityMask
 �����.+�5   
   �� -   5         ��Name$ CloseBtn��5       & "MaterialDesignFloatingActionButton#��[ 6:   $
��Left=�6v   
���   �$��1021,0,0,683q�5   B   $��49��6X   ��6   Z� ��6   Z� .��5      �� $��-5q�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
CloseThick=�6*   5      5      ]� 5   
   .+�5      o� $	��Top=�6   $
��Left=�6(   .@�5       m� $��_Tài khoản��6   .@�5!      m� -   5         m�Name$ 
mnPersonal��5!      $��_Thông tin cá nhân��63   	 m� Icon	 5"      0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$
 Account=�m� 5#      -   5        $ mnExit��5#      $
��Exit��5$       m� InputGestureText$ Ctrl+E��5&      	 5%        $
 	ExitToApp=�5&      5'      5(      �� 5)       �� AcceptsReturn$
 True��6   �� 5*      $��87��6   $	��649��6$    �� Orientation$ 
Horizontal=�61   $
��Left=�6J   .+�5+      #  MaterialDesignThemes.Wpf.Card  $��10q�6&      UniformCornerRadius$ 15Q�62   .��5,      �� $
��0 15q�6   .@�5-      �� $��Center=�6'   $
��0 10q�6D   .��5.      �� -   5        $
 menu��5.   %   #��[ 6F   $
��Left=�6�   
���   ���5/      Z� ��65   Z� .��50   "   �� $��-5q�6-   .+�51   &     $ 
Silverware=�6>   52   #   53      54      �� 55      $��Center=�6'   $��0q�6D   .��56      �� -   5        $ drink��56   %   #��[ 6I   $
��Left=�6�   
���   ���57   "   Z� ��69   Z� .��58   "   �� $��-5q�6-   .+�59   &     $
 Beer=�6>   5:   #   5;      5<      �� 5=      $��Center=�6'   $
��0 10q�6D   .��5>      �� -   5        $ report��5>   %   #��[ 6J   $
��Left=�6�   
���   ���5?      Z� ��65   Z� .��5@   "   �� $��-5q�6-   .+�5A   &     $ ChartBox=�6>   5B   #   5C      5D      �� 5E      $��Center=�6'   $��0q�6D   .��5F      �� -   5        $ employee��5F   %   ���	#FFE3E3E3#��[ 6N   $
��Left=�6�   
���   ���5G      Z� .��5H   "   �� $��-5q�6-   .+�5I   &     $ AccountMultiple=�6>   5J   #   5K      5L      �� 5M      $��Center=�6'   $
��0 10q�6D   .��5N      �� -   5        $ logout��5N   %   #��[ 6J   $
��Left=�6�   
���   ���5O      Z� ��65   Z� .��5P   "   �� $��-5q�6-   .+�5Q   &     $ 	ExitToApp=�6>   5R   #   5S      5T      5U      5W      5X      5Y      5\      5^      