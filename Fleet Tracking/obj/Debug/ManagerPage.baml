   M S B A M L   `   `   `  ����I  EFleet Tracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Fleet_TrackingFleet_Tracking  5           Fleet_Tracking.ManagerPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Fleet_Tracking     5        N� Title$  ManagerPage��5      $��0,0,0,0q�6   .��5
      � ��5   
   �� 5       �� ImageSource$. (Resources/action-asphalt-blur-315938.jpg��6   .+�5   
   � $	��Top=�6   $��60��6'   ��5      �� 5       �� Color# � ��6"    �� Opacity$
 0.62Q�6h   .+�5      �� -   5         ��Name$ image��5      $
��Left=�6#   $��77��6>   $��36,0,0,0q�6J   $	��Top=�6\   $	��131��6t   $��Resources/Untitled.png��6�   $
��Fill=�6�   �� 5      -   5         ��Name$ label��5      $��Fleet Tracking��6#   $
��Left=�6<   $��	196,0,0,0q�6W   $	��Top=�6j   $��Curlz MT)�6�   $��40(�6�   ���	#FFC3FF00$��60��6�   $	��231��6�   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��198��6I   $	��Top=�6U   $��60��6m   $��1,60,1,1q�6y    J� Opacity$	 0.7Q�6�   ��5      �� 5      $ 	#FF262D35��6"   .+�5      �� ��6   Z� ��6,   Z� .��5      �� $ 
Horizontal=�6   $	��195��66   $��46��6B   .+�5      �� $
��Menu��6   
������ 
�������$��Tempus Sans ITC)�6W   $��24(�6t   $��10,0,0,0q�6�   $��0,0,0,1q�6�   $��Bottom=�6�   �� 5      $��Resources/list (1).png��6   $
��Fill=�6<   $��60,4,0,0q�6K   $��48��6]   $��Right=�6h   $��41��6�   $	��Top=�6�   5      5      5      �� 5    
   -   5         ��Name$ 	sidePanel��5    ,   $ Vertical=�6   $
��Left=�6?   $	��199��6Z   $��	0,120,0,0q�6f   ��5!      �� 5"      # � ��6"   $
 0.62Q�6h   .+�5%      �� $ 
Horizontal=�6   $��54��62   $��	0,100,0,0q�6>   .+�5&      � -   5        	 �Name$	 	colorGrid��5&      
�������$��12��6=   �� 5'      -   5        
 ��Name$
 btnCaptureV��5'   *   $��3,0,0,0q�6   $	��178��6V   ��6@   Z� .��5(      �� $ 
Horizontal=�6!   $	��178��6:   .+�5)      �� $��Resources/icon (3).png��6    $��57��6@   $
��Fill=�6K   �� 5*      $��Capture Vehicle��6    $��	10,10,0,0q�6:   $��Yu Gothic UI Light)�6M   
���������6m   Z� 6�   5+      5,      5-      �� 5.      $ 
Horizontal=�6   $��54��62   $��0,20,0,0q�6>   .+�5/      � -   5        $	 
colorGrid1��5/      
�������$��12��6>   �� 50      -   5        $
 
btnUpdateV��50   *   $��3,0,0,0q�6   $	��177��6?   ��6L   Z� .��51      �� $ 
Horizontal=�6!   $	��178��6:   .+�52      �� $��Resources/rotate (2).png��6    $��57��6B   $
��Fill=�6M   �� 53      $��Update Vehicle��6    $��	10,10,0,0q�69   $��Yu Gothic UI Light)�6L   
���������6l   Z� 6�   54      55      56      �� 57      $��5��6   �� 58      $ 
Horizontal=�6   $��54��62   $��0,20,0,0q�6>   .+�59      � -   5        $	 
colorGrid2��59      
�������$��12��6>   �� 5:      -	   5        $
 	btnDelete��5:   +   $��3,0,0,0q�6   $	��177��6>   ��6L   Z� .��5;      �� $ 
Horizontal=�6!   $	��178��6:   .+�5<      �� $'��!rubbish-bin-delete-button (2).png��6    $��57��6K   $
��Fill=�6V   �� 5=      $��Delete Vehicle ��6    $��	10,10,0,0q�6:   $��Yu Gothic UI Light)�6M   
���������6m   Z� 6�   5>      5?      5@      �� 5A      
���   �$��
10,40,10,0q�6+   �� 5B      $ 
Horizontal=�6   $��54��62   $��0,5,0,0q�6>   .+�5C      � -
   5        $	 
colorGrid3��5C   5   
�������$��12��6*   65   �� 5D      -   5        $
 btnVehicleReport��5D      $��3,0,0,0q�64   $	��177��6G   ��6T   Z� .��5E      �� $ 
Horizontal=�6!   $	��178��6:   .+�5F      �� $��Resources/to-do-list.png��6    $��57��6B   $
��Fill=�6M   �� 5G      $��Vehicle Report��6    $��	10,10,0,0q�69   $��Yu Gothic UI Light)�6L   
���������6l   Z� 6�   5H      5I      5J      �� 5K      
���   �$��
10,30,10,0q�6+   �� 5L      $ 
Horizontal=�6   $��54��62   $��Bottom=�6>   .+�5M      � -   5        $	 
colorGrid4��5M   5   
�������$��12��6*   65   �� 5N      $��3,0,0,0q�6   $	��177��6,   ��69   Z� .��5O      �� $ 
Horizontal=�6!   $	��178��6:   .+�5P      �� $'��!rubbish-bin-delete-button (2).png��6    $��57��6K   $
��Fill=�6V   �� 5Q      $��Settings��6    $��0,10,0,0q�63   $��Yu Gothic UI Light)�6E   
���������6e   Z� 6{   5R      5S      5T      5U      �� 5V   
   $ Vertical=�6   $	��Top=�6,   $��
199,60,0,0q�6D   $��60��6X   ��5W      �� 5X      # � ��6"   $
 0.53Q�6h   .+�5Z      �� $ 
Horizontal=�6   $��Center=�62   $	��600��6O   $��0,5,0,0q�6[   .+�5[      �� $��Vehicle Report��6   $	��140��62   $��30,0,0,0q�6>   �� 5\      $��Service Report��6   $	��140��62   $��3,0,0,0q�6>   �� 5]      $��Trip Report��6   $	��140��6/   $��3,0,0,0q�6;   �� 5^      $�� ��6   $	��140��6$   $��3,0,0,0q�60   5_      �� 5`      $ 
Horizontal=�6   $��Center=�62   $	��800��6O   $��0,5,0,0q�6[   .+�5a      �� $��Vehicle Report��6   $	��140��62   $��55,0,0,0q�6>   �� 5b      $��Service Report��6   $	��140��62   $��3,0,0,0q�6>   �� 5c      $��Trip Report��6   $	��140��6/   $��3,0,0,0q�6;   �� 5d      $�� ��6   $	��140��6$   $��3,0,0,0q�60   �� 5e      $�� ��6   $	��140��6$   $��3,0,0,0q�60   5f      5g      5h      5i      