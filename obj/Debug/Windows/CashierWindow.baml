   M S B A M L   `   `   `  ����D  @TravelApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TravelApp.WindowsTravelApp.Windows  5   	   %    TravelApp.Windows.CashierWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:TravelApp.Windows  5   	     � Title$  CashierWindow��5	   	    � WindowStyle$
 None=�6    � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�6e    � SizeToContent$ WidthAndHeight=�6{    � WindowStartupLocation$ CenterScreen=�6�   .��5      �� -   5        $��15q�5      
�������$��Center=�6,    �� Padding$ 30q�6G    �� CornerRadius$ 20��6T    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6   
   Color$
 	LightGray��6/      ShadowDepth$ 0Q�6A   ._�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ HideAppButton��5      $��Right=�60      MaterialDesignIconButton#��[  6L   $��20��6~   $��20��6�   $��5q�6�   
��� � �
������ .��5      � .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�62   $��Center=�6?   $��Center=�6Z   $��20��6w   $��20��6�   
���   �6�   5      5      �� 5      -   5        $ CloseAppButton��5      $��Right=�61   #��[  6M   $��20��6   $��20��6�   $��5q�6�   
���  ��
������ .��5      � .+�5        $ Close=�62   $��Center=�6?   $��Center=�6Z   $��15��6w   $��15��6�   
���   �6�   5      5      5      �� 5      -   5         ��Name$ WindowComboBox��5      .@�5      �� .��6   
КАССА6&   5       � 5      -   5          �Name$ 
AdminFrame��5      $��Center=�6)   $��0 40 0 0q�6G     � NavigationUIVisibility$ Hidden=�6Y   �� 5       -   5        $ ReturnButton��5       $
��Left=�6+   $	��240��6F   
����� �
���   �$��0 20 0 0q�6�   .��5!      � .+�5"      �� " Выйти из аккаунта5$      5%      5&      5'      5(      5)      