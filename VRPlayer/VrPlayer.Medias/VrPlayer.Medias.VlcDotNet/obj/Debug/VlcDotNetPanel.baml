   M S B A M L   `   `   `  ����  VrPlayer.Medias.VlcDotNet.    (VrPlayer.Medias.VlcDotNet.VlcDotNetPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      ��   �� Orientation$  Vertical=�6   $��16q�6(   .+�5   
   �� $��	VLC paths��6   $
��Bold"�6%   $��0,0,0,8q�67   6J   � 5	   
   $��0,0,0,16q�6    � RowDefinitions 5
      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   $	��200��6-   �� 5      $��32 �6#   .+�5      �� $��0��6   $��0��6$   $��VLC application folder:��61   6U   �� 5      $��1��6   $��0��6&    �� 
IsReadOnly . ��63   ��  �� Path$ LibVlcDllsPath�6l   �� 5      -   5        $��2��5      $��0��6%   .��6V   ...6[   �� 5      $��0��6   $��1��6$   $��VLC plugins folder:��61   6Q   �� 5      $��1��6   $��1��6&    . ��63   �� $ LibVlcPluginsPath�6o   �� 5      -   5        $��2��5      $��1��6%   .��6Y   ...6^   5      �� 5   
   $��Options��6   $
��Bold"�6#   $��0,0,0,8q�65   6H   � 5   
   $��0,0,0,16q�6    5      �� 5      $
��Auto �6     5      �� 5       $��* �6#   $	��200��6-   .+�5"      �� $��0��6   $��0��6&    . {�.  ��63   �� $ Options�6w   5#      �� 5$   
   -   5        $
��Wrap=�5$      $>��8**Note: VLC media player 1.2 or later must be installed.��6(   
���  ��$��0,0,0,16q�6y    � Cursor$
 Hand��6�   6�   5%      5&      