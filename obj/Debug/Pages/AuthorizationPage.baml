   M S B A M L   `   `   `  ����D  @TravelApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TravelApp.PagesTravelApp.Pages  5      '    !TravelApp.Pages.AuthorizationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      )localclr-namespace:TravelApp.Pages  5      -   5          N� Title$  AuthorizationPage��5	      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ AuthDataGrid��5      
���   �$��0 0 10 0q�6A   
�������   
IsReadOnly . 6�   �� 5      $ Vertical=�6   .+�5      �� -   5         ��Name$ LoginTextBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$) #Логин пользователя��60    �� 	MaxLength$ 40��6d    !  MaterialDesignOutlinedTextBox#��[  6s   $��12(�6�   $	��300��6�   $��0 0 0 20q�6�   6�   �� 5      -   5        $ PassTextBox��5      $ 20��6/   $+ %Пароль пользователя��6>   #��[  6s   $��12(�6�   $	��300��6�   $��0 0 0 20q�6�   �� 5      -   5         ��Name$ 	UserIdBox��5         MaterialDesignFilledComboBox#��[ 6.   $ Пользователь��6d   �� 5      $ 
Horizontal=�6   $��Center=�66   $��0 10 0 0q�6S   .+�5      �� -   5         ��Name$ 
EditButton��5      $��Изменить��61   $
��Left=�6D   $��0 0 20 0q�6_   
���   �
����� �6�   �� 5      -   5        $ 	AddButton��5      $��Добавить��60   $
��Left=�6C   
���   �
����� �6�   5      5      5      5      5      