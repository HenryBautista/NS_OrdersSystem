   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5       NS_OrdersSystem$   NS_OrdersSystem.Views.UserView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5        � Title$  Usuarios��5      $	��700��5       � 
ResizeMode$ 	CanResize=�5      (   "MahApps.Metro.Controls.MetroWindow   ShowMinButton .    ShowTitleBar .  $��1q�5
       � WindowStartupLocation$ CenterScreen=�5      
��� ���   EnableDWMDropShadow . $	��500��5      $	��500��5      $	��600��5       � 	Resources 5         
TextTitulo �� 
TargetType �� Property	 �� Value  TextSubTitulo�� 5   
   %  &	        &	 �     �� 5      " ��6'   .�5      ��  � ��$	 30(�6-   �� 5       � ��
	 �   �6/   �� 5       � ��$	 Normal$�6.   �� 5       � ��$	 Light"�6/   �� 5       � ��$	 Segoe Ui)�6/   5      �� 5      " ��6*   .�5      ��  � ��$	 15(�6-   �� 5       � ��
	 �   �6/   �� 5       � ��$	 Normal$�6.   �� 5       � ��$	 Light"�6/   �� 5        � ��$	 Segoe Ui)�6/   �� 5!       �@J�Opacity$		 0.8Q�6,   5"      5#      .��5%      � $��10q�6   
 � RowDefinitions
 5&   
   �� 5'      �� 5(      $��5* �6   �� 5)      $��5* �6   .+�5+   
   �� $��Usuarios��6   #��[  6$   $��Center=�6H   �� 5,   
   $��1��6   .+�5-      �� Nombre6    �� 5.      -   5        $��TBName��5.      �� 5/      	Paterno6!   �� 50      -   5        $��	TBPaterno��50      �� 51      	Materno6!   �� 52      -   5        $��	TBMaterno��52      �� 53      Login6   �� 54      -   5        $��TBlogin��54      �� 55      Contraseña6$   �� 56      -   5        $��
TBPassword��56      �� 57       �� Orientation$ 
Horizontal=�6   $
��0,10q�62   .+�58      !   MahApps.Metro.Controls.Tile  -   5        $
��BAdd��58       $��30��6,   $	��100��68   ���	#FF0A3F63.��59      �� $��Center=�6    	AGREGAR6D   5:        5;      -   5        $��BUpdate��5;       $��30��6/   $	��100��6;   ���	#FF0A3F63.��5<      �� $��Center=�6    	MODIFICAR6F   5=        5>      -   5        $��BEnable��5>       $��30��6/   $	��100��6;   ���	#FF0A3F63.��5?      �� $��Center=�6    	HABILITAR6F   5@        5A      -	   5        $��	BUnenable��5A       $��30��61   $	��100��6=   ���	#FF0A3F63.��5B      �� $��Center=�6    INHABILITAR6H   5C      5E      5F      &   System.Windows.Controls.DataGrid  5G   
   -
   5        $��DGUsers��5G      $��2��6"      AutoGenerateColumns . $	��300��6J   5I      5J      5L      