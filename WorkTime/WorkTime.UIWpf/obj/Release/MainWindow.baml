   M S B A M L   `   `   `  ���� I  EWorkTime.UIWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkTime.UIWpfWorkTime.UIWpf      WorkTime.UIWpf.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:WorkTime.UIWpf     -     � Title$
  Time�� � WindowStartupLocation$ Manual=� � 
ResizeMode$ NoResize=�$	��440��$	��115����Z� .��� 
������� � ColumnDefinitions .+��� -    ��Name$ 
labelStart��$��Start��$
��Left=�$	��Top=�$��	23,15,0,0q�$��28��$��55���� -   $ labelEnd��$	��End��$
��Left=�$	��Top=�$��
135,15,0,0q�$��28��$��55���� -    ��Name$ textBoxStart��$
��Left=�$��23��$��	23,48,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$��70���� -   $ 
textBoxEnd��$
��Left=�$��23��$��
135,48,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$��70�� J� RenderTransformOrigin$ 3.104,0.458&��� -    ��Name$ buttonCalculate��$��Go��$
��Left=�$��
218,48,0,0q�$	��Top=�$��35��$��22��	 �� 	IsDefault	 . �� -   $ textBoxTimeLeftHours��$
��Left=�$��40��$��
288,24,0,0q�$
 Wrap=�$	��...��$	��Top=�$	��126��$��16(�
 J� Opacity$	
 0.6Q�$��0q� �� 
IsReadOnly . 