   M S B A M L   `   `   `  ����  VrPlayer-    'VrPlayer.Views.Settings.DisplaySettings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      ��   �� Orientation$  Vertical=�6   $��16q�6(   .+�5   
   �� $��Display��6   $��18(�6"   �� 5	   
   
�������$��1q�6&   $��1��6:   $
��auto��6E   $��0,0,0,24q�6R   �� 5
   
   $��	Viewports��6   $
��Bold"�6%   $��0,0,0,8q�67   6J   � 5   
   $��0,0,0,16q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   $	��200��6-   �� 5      $��50 �6#   .+�5      �� $��0��6   $��0��6$   $��Horizontal offset:��61   6P   �� 5      $��1��6   $��0��6%    � Minimum$ -1000Q�6j    � Maximum$
 1000Q�6z    � Value 62   ��  �� Path$&  Config.ViewportsHorizontalOffset�6�   �� 5      $��2��6   $��0��6&   ��63   �� $&  Config.ViewportsHorizontalOffset�6l   �� 5      $��0��6   $��1��6$   $��Vertical offset:��61   6N   �� 5      $��1��6   $��1��6%   $
 -500Q�6h   $	 500Q�6w    62   �� $$ Config.ViewportsVerticalOffset�6�   �� 5      $��2��6   $��1��6&   ��63   �� $$ Config.ViewportsVerticalOffset�6j   5      �� 5   
   $��Camera��6   $
��Bold"�6"   $��0,0,0,8q�64   6G   � 5   
   $��0,0,0,16q�6    5      �� 5      $
��Auto �6     5!      �� 5"      $
��Auto �6#   �� 5#      $��* �6#   $	��200��6-   �� 5$      $��50 �6#   .+�5&      �� $��0��6   $��0��6$   $��Field of view (FOV):��61   6R   �� 5'      $��1��6   $��0��6%   $ 0Q�6b   $	 180Q�6n    62   �� $ Config.CameraFieldOfView�6~   �� 5(      $��2��6   $��0��6&   ��63   �� $ Config.CameraFieldOfView�6e   5)      5*      5+      