   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   NS_OrdersSystem%   NS_OrdersSystem.Views.OrderView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro       � Title$  Recibos��$	��700�� � 
ResizeMode$ 	CanResize=�(   "MahApps.Metro.Controls.MetroWindow   ShowMinButton .    ShowTitleBar .  $��1q� � WindowStartupLocation$ CenterScreen=�
��� ���   EnableDWMDropShadow . $
��1200��$	��900��$	��700�� � 	Resources    
TextTitulo �� 
TargetType �� Property	 �� Value  TextSubTitulo�� %G  &	        &	 �     �� " ��.���  � ��$	 30(���  � ��
	 �   ���  � ��$	 Normal$���  � ��$	 Light"���  � ��$	 Segoe Ui)��� " ��.���  � ��$	 15(���  � ��
	 �   ���  � ��$	 Normal$���  � ��$	 Light"���  � ��$	 Segoe Ui)���  �@J�Opacity$		 0.8Q�.��� -   $��GridMain��.+��� -   $��TextBlockMessage��$
��Left=�$	��Top=�$��10q�#��[ �� $��Right=�
 �� Orientation$
 
Horizontal=�$��25��$	��Top=�$��100,5q�.+�A� $��10��$��10��
��� � �$��Center=��� -   $��TextBoxCurrentUser��$��Henry Bautista��$��20��$��Bottom=�$
��10,0q�!   MahApps.Metro.Controls.Tile  -   $��20��
�������$��TERMINAR SESION��
���   �  -   $��ButtonUsuarios��$��20��
�������$��USUARIOS��
���   �4   .MahApps.Metro.Controls.MetroAnimatedTabControl  $��1��$��0,30,0,0q� �� TabStripPlacement$	 top=�.@��� $��recibos��.��� $��1��$��0,20,0,0q� � RowDefinitions �� $	��10* ��� $��90 �.+�� $��0��$��20,0,0,0q� � ColumnDefinitions �� �� $
��1.5* �.+��� $
��Left=�.+��� $
 
Horizontal=�.+��� $��Usuario��$��Bottom=�$��0,0,5,0q��� -   $��TextBoxUsuario��{�.  $	��100���� $��	N# Recibo��$��Bottom=�$��5,0,5,0q��� -   $��TextBoxNumeroRecibo��{�.  $	��100���� $��Fecha��(  "System.Windows.Controls.DatePicker  -   $��DatePickerDate��$��1���� $��Nombre Cliente���� -	   $��TextBoxName���� $��Telefono���� -
   $��TextBoxPhone���� $��Producto���� -   $��TextBoxProduct���� $��Precio���� $
 
Horizontal=�.+��� -   $��TextBoxPrecio�� �� SelectedText$
 0.00��$	��100��$
��Left=��� $��  BS. ��$��Center=��� -   $��TextBoxAlert��$��Right=�$��Center=��� $��Anticipo���� -   $��TextBoxAnticipe��$
 0.00��$	��100��$
��Left=��� $��Saldo���� -   $��TextBoxSaldo��$	��100��$
��Left=�{�.  �� $��Observaciones���� -   $��TextBoxObservation��$��60�� �� TextWrapping$
 Wrap=�$	��300��$	��300���� $��Estado���� -   $��ComboBoxState��$	��100��$
��Left=� �� SelectedIndex$ 0��.@��� .��	ABIERTO�� .��	CANCELADO�� $��1��.+��� $��Historial de Recibos��#��[ �� $
 
Horizontal=�$��	0,10,0,10q�.+��� $
��10,0q�.+��� $��Nombre Cliente���� -   $��TBSClientName��$	��100���� $
��10,0q�.+��� $��Producto���� -   $��
TBSProduct��$	��100���� $
��10,0q�.+��� $��Fecha��  -   $��DPSDate��$	��100��  -   $��ButtonBuscar��$	��100��$��30�����	#FF0A3F63$��Bottom=�$
��10,0q�.���� $��Center=�Buscar&   System.Windows.Controls.DataGrid  -   $��DataGridOrders��$	��380��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ CODIGO��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
or_order+  $ CLIENTE�� �� *or_client_name+  $ FECHA�� �� *	or_date+  $ TELEFONO�� �� *
or_phone+  $ PRODUCTO�� �� *or_product_description+  $ PRECIO�� �� *
or_price+  $ ANTICIPO�� �� *or_anticipe+  $ OBSERVACION�� �� *or_observation+4	  .System.Windows.Controls.DataGridCheckBoxColumn	  $ ESTADO�� �� *
or_state+  $ USUARIO�� �� *name+� $��2�����	#FF0A3F63.+��� $
 
Horizontal=�$��50,0,0,0q�.+��� $��Center=�$��0,0,10,0q�.+��� -   $��	ButtonAdd��
������ $��0q�
���   �|�.  $��50��$��50��.���� $3��-/NS_OrdersSystem;component/Images/Add-New.png���� $��Guardar Nuevo��$
��Wrap=� �� TextAlignment$ Center=�
�������$��Light"�$��50��$��Center=��� $��Center=�$��0,0,10,0q�.+��� -   $��ButtonClean��
������ $��0q�
���   �|�.  $��50��$��50��.���� $1��+/NS_OrdersSystem;component/Images/clean.png���� $��Limpiar Forma��$
��Wrap=�$ Center=�$��50��
�������$��Light"�$��Center=��� $��Center=�$��0,0,10,0q�.+��� -   $��ButtonUpdate��
������ {�.  $��0q�
���   �|�.  $��50��$��50��.���� $3��-/NS_OrdersSystem;component/Images/Refresh.png���� $��Actualizar Recibo��$
��Wrap=�$ Center=�$��50��
�������$��Light"�$��Center=��� $��Center=�$��0,0,10,0q�.+��� -   $��ButtonDelete��
������ $��0q�
���   �|�.  $��50��$��50��.���� $1��+/NS_OrdersSystem;component/Images/Trash.png���� $��Eliminar Recibo��$
��Wrap=�$��50��$ Center=�
�������$��Light"�$��Center=��� $��Center=�$��0,0,10,0q�.+��� -   $��ButtonPrint��
������ $��0q�
���   �|�.  $��50��$��50��.���� $1��+/NS_OrdersSystem;component/Images/Trash.png���� $��Imprimir Recibo��$
��Wrap=�$��50��$ Center=�
�������$��Light"�$��Center=��� $��Center=�$��0,0,50,0q�$��Right=�.+��� -   $��ButtonShowAll��
������ $��0q�
���   �|�.  $��50��$��50��.���� $5��//NS_OrdersSystem;component/Images/View-List.png���� $��Mostrar todo��$
��Wrap=�$ Center=�
�������$��Light"�$��50��$��Center=��� $��cotizaciones��.��� $��0,20,0,0q� �� $	��10* ��� $��90 �.+�� $��0��$��20,0,0,0q� �� �� $
��1.5* �.+��� $
��Left=�.+��� $
 
Horizontal=�.+��� $��Usuario��$��Bottom=�$��0,0,5,0q��� -   $��TextBoxUsuarioCoti��{�.  $	��100���� $��N# Cotizacion��$��Bottom=�$��5,0,5,0q��� -   $��TextBoxNumeroCoti��{�.  $	��100���� $��Fecha��  -   $��DatePickerDateCoti��$��1���� $��Nombre Cliente���� -    $��TextBoxNameCoti���� $��Telefono���� -!   $��TextBoxPhoneCoti���� $��Detalle���� -"   $��TextBoxDetalle��$��60��$
 Wrap=�$	��300��$	��300���� $��Precio���� $
 
Horizontal=�.+��� -#   $��TextBoxPrecioCoti��$
 0.00��$	��100��$
��Left=��� $��	Proveedor���� -$   $��TextBoxProveedor��$	��300��$
��Left=��� $��1��.+��� $��Historial de Recibos��#��[ �� $
 
Horizontal=�$��	0,10,0,10q�.+��� $
��10,0q�.+��� $��Nombre Cliente���� -%   $��TBSClientNameCoti��$	��100���� $
��10,0q�.+��� $��Fecha��  -&   $��DPSDateCoti��$	��100��  -'   $��ButtonBuscarCoti��$	��100��$��30�����	#FF0A3F63$��Bottom=�$
��10,0q�.���� $��Center=�Buscar  -(   $��DataGridQuotes��$	��380�� .     $ CODIGO�� �� *
qu_quote+  $ CLIENTE�� �� *qu_client_name+  $ FECHA�� �� *	qu_date+  $ TELEFONO�� �� *
qu_phone+  $ DETALLE�� �� *	qu_detail+  $ PRECIO�� �� *
qu_price+  $ 	PROVEEDOR�� �� *qu_supplier+  $ USUARIO�� �� *name+� $��2�����	#FF0A3F63.+��� $
 
Horizontal=�$��50,0,0,0q�.+��� $��Center=�$��0,0,10,0q�.+��� -)   $��ButtonAddCoti��
������ $��0q�
���   �|�.  $��50��$��50��.���� $3��-/NS_OrdersSystem;component/Images/Add-New.png���� $��Guardar Nuevo��$
��Wrap=�$ Center=�
�������$��Light"�$��50��$��Center=��� $��Center=�$��0,0,10,0q�.+��� -*   $��ButtonCleanCoti��
������ $��0q�
���   �|�.  $��50��$��50��.���� $1��+/NS_OrdersSystem;component/Images/clean.png���� $��Limpiar Forma��$
��Wrap=�$ Center=�$��50��
�������$��Light"�$��Center=��� $��Center=�$��0,0,10,0q�.+��� -+   $��ButtonUpdateCoti��
������ {�.  $��0q�
���   �|�.  $��50��$��50��.���� $3��-/NS_OrdersSystem;component/Images/Refresh.png���� $��Actualizar Cotizado��$
��Wrap=�$ Center=�$��50��
�������$��Light"�$��Center=��� $��Center=�$��0,0,10,0q�.+��� -,   $��ButtonDeleteCoti��
������ $��0q�
���   �|�.  $��50��$��50��.���� $1��+/NS_OrdersSystem;component/Images/Trash.png���� $��Eliminar Cotizado��$
��Wrap=�$��50��$ Center=�
�������$��Light"�$��Center=��� $��Center=�$��0,0,50,0q�$��Right=�.+��� --   $��ButtonShowAllCoti��
������ $��0q�
���   �|�.  $��50��$��50��.���� $5��//NS_OrdersSystem;component/Images/View-List.png���� $��Mostrar todo��$
��Wrap=�$ Center=�
�������$��Light"�$��50��$��Center=�