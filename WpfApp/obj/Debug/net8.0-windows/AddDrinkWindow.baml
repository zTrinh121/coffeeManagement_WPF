   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.AddDrinkWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  	Add Drink��5   	   $	��350��6   $	��400��6(    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,0,0,10q�6"   .+�5      �� $��Drink Name:��6   $
��Bold"�6+   �� 5      -   5         ��Name$ DrinkNameTextBox��5      $	��200��60   $
��Left=�6<   5      �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $��Category ID:��6   $
��Bold"�6,   �� 5      -   5        $ CategoryIdTextBox��5      $	��200��61   $
��Left=�6=   5      �� 5   
   $��2��6   $��0,0,0,10q�6"   .+�5      �� $��Price:��6   $
��Bold"�6&   �� 5      -   5        $ PriceTextBox��5      $	��200��6,   $
��Left=�68   5      �� 5   
   $��3��6   $��0,0,0,10q�6"   .+�5      �� $��Image Path:��6   $
��Bold"�6+   �� 5      -   5        $ ImagePathTextBox��5      $	��200��60   $
��Left=�6<    �� 
IsReadOnly$
 True��6W   �� 5       -   5        $��	Browse...��5       $��80��6)   64   5!      �� 5"   
   -   5        $��4��5"      $��	Add Drink��6   $��80��62   $��Right=�6=   6Y   5#      5$      