   M S B A M L   `   `   `  ����   MatrixCalculator!    MatrixCalculator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$/  )Матричный калькулятор��$��992.166��$��447.721��
����ح� � 
ResizeMode$ NoResize=� � 	Resources &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value5  /System.Windows.Controls.DataGridLengthConverter��%>  '        '�� G    '	� ;    '�� �    �� "  .���  � ��$	 230����  � ��$	 206����  � ��$
 Left=���  � ��$	 Top=���  �@ CanUserAddRows .  ��  �@ HeadersVisibility$
 None=���  �@ 	RowHeight$ 20Q���  �@ MinColumnWidth$ 30Q���  �@ ColumnWidth$ * ��  � �� �� ��  � �� . �� " ��.���  � ��$ 28����  � ��$ 23����  � ��$
 Left=���  � ��$	 Top=���  �@��TextWrapping$
 Wrap=���  � ��$  ����  � ��$ Center=���  � ��$ Center=���  �@��	MaxLength$ 2���� " 	�.���  � ��$
 auto����  � ��$ 10q���  � ��$
 Left=���  �@J�RenderTransformOrigin$ 
0.458,2.64&��� " ��.���  � ��
 �������  � ��$
 Left=���  � ��$	 Top=�.��� $��	0,0,0,0.5q�.+�  -     Name$ DataGridMatrixA��$��	62,75,0,0q�  -   $ DataGridMatrixB��$��
374,75,0,0q�  -   $ DataGridMatrixC��$��
701,75,0,0q�   
IsReadOnly . �� $��47��$
��auto��$��311,126,0,0q�$
��Left=�$	��Top=�.+�	� -    	�Name$ RadioButtonAddition��$��+��	� -   $ RadioButtonSubtraction��$��-��	� -   $ RadioButtonMultiplication��$��*���� -   	 ��Name$	 TextBlockMatrixA��$��77��$��34��$��	62,29,0,0q�$
��Left=�$	��Top=�$/��)Размерность матрицы А:��$
��Wrap=��� -   
 ��Name$
 TextBoxRowsNumMatrixA��$��
147,33,0,0q�$��0���� -	   $
 TextBoxColumnsNumMatrixA��$��
197,33,0,0q�$��1���� -
    ��Name$ LabelSymbolXMatrixA��$��22��$��
175,29,0,0q�$
��Left=�$	��Top=�$��Center=�$��х���� -    ��Name$ ButtonOkMatrixA��$��50��$��
242,36,0,0q�$
��ОК��$��2���� -   $	 TextBlockMatrixB��$��77��$��34��$��
374,29,0,0q�$
��Left=�$	��Top=�$.��(Размерность матрицы B:��$
��Wrap=��� -   $
 TextBoxRowsNumMatrixB��$��
459,33,0,0q�$��3���� -   $
 TextBoxColumnsNumMatrixB��$��
509,33,0,0q�$��4���� -   $ LabelSymbolXMatrixB��$��22��$��
487,29,0,0q�$
��Left=�$	��Top=�$��Center=�$��х���� -   $ ButtonOkMatrixB��$��49��$��
555,36,0,0q�$
��ОК��$��5���� -   $ LabelMatrixC��$��
701,29,0,0q�$
��Left=�$	��Top=�$4��.Результирующая матрица C:���� -   $ ButtonCalculateMatrices��$��60��$��50��$��622,156,0,0q�$��=��$��22(��� -   $ ButtonTransposeMatrixA��$	��230��$��
62,295,0,0q�$$��Транспонировать���� -   $ ButtonTransposeMatrixB��$	��230��$��374,295,0,0q�$$��Транспонировать���� -   $ ButtonTransposeMatrixC��$	��230��$��701,295,0,0q�$$��Транспонировать���� -   $ ButtonCopyMatrixA��$	��112��$��40��$��
62,320,0,0q�.���� $(��"Копировать в буфер�� �� TextAlignment$ Center=�$
��Wrap=��� -   $ ButtonPasteMatrixA��$	��112��$��40��$��180,320,0,0q�.���� $)��#Вставить из  буфера��$ Center=�$
��Wrap=��� -   $ ButtonCopyMatrixB��$	��112��$��40��$��374,320,0,0q�.���� $(��"Копировать в буфер��$ Center=�$
��Wrap=��� -   $ ButtonPasteMatrixB��$	��112��$��40��$��492,320,0,0q�.���� $)��#Вставить из  буфера��$ Center=�$
��Wrap=��� -   $ ButtonCopyMatrixC��$	��112��$��40��$��701,320,0,0q�.���� $(��"Копировать в буфер��$ Center=�$
��Wrap=��� -   $ ButtonPasteMatrixC��$	��112��$��40��$��819,320,0,0q�.���� $)��#Вставить из  буфера��$ Center=�$
��Wrap=�