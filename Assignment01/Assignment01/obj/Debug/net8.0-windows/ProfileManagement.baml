   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	   #    SalesWPFApp.ProfileManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  ProfileManagement��5   	    � WindowStartupLocation$ CenterScreen=�5	   
   .��5
      � .+�5   
   ]� .+�5      �  � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��5* �6$   �� 5      $��* �6$   �� 5      $��4* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5      �� -   5         ��Name$ 	btnLogout��5      $��0 0 0 0q�60   $��80��6A   $��30��6L   $��Logout��6X   6j   5      �� 5      $��1��6   
����ح�$ Vertical=�6A   $��Center=�6Y   $	��400��6v   .+�5      �� -   5        $��lbTitle��5      
���  ��$��DemiBold"�6<   $��20(�6R   $��Your Profile��6`   �� 5      -   5        $��	lbCompany��5      $��Company Name��6-   �� 5      -   5        $��
txtCompany��5      $��Stretch=�60   $��0 0 0 0q�6N   $��25��6`   $	��400��6m   ��6z   ��  �� Path$ CompanyName� �� Mode$ OneWay=� � DataContext 6�   ��  �� ElementName$ 	lvMembers��$ SelectedItem��� 5!      -   5        $��lbCity��5!      $
��City��6*   �� 5#      -   5        $��txtCity��5#      $��Stretch=�6-   $��0 0 0 0q�6K   $��25��6]   $	��400��6j   ��6w   �� $
 City�$ OneWay=� 6�   �� $ 	lvMembers��$ SelectedItem��� 5&      -   5        $��	lbCountry��5&      $��Country��6-   �� 5(      -   5        $��
txtCountry��5(      $��25��60   $��0 0 0 0q�6<   $��Stretch=�6M   $	��400��6k   ��6w   �� $ Country�$ OneWay=� 6�   �� $ 	lvMembers��$ SelectedItem�50      �� 51      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $	��400��6a   .+�52      �� -	   5        $ btnLoad��52      $��
50 5 150 0q�6.   $��80��6B   $
��Load��6M   6\   �� 54      -
   5        $ 	btnUpdate��54      $��0 5 0 0q�60   $��80��6A   $��Update Profile��6L   6e   56      �� 57      -   5        $��lvOrder��57   )   $��3��6   $
��Auto��68   $��0,41,0,0q�6E   	 �� View	 58      �� 59      .P�5:      �� $��OrderId��6-   
 �� Width$	
 200��6>    �� DisplayMemberBinding 6J   �� $ OrderId��� 5;      $��	OrderDate��6-   $	
 300��6@    6L   �� $ 	OrderDate� �� StringFormat$ 
dd/MM/yyyy���� 5<      $��RequiredDate��6-   $	
 200��6C    6O   �� $ RequiredDate�$ 
dd/MM/yyyy���� 5=      $��ShippedDate��6-   $	
 200��6B    6N   �� $ ShippedDate�$ 
dd/MM/yyyy���� 5>      $��Freight��6-   $	
 200��6>    6J   �� $ Freight�5?      5A      5C      5E      5F      5G      