   M S B A M L   `   `   `  ����D  @TravelApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TravelApp	TravelApp  5   	   #    TravelApp.AuthorizationWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:TravelApp     5   	   -   5          �Name$  	AufWindow��5       � Title$ AuthorizationWindow��5   	   
������  � WindowStyle$
 None=�6>    � AllowsTransparency .  � 
ResizeMode$ NoResize=�6k    � WindowStartupLocation$ CenterScreen=�6�   .��5      �� -   5        $	��400��5      $��15q�6   
�������$��Center=�6;    �� Padding$ 30q�6V   $	��550��6c    �� CornerRadius$ 20��6r    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5	      	   
BlurRadius$	 30Q�6   
   Color$
 	LightGray��6/      ShadowDepth$ 0Q�6A   ._�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ HideAppButton��5      $��Right=�60      MaterialDesignIconButton#��[  6L   $��20��6~   $��20��6�   $��5q�6�   
��� � �
������ .��5      � .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�62   $��Center=�6?   $��Center=�6Z   $��20��6w   $��20��6�   
���   �6�   5      5      �� 5      -   5        $ CloseAppButton��5      $��Right=�61   #��[  6M   $��20��6   $��20��6�   $��5q�6�   
���  ��
������ .��5      � .+�5        $ Close=�62   $��Center=�6?   $��Center=�6Z   $��15��6w   $��15��6�   
���   �6�   5      5      5      �� 5      $1��+Туристическое агенство��6   $��30(�66   $
��Bold"�6D   $��0 0 0 20q�6V   �� 5      -   5         ��Name$ LoginTextBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6,    % !MaterialDesignFloatingHintTextBox#��[ 6\   $��18(�6�   G� 5      -   5         G�Name$ PassTextBox��5      $! Введите пароль��6/    ) %MaterialDesignFloatingHintPasswordBox#��[ 6_   $��18(�6�   � 5      $��0 20 0 0q�6   .+�5      �� -   5        $ EnterButton��5      $
��Left=�6.   $	��120��6I   
����� �
���   �.��5      � .+�5      �� 
�������
Войти6>   5      5       5!      5"      5#      5%      