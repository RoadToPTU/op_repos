   M S B A M L   `   `   `  ����@  <prac3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:prac3prac3  5   	       prac3.Administration   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:prac3     5   	     � Title$  Administration��5   	   $	��501��6    $	��800��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��78* �6   �� 5      $
��139* �6    � ColumnDefinitions 5   
   �� 5      $
��297* �6   �� 5      $
��503* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ UsersLogins��5      $��1��6(   $��10,10,10,10q�65   ${�False��6J   �� 5   
   -   5         ��Name$ 
login_butt��5      $"��Авторизуватися��6%   $
��Left=�6>   $��
50,119,0,0q�6Y   $	��Top=�6m   $��25��6�   $	��148��6�   6�   �� 5   
   -   5        $��1��5      $��Закрити вікно��6!   $
��Left=�69   $��30��6T   $��216,257,0,0q�6`   $��1��6u   $	��Top=�6�   $	��254��6�   6�   �� 5   
   -   5        $ AddUser��5      $��1��6"   $)��#Додати користувача��62   $
��Left=�6O   $��31��6j   $��
31,217,0,0q�6v   $��1��6�   $	��Top=�6�   $	��140��6�   ${�False��6�   �� 5   
   -   5        $ CorrectRestrictionBtn��5      $��1��60   $��Встановити��6@   $
��Left=�6U   $��31��6p   $��361,217,0,0q�6|   $��1��6�   $	��Top=�6�   $	��109��6�   ${�False��6�   �� 5   
   -   5        $ CorrectStatusBtn��5      $��1��6+   $/��)Встановити активність��6;   $
��Left=�6[   $��301,171,0,0q�6v   $��1��6�   $	��Top=�6�   $��28��6�   $	��169��6�   ${�False��6�   �� 5   
   -   5        $ 	next_butt��5      $��1��6$   $��Наступний��64   $
��Left=�6H   $��
385,91,0,0q�6c   $��1��6w   $	��Top=�6�   ${�False��6�   �� 5   
   -   5        $ 	prev_butt��5      $��1��6$   $��Попередній��64   $
��Left=�6I   $��	31,91,0,0q�6d   $��1��6w   $	��Top=�6�   ${�False��6�   �� 5   
   -	   5        $ UpdatePasswd��5      $��1��6'   $!��Оновити пароль��67   $
��Left=�6P   $��363,117,0,0q�6k   $	��Top=�6�   $��27��6�   $	��107��6�   ${�False��6�   �� 5   
   $>��8Введіть пароль адміністратора��6   $
��Left=�68   $��	10,10,0,0q�6S   $	��Top=�6f   �� 5   
   $>��8Перегляд користувачів списком��6   $
��Left=�68   $��
10,169,0,0q�6S   $	��Top=�6g   �� 5   
   $��1��6   $:��4Зміна паролю Адміністратора��6    $��Center=�6F   $��0,10,0,0q�6c   $	��Top=�6u   �� 5   
   $��1��6   $#��Поточний пароль��6    $
��Left=�6:   $��	31,43,0,0q�6U   $	��Top=�6h   �� 5   
   $��1��6   $��Новий пароль��6    $
��Left=�67   $��
296,43,0,0q�6R   $	��Top=�6f   �� 5    
   $��1��6   $%��Повторіть пароль��6    $
��Left=�6;   $��
35,119,0,0q�6V   $	��Top=�6j   �� 5!   
   $��1��6   $<��6Перегляд кожного користувача��6    $
��Left=�6G   $	��Top=�6b   $��
18,156,0,0q�6z   $��2��6�   �� 5"   
   $��1��6   $��Ім'я��6    $
��Left=�6/   $��	20,10,0,0q�6J   $��1��6]   $	��Top=�6j   �� 5#   
   $��1��6   $��Прізвище��6    $
��Left=�63   $��	20,41,0,0q�6N   $��1��6a   $	��Top=�6n   �� 5$   
   $��1��6   $��
Логін��6    $
��Left=�60   $��	308,5,0,0q�6K   $��1��6^   $	��Top=�6k   $��53��6�   �� 5%   
   $��1��6   $��Статус��6    $
��Left=�61   $��
310,41,0,0q�6L   $��1��6`   $	��Top=�6m   �� 5&   
   -
   5         ��Name$ name_l��5&      $��1��6    $�� ��60   $
��Left=�6;   $��
129,10,0,0q�6V   $��1��6j   $	��Top=�6w   �� 5'   
   -   5        $ 	surname_l��5'      $��1��6#   $�� ��63   $
��Left=�6>   $��
129,41,0,0q�6Y   $��1��6m   $	��Top=�6z   �� 5(   
   -   5        $ login_l��5(      $��1��6!   $�� ��61   $
��Left=�6<   $��
406,10,0,0q�6W   $��1��6k   $	��Top=�6x   �� 5)   
   -   5        $ status_l��5)      $��1��6"   $�� ��62   $
��Left=�6=   $��
406,41,0,0q�6X   $��1��6l   $	��Top=�6y   �� 5*   
   $��1��6   $*��$Обмеження на пароль��6    $
��Left=�6>   $��
117,88,0,0q�6Y   $��1��6m   $	��Top=�6z   �� 5+   
   -   5        $ pswd_l��5+      $��1��6    $�� ��60   $
��Left=�6;   $��
296,88,0,0q�6V   $��1��6j   $	��Top=�6w   �� 5,   
   $��1��6   $/��)Додавання користувача��6    $
��Left=�6@   $��
18,131,0,0q�6[   $��1��6o   $	��Top=�6|   �� 5-   
   $��1��6   $��Користувач��6    $
��Left=�65   $��252,131,0,0q�6P   $��1��6e   $	��Top=�6r   �� 5.   
   -   5         ��Name$ 	comboboxx��5.      $��1��6&   $
��Left=�66   $��350,133,0,0q�6Q   $��1��6f   $	��Top=�6s   $	��120��6�   ${�False��6�   �� 5/   
   -   5         ��Name$ ChangeActive��5/      $��1��6)   $��Активність��69   $��Center=�6N   $��	0,178,0,0q�6k   $��1��6~   $	��Top=�6�   ${�False��6�   �� 50   
   -   5        $ ChangeRestriction��50      $��1��6.   $*��$Обмеження на пароль��6>   $
��Left=�6\   $��210,226,0,0q�6w   $��1��6�   $	��Top=�6�   ${�False��6�   �� 51   
   -   5         ��Name$ 	add_login��51      $��1��6%   $
��Left=�65   $��29��6P   $��
31,171,0,0q�6\   $��1��6p   	 �� TextWrapping$
	 Wrap=�6}   $	��Top=�6�   $	��140��6�   G� 52   
   -   5        
 G�Name$
 RealAdminPasswd��52      $
��Left=�6/   $��31��6J   $��	24,56,0,0q�6V   $	��Top=�6i   $	��189��6�   G� 53   
   -   5        $
 AdminPasswd��53      $��1��6+   $
��Left=�6;   $��27��6V   $��35,0,0,0q�6b   $��Center=�6t   $	��136��6�   ${�False��6�   G� 54   
   -   5        $
 NewAdminPasswd��54      $��1��6.   $
��Left=�6>   $��27��6Y   $��	296,0,0,0q�6e   $��Center=�6x   $	��133��6�   ${�False��6�   G� 55   
   -   5        $
 NewAdminPasswd2��55      $��1��6/   $
��Left=�6?   $��25��6Z   $��171,119,0,0q�6f   $	��Top=�6{   $	��135��6�   ${�False��6�   57      58      