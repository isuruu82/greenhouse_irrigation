   M S B A M L   `   `   `  ����J  FWatering System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Watering_SystemWatering_System  5          Watering_System.Line_Tile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Watering_System     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��310��5	      $	��300��6   .��5
      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5   �   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6.   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5      � $��5q�6   ���	#FF807A7A J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6'      ShadowDepth$ 1Q�66      RenderingBias$ Quality=�6F   .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6!   $	��Top=�6:   $
��Left=�6R   .+�5      �� -   5         ��Name$ btnlogo��5   !    0  ,MaterialDesignFloatingActionMiniAccentButton#��[  62   $��80��6x   $��80��6�   $��0q�6�   $��5q�6�   ���	#FF00E24A	 J� RenderTransformOrigin$		 1,1&�6�   
 J� OpacityMask
 �	#FFE20707��5      �� 5   "    �� ImageSource$ Images/plantline.png��6-    j� Stretch$ UniformToFill=�6P   5      �� 5      $ Vertical=�6&   $��70��6=   $��20,0,0,0q�6I   .+�5      �� -   5        $��	line_name��5   <   $��Plant Line 1��6(   $��20(�6M   $
��Wrap=�6[   $��0 5 0 0q�6o   
�������6�   �� 5      $��Flowers��6(   $��12(�67   $��0 2 0 0q�6E   $
��Wrap=�6V   
�������6   �� 5      $��Updated��6(   $��10(�67   $��0 2 0 0q�6E   $
��Wrap=�6V   
�������6   5      5      �� 5      $ Vertical=�6!   $	��175��68   $��Center=�6E   .+�5      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $��13(�6(   $��Current Temperature��66   $��2q�6Q   
�������$	��182��6o   $
��Left=�6{   6�   �� 5       $��13(�6(   $��30��66   $��2q�6@   
������� �� TextAlignment$ Right=�6^   $��80��6t   5!      �� 5"      $ 
Horizontal=�6%   $��Center=�6>   .+�5#      �� $��13(�6(   $��Current Humidity��66   $��2q�6N   
�������$	��182��6l   $
��Left=�6x   6�   �� 5$      $��13(�6(   $��30��66   $��2q�6@   
�������$ Right=�6^   $��80��6t   5%      �� 5&      $ 
Horizontal=�6%   $��0 0 0 20q�6>   $��Center=�6P   .+�5'      �� $��13(�6(   $��Current Soil Moistue��66   $��2q�6R   
�������$	��182��6q   $
��Left=�6}   6�   �� 5(      $��13(�6(   $��30��66   $��2q�6@   
�������$ Right=�6^   $��80��6t   5)      �� 5*      $ 
Horizontal=�6%   $��Center=�6>   .+�5+      �� $��13(�6(   $��Today Avg Temperature��66   $��2q�6S   
�������$	��182��6r   $
��Left=�6~   6�   �� 5,      $��13(�6(   $��30��66   $��2q�6@   
�������$ Right=�6^   $��80��6t   5-      �� 5.      $ 
Horizontal=�6%   $��Center=�6>   .+�5/      �� $��13(�6(   $��Today Avg Moisture��66   $��2q�6P   
�������$	��182��6n   $
��Left=�6z   6�   �� 50      $��13(�6(   $��30��66   $��2q�6@   
�������$ Right=�6^   $��80��6t   51      �� 52      $ 
Horizontal=�6%   $��Center=�6>   .+�53      �� $��13(�6(   $��Today Avg Moisture��66   $��2q�6P   
�������$	��182��6o   $
��Left=�6{   6�   �� 54      $��13(�6(   $��30��66   $��2q�6@   
�������$ Right=�6^   $��80��6t   55      56      �� 57      59      �� 5:      .+�5;      �� -   5        $��Refresh��5;   !   6J   5<      5=      5>      5?      5@      5A      