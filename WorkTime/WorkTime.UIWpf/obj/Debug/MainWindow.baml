   M S B A M L   `   `   `  ����I  EWorkTime.UIWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkTime.UIWpfWorkTime.UIWpf  5   	       WorkTime.UIWpf.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WorkTime.UIWpf     5   	   Y UXceed.Wpf.DataGrid, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5   	   -   5        $��myWindow��5   4     � WindowStyle$
  None=�5      
������  � AllowsTransparency .  � Title$
 Time��5	   	    � WindowStartupLocation$ Manual=�6-    � 
ResizeMode$ NoResize=�6L   $	��536��6b   $	��414��6n    � SizeToContent$ Height=�6{    � Icon$ Resources/home.ico��6�    � TaskbarItemInfo 5
      *  $System.Windows.Shell.TaskbarItemInfo  5   
   .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   
�������$��3q�66   �� 5   
   -   5        $��5, 20, 5, 5q�5      $ 10��6/   ���	#FF292929
������ 6r   � 5   
   	 � RowDefinitions	 5      �� 5      $	��125 �6    �� 5      $��* �6    �� 5      $��20 �6    .+�5      �� -   5        
 ��Name$
 
labelStart��5      $��Start��6(   $
��Left=�68   $	��Top=�6S   $��	23,37,0,0q�6k   $��23��6~   $��55��6�   �� 5      -   5        $
 labelEnd��5      $	��End��6&   $
��Left=�64   $	��Top=�6O   $��
143,36,0,0q�6g   $��24��6{   $��55��6�   �� 5      -   5         ��Name$ textBoxStart��5      $
��Left=�6,   $��23��6G   $��	23,62,0,0q�6S    �� TextWrapping$
 Wrap=�6f   $��TextBox��6z   $	��Top=�6�   $��70��6�   �� 5      -   5        $ 
textBoxEnd��5      $
��Left=�6*   $��23��6E   $��
143,62,0,0q�6Q   $
 Wrap=�6e   $��TextBox��6y   $	��Top=�6�   $��70��6�    J� RenderTransformOrigin$ 3.104,0.458&�6�   �� 5      -   5         ��Name$ buttonCalculate��5      $
��Calc��6.   $
��Left=�6=   $��
218,63,0,0q�6X   $	��Top=�6l   $��74��6�   $��22��6�    �� 	IsDefault . $ 6.543,-2.636&�6�   �� 5      -   5        $ textBoxTimeLeftHours��5      $
��Left=�64   $��40��6O   $��
392,65,0,0q�6[   $
 Wrap=�6o   $	��...��6�   $	��Top=�6�   $	��126��6�   $��16(�6�    J� Opacity$	 0.6Q�6�   $��0q�6�    �� 
IsReadOnly . 6�   �� 5      -	   5        $ buttonSaveTimes��5      $��Calc & Save��6.   $
��Left=�6H   $��
218,92,0,0q�6c   $	��Top=�6w   $��74��6�   $��22��6�    . 6�   �� 5      -
   5         ��Name$ image��5      $ .5,.5&�6C   $��Center=�6�   $��95��6�   $��
150,25,0,0q�6�   $	��Top=�6�   $	��104��6�   $��Resources/home.ico��6�   z�5      �� 5      -   5        myRotateTransform�� �� Angle$ 0Q�5   A   5!      9� 5#      -   5         9�Name$ detailExpander��5#      $��Details��6/    9� ExpandDirection$
 Down=�6@    9� 
IsExpanded .  $��1��6j   $��
5, 0, 5, 0q�6w   .��5$      (  "Xceed.Wpf.DataGrid.DataGridControl  -   5          Name$ 	DataGrid1��5$   '   $��	30,0,26,0q�6:   $	��Top=�6N   $	��233��6f      SelectionMode$ Single=�5%         IsDeleteCommandEnabled .    IsCopyCommandEnabled .  $ 0.479,0.558&�6]   5&      5'      �� 5(   
   -   5        $	��Top=�5(      $��Right=�6,   $��20��6H   $��0, 0, 10, 0q�6T   $��x��6i    �� TextAlignment$ Center=�6r   $��20��6�   
������� � Cursor$
 Hand��6�   ��5)      
� 5*      -   5        myHover�� �� Opacity$ 0Q�5*   7   .��5+      �  � Color$ #EC1432��6#    � Offset$ 0Q�63   � 5,      $ Transparent��6#   $ 1Q�67   5-        � Triggers  5/      :� 50      ! :� RoutedEvent$! 
MouseEnter��6   .[�51      �� .��52      �� .��53      W� 	" W� To$" 1X�6.   # g� Duration$# 00:00:00.25D�65   $ �� TargetProperty$$ Opacity�6L   % �� 
TargetName$% myHover��6p   54      55      56      :� 57      $! 
MouseLeave��6   .[�58      �� .��59      �� .��5:      W� $" 0X�6.   $# 00:00:00.25D�65   $$ Opacity�6L   $% myHover��6p   5;      5<      5=      5?      �� 5@   
   -   5        $	��Top=�5@      $��Right=�6,   $��20��6H   $��0, 0, 30, 0q�6T   $��_��6i   $ Center=�6r   $��20��6�   
�������$
 Hand��6�   ��5A      
� 5B      -   5        myHover2��$ 0Q�5B   8   .��5C      � $ #ECE014��6#   $ 0Q�63   � 5D      $ Transparent��6#   $ 1Q�67   5E        5G      :� 5H      $! 
MouseEnter��6   .[�5I      �� .��5J      �� .��5K      W� $" 1X�6.   $# 00:00:00.25D�65   $$ Opacity�6L   $% myHover2��6p   5L      5M      5N      :� 5O      $! 
MouseLeave��6   .[�5P      �� .��5Q      �� .��5R      W� $" 0X�6.   $# 00:00:00.25D�65   $$ Opacity�6L   $% myHover2��6p   5S      5T      5U      5W      5X      5Y      