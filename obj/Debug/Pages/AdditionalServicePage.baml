   M S B A M L   `   `   `  ����D  @TravelApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TravelApp.PagesTravelApp.Pages  5      +    %TravelApp.Pages.AdditionalServicePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      )localclr-namespace:TravelApp.Pages  5      -   5          N� Title$  AdditionalServicePage��5	      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ ServicesDataGrid��5      
���   �$��0 0 10 0q�6E   
�������   
IsReadOnly . 6�   �� 5      $ Vertical=�6   .+�5      �� -   5         ��Name$ ServiceNameBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Название услуги��62    �� 	MaxLength$ 40��6c    !  MaterialDesignOutlinedTextBox#��[  6r   $��12(�6�   $	��300��6�   $��0 0 0 20q�6�   6�   �� 5      -   5        $ ServicePriceBox��5      $% Стоимость услуги��63   #��[  6e   $��12(�6�   $	��300��6�   $��0 0 0 10q�6�   6�   �� 5      $ 
Horizontal=�6   $��Center=�66   $��0 10 0 0q�6S   .+�5      �� -   5         ��Name$ 
EditButton��5      $��Изменить��61   $
��Left=�6D   $��0 0 20 0q�6_   
���   �
����� �6�   �� 5      -   5        $ 	AddButton��5      $��Добавить��60   $
��Left=�6C   
���   �
����� �6�   5      5      5      5      5      