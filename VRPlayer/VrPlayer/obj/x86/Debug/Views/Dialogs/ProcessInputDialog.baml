   M S B A M L   `   `   `  ����  VrPlayer/    )VrPlayer.Views.Dialogs.ProcessInputDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Open process��5   	    � Icon$* $/Medias/Nuvola/16x16/window_list.png��6    � 
ResizeMode$ NoResize=�6J    � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�6v    � Topmost .  � WindowStartupLocation$ CenterScreen=�6�   .��5      �� $��5q�6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��5q�6.   .+�5      �� $��Process:��6   �� 5      -   5         ��Name$ ResponseComboBox��5      $	��500��61   	 �� DisplayMemberPath$	 MainWindowTitle��6d   
 �� SelectedValuePath$
 .��6�    �� SelectedIndex$ 0��6�   ��6=   ��  �� Path$ 	Processes�6�   5	      �� 5
   
   $ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5        $��OK��5      $��50��6:   $��25��6E   $��5q�6Q   �� 5      -   5        $��Cancel��5      $��50��6B   $��25��6M   $��5q�6Z   5      5      5      