   M S B A M L   `   `   `  ����D  @TravelApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TravelApp.PagesTravelApp.Pages  5      !    TravelApp.Pages.ReceiptPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      )localclr-namespace:TravelApp.Pages  5      -   5          N� Title$  ReceiptPage��5	      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ReceiptDataGrid��5      
���   �$��0 0 10 0q�6D   
�������   
IsReadOnly . 6�   �� 5      $ Vertical=�6   .+�5      �� -   5         ��Name$ DeposMoneyBox��5       !  MaterialDesignOutlinedTextBox#��[  61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Внесенная сумма��6h   $��0 0 0 10q�6�   6�   �� 5      -   5         ��Name$ 	TouristID��5         MaterialDesignFilledComboBox#��[ 6.   $ Турист��6d   $��0 0 0 10q�6�   �� 5      -   5        $ 	VoucherID��5      #��[ 6.   $ Путевка��6d   $��0 0 0 10q�6�   �� 5      -   5         ��Name$ VoucherPrice��5      $��0 0 0 10q�62   6F   �� 5      -   5        $ ChangeMoney��5      $��0 0 0 10q�61   6E   �� 5      $ 
Horizontal=�6   $��Center=�66   $��0 10 0 0q�6S   .+�5      �� -   5         ��Name$ 
EditButton��5      $��Изменить��61   $
��Left=�6D   $��0 0 20 0q�6_   
���   �
����� �6�   �� 5      -	   5        $ 	AddButton��5      $,��&Добавить и выгрузить��60   $
��Left=�6O   
���   �
����� �$��0 0 20 0q�6�   �� 5      -
   5        $ 
LoadButton��5      $��Выгрузить��61   $
��Left=�6E   
���   �
����� �6�   5      5      5      5      5      