   M S B A M L   `   `   `  ����  VrPlayer-    'VrPlayer.Views.Settings.GeneralSettings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      ��   �� Orientation$  Vertical=�6   $��16q�6(   .+�5   
   �� $��General��6   $��18(�6"   �� 5	   
   
�������$��1q�6&   $��1��6:   $
��auto��6E   $��0,0,0,24q�6R   �� 5
   
   $��Head-neck model��6   $
��Bold"�6+   $��0,0,0,8q�6=   6P   � 5   
   $��0,0,0,16q�6    � RowDefinitions 5      �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   $	��200��6-   �� 5      $��50 �6#   .+�5      �� $��0��6   $��0��6$   $��Neck height:��61   6J   �� 5      $��1��6   $��0��6%    � Minimum$ 0Q�6[    � Maximum$	 0.5Q�6g    � Value 62   ��  �� Path$ Config.NeckHeight�6w   �� 5      $��2��6   $��0��6&   ��63   �� $ Config.NeckHeight�6]   5      �� 5   
   $��Samples��6   $
��Bold"�6#   $��0,0,0,8q�65   6H   � 5   
   $��0,0,0,16q�6    5      �� 5      $
��Auto �6     5      �� 5      $
��Auto �6#   �� 5      $��* �6#   $	��200��6-   �� 5       $��32 �6#   .+�5"      �� $��0��6   $��0��6$   $��Directory path:��61   6M   �� 5#      $��1��6   $��0��6&    �� 
IsReadOnly . ��63   �� $ Config.SamplesFolder�6r   �� 5$      $��2��6   $��0��6%   ��62   �� $ ChangeSamplePathCommand�.��6c   ...6h   5%      �� 5&   
   $��Presets��6   $
��Bold"�6#   $��0,0,0,8q�65   6H   � 5'   
   $��0,0,0,16q�6    5(      �� 5)      $
��Auto �6     5+      �� 5,      $
��Auto �6#   �� 5-      $��50 �6#   .+�5/      �� $��0��6   $��0��6$   $��Read side-car files:��61   6R   �� 50      $��1��6   $��0��6'   $��Center=�6i   $��Center=�6�    d� 	IsChecked 64   �� $ Config.ReadSideCarPresets�6�   51      52      53      