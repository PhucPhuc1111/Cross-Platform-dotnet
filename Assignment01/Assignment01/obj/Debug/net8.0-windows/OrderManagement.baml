   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	   !    SalesWPFApp.OrderManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  OrderManagement��5   	    � WindowStartupLocation$ CenterScreen=�5	   
   .��5
      � .+�5   
   ]� .+�5      �  � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��9* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��4* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5      �� -   5         ��Name$ 	btnMember��5      $��0 0 0 0q�60   $��80��6A   $��30��6L   $��Member��6X   6j   �� 5      -   5        $ 
btnProduct��5      $��	10 0 10 0q�61   $��80��6D   $��30��6O   $��Product��6[   6n   �� 5      -   5        $ btnOrder��5      $��0 0 10 0q�6/   $��80��6A   $��30��6L   $��Order��6X   6i   �� 5      -   5        $ 	btnLogout��5      $��0 0 0 0q�60   $��80��6A   $��30��6L   $��Logout��6X   6j   5      �� 5      $��1��6   
����ح�$ Vertical=�6A   $��Center=�6Y   $	��400��6v   .+�5      �� -   5        $��lbTitle��5      
���  ��$��DemiBold"�6<   $��20(�6R   $��Order Information��6`   �� 5      -   5        $��	lbOrderId��5      $��Order Id��6-   �� 5      -   5        $��
txtOrderId��5      $��25��60    �� 
IsReadOnly$
 True��6<   $��0 0 0 0q�6N   $��Stretch=�6_   $	��400��6}   ��6�   ��  �� Path$ OrderId� �� Mode$ OneWay=� � DataContext 6�   �� 	 �� ElementName$	 lvOrders��$ SelectedItem��� 5"      -   5        $��
lbMemberID��5"      $��	Member ID��6.   �� 5#      -	   5        $��txtMemberID��5#      $��Stretch=�61   $��0 0 0 0q�6O   $��25��6a   $	��400��6n   ��6{   �� $ MemberId�$ OneWay=� 6�   �� $	 lvOrders��$ SelectedItem��� 5%      -
   5        $��lbOrderDate��5%      $��
Order Date��6/   (  "System.Windows.Controls.DatePicker  5&      -   5        $��txtOrderDate��5&   !   $��Stretch=�65   $��0 0 0 0q�6S   $��25��6e   $	��400��6r   
   Text
 5'      �� $ 	OrderDate�$ OneWay=� �� StringFormat$ 
dd/MM/yyyy�� 6f   �� $	 lvOrders��$ SelectedItem��� 5-      -   5        $��
lbRequired��5-      $��Required Date��6.     5/      -   5        $��txtRequired��5/   !   $��Stretch=�64   $��0 0 0 0q�6R   $��25��6d   $	��400��6q   
 50      �� $ RequiredDate�$ OneWay=�$ 
dd/MM/yyyy�� 6i   �� $	 lvOrders��$ SelectedItem��� 53      -   5        $��	lbShipped��53      $��Shipped Date��6-     55      -   5        $��
txtShipped��55   !   $��25��63   $��0 0 0 0q�6?   $��Stretch=�6P   $	��400��6n   
 56      �� $ ShippedDate�$ OneWay=�$ 
dd/MM/yyyy�� 6h   �� $	 lvOrders��$ SelectedItem��� 5:      -   5        $��	lbFreight��5:      $��Freight��6-   �� 5<      -   5        $��
txtFreight��5<      $��25��60   $��0 0 0 0q�6<   $��Stretch=�6M   $	��400��6k   ��6w   �� $ Freight�$ OneWay=� 6�   �� $	 lvOrders��$ SelectedItem�5@      �� 5A      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $	��500��6a   .+�5B      �� -   5        $ btnLoad��5B      $��60,0,0,0q�6.   $��25��6@   $��80��6M   $
��Load��6X   6g   �� 5C      -   5        $ 	btnInsert��5C      $��10q�60   $��80��6<   $��Insert��6G   6X   �� 5D      -   5        $ 	btnUpdate��5D      $��10q�60   $��80��6<   $��Update��6G   6X   �� 5E      -   5        $ 	btnDelete��5E      $��10q�60   $��80��6<   $��Delete��6G   6Y   5G      �� 5H      $��3��6   $ 
Horizontal=�6*   $��Center=�6C   $	��500��6a   .+�5I      �� �� 5J      -   5        $��lbStart��5J       $��Start��6/      5K      -   5        $��txtStart��5K   &   $	��150��66   $��Stretch=�6B   6b    �� 5L      -   5        $��lbEnd��5L       $	��End��6-      5M      -   5        $��txtEnd��5M   &   $	��150��64   $��Stretch=�6@   6`    �� 5N      -   5        $ 	btnSearch��5N   !   $��0q�64   $��80��6?   $��25��6J   $��Search��6V   6h   5O      5R      �� 5S      -   5        $��lvOrders��5S   )   $��4��6   $
��Auto��69   $��0,41,0,0q�6F    �� View 5T      �� 5U      .P�5V      �� $��OrderId��6-    �� Width$	 200��6>    �� DisplayMemberBinding 6J   �� $ OrderId��� 5W      $��MemberId��6-   $	 300��6?    6K   �� $ MemberId��� 5X      $��	OrderDate��6-   $	 300��6@    6L   �� $ 	OrderDate�$ 
dd/MM/yyyy���� 5Y      $��RequiredDate��6-   $	 200��6C    6O   �� $ RequiredDate�$ 
dd/MM/yyyy���� 5Z      $��ShippedDate��6-   $	 200��6B    6N   �� $ ShippedDate�$ 
dd/MM/yyyy���� 5[      $��Freight��6-   $	 200��6>    6J   �� $ Freight�5\      5^      5`      5b      5c      5d      