   M S B A M L   `   `   `  ���� A  =cource, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:courcecource      cource.LoginWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:cource       � Title$  Auto Deluxe��$	��350��$	��300�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=� � Icon$ Images/icon.ico��.���� ���#272537 �� CornerRadius$ 20��
�������$��1q�._��  � RowDefinitions �� $��20 ��� $��55 ��� $��55 ��� $	��110 ��� $��30 ��� .+��� -   
������ $��20�� � Cursor$
 Hand��]� $��1��.+��� -   $��NameText��$
��Left=�$��Auto Deluxe��$��Center=�$
��Left=�
�������$��/Fonts/#Poppins)�$��28(�$��35,0,0,0q��� -   $��Right=�$��25��$��25��$��Right=�$��0, 0, 35, 0q�$
 Hand������ 	 �� 
TargetType"	 ��.R��� 
 ��Name$
 Bd��
������ ._�F�  F�Name$ Pt��=����        �@ @ � 5  5 �@  5 � 5 @ �@B @B 	 �� Stretch$ Uniform=�
�������$��2���� -   $��Right=�$��25��$��25��$��Right=�$��
0, 0, 5, 0q�$
 Hand������ "	 ��.R��� $
 Bd��
������ ._�F� $ Pt��+����        �@  5 � 5  5 �@B @B 	$ Uniform=�
�������$��2���� -   $��RegLog��$��4��$��Center=�$��Enter Login and Password��
�������$��0, -5, 0, 0q� J� Opacity$ 0Q�$y�Hidden=��� $��3��.+��� $	��Top=�$ 10�����#353340$	��225��$��40��$��-2, 10, 0, 0q�._�� .+��� $��1���� -   $��LoginTextBox��$��3q�$��0q�
������ $��Center=�$��/Fonts/#Poppins)�$��14(�$��5q�
�������$��0����  J� IsHitTestVisible .  $��Center=�$��Login��$
��Left=�$��10,0,0,0q�$��/Fonts/#Poppins)�$��14(�
�������$��1������  �� 
TargetType" �� �� Triggers ��  �� Binding �� *Text+ �� ElementName$ LoginTextBox�� �� Value  .a���  �� Property � y� �� Value$ Visible=�.���  � y�$ Hidden=��� $	��Top=�$ 10�����#353340$	��225��$��40��$��-2, 10, 0, 0q�._�� .+��� $��1���� -   $��PasswordTextBox��$��3q�$��0q�
������ $��Center=�$��/Fonts/#Poppins)�$��14(�$��5q�
�������$��0����  .  $��Center=�$��Password��$
��Left=�$��10,0,0,0q�$��/Fonts/#Poppins)�$��14(�
�������$��1������ " �� ��  �� *Text+$ PasswordTextBox��  .a���  � y�$ Visible=�.���  � y�$ Hidden=�� $��5�� ��  � ColumnDefinitions �� �� .+��� -   $��LoginButton��$	��105��$��40��$
 Hand��$��Login��$��0��$��14(�$��2��$��Bottom=�$��27, 0, 0, 39q�   SwitchButtonTheme#��[  �� -	   $��Registration��$	��105��$��40��$
 Hand��$��Registration��$��1��$��14(�$��3��$��Bottom=�$��0, 0, 33, 39q�#��[  