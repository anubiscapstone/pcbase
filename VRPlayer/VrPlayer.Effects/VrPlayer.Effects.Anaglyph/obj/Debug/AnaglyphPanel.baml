   M S B A M L   `   `   `  ����K  GVrPlayer.Helpers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcCclr-namespace:VrPlayer.Helpers.Converters;assembly=VrPlayer.HelpersVrPlayer.Helpers.Converters  5       VrPlayer.Effects.Anaglyph-   'VrPlayer.Effects.Anaglyph.AnaglyphPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z
convertersCclr-namespace:VrPlayer.Helpers.Converters;assembly=VrPlayer.Helpers     5        � 	Resources  5	      =   7VrPlayer.Helpers.Converters.EnumMatchToBooleanConverter   enumConverter��%   &	          5
   
   61   5      .��5      ��  �� Orientation$ Vertical=�6   $��16q�6(   .+�5   
   �� $��Stereo mode��6   $
��Bold"�6'   $��0,0,0,8q�69   6L   � 5   
   $��0,0,0,16q�6    � RowDefinitions 5      �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   .+�5      �� $��0��6   $��0��6)   .+�5      	�  	� 	GroupName$ 
StereoMode��6   $��Side by side��65    d� 	IsChecked 5      ��  �� Path$ 
StereoMode� �� Mode$ TwoWay=� �� 	Converter# [  	 �� ConverterParameter$	 2��	� 5      $ 
StereoMode��6   $��Over / Under��65    5      �� $ 
StereoMode�$ TwoWay=�# [  $	 1��5      5      �� 5    
   $��Anaglyph type��6   $
��Bold"�6)   $��0,0,0,8q�6;   6N   � 5!   
   $��0,0,0,16q�6    5"      �� 5#      $
��Auto �6     5%      �� 5&      $
��Auto �6#   .+�5(      �� $��0��6   $��0��6)   .+�5)      	� $ AnaglyphMode��6   $��Red-Blue��67    5*      �� $ AnaglyphMode�$ TwoWay=�# [  $	 0��	� 5-      $ AnaglyphMode��6   $��Blue-Red��67    5.      �� $ AnaglyphMode�$ TwoWay=�# [  $	 1��51      52      53      54      