   M S B A M L   `   `   `  ����K  GVrPlayer.Helpers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcCclr-namespace:VrPlayer.Helpers.Converters;assembly=VrPlayer.HelpersVrPlayer.Helpers.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      & "VrPlayer.Trackers.YEI3SpaceTracker7   1VrPlayer.Trackers.YEI3SpaceTracker.YEI3SpacePanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z
convertersCclr-namespace:VrPlayer.Helpers.Converters;assembly=VrPlayer.Helpers     5      9system&clr-namespace:System;assembly=mscorlib     5      $	��199��5        � 	Resources  5	      <   6VrPlayer.Helpers.Converters.QuaternionToCoordConverter   CoordConverter  X��%@   &	        &	        5
   
   60   ��5   
   X��6%   5      .��5      ��  �� Orientation$ Vertical=�6   $��16,16,16,10q�6(   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   $	��200��6-   �� 5      $��50 �6#   .+�5      �� $��0��6   $��0��6$   $��Scale factor:��61   6K   �� 5      $��1��6   $��0��6%    � Minimum$ 0Q�6]    � Maximum$ 50Q�6i    � Value 62   ��  �� Path$ PositionScaleFactor�6x   �� 5      $��2��6   $��0��6&   ��63   �� $ PositionScaleFactor�6_   5      5       5!      