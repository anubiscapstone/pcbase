   M S B A M L   `   `   `  ����  VrPlayer-    'VrPlayer.Views.Settings.EffectsSettings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      ��   �� Orientation$  Vertical=�6   $��16q�6(   .+�5   
   �� $��Effects��6   $��18(�6"   �� 5	   
   
�������$��1q�6&   $��1��6:   $
��auto��6E   $��0,0,0,24q�6R   �� 5
   
   $  
Horizontal=�6   $��0,0,0,16q�6.   .+�5      �� $��Current effect: ��6   �� 5      $	��200��6    �� DisplayMemberPath$
 Name��6Q   ��6#   �� *PluginManager.Effects+ �� SelectedItem 5      �� 5       �� Path$$ DataContext.State.EffectPlugin�6p    �� RelativeSource 6   �� *FindAncestor+ �� AncestorType" >�6p   5      5      �� 5   
   $	��275��6   
�������$��1q�66   ._�5      �� ��5      �� 5      $* $DataContext.State.EffectPlugin.Panel�6p    6   �� *FindAncestor+" >�6p   5      5      5      5      