   M S B A M L   `   `   `  ����J  FWatering System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Watering_SystemWatering_System  5      "    Watering_System.Action_Panel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Watering_System     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $
��auto��6   .��5
      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitioningContentSlide��5   �   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6.   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5      �  � ColumnDefinitions 5      �� 5       � RowDefinitions 5      �� 5      $��60 �6$   �� 5      .+�5      � $��0��6   $��0��6'   .+�5      �� -   5         ��Name$ title��5       $��Center=�6/   $��10q�6L   $��Greenhouse Action Panel��6X   $��Center=�6x   $��30(�6�   
���   �$
��Bold"�6�   5      � 5      $��1��6    5      �� 5      �� 5      �� 5       5      �� 5      �� 5      .+�5!      � $��0��6   $��0��6(   .+�5"      �� .+�5#      �� -   5        $��Manage Plants��5#   %   $	��200��6=   $��10q�6J   
���   �
���E��$��30(�6�   6�   5$      5%      � 5&      $��0��6   $��1��6(   .+�5'      �� .+�5(      �� -   5        $	��200��5(   %   $��10q�62   
�������
��� � �$��30(�6d   ��5)   "   �� 5*   &   $
��Wrap=�60   $��Manage Pest Control Dates��6D    �� TextAlignment$ Center=�6e   5,      5-      5.      � 5/      $��0��6   $��2��6(   .+�50      �� .+�51      �� -   5        $	��200��51   %   $��10q�62   
���   �
���2͚�$��30(�6j   ��52   "   �� 53   &   $
��Wrap=�60   $��Harvesting Dates��6D   $ Center=�6\   55      56      57      � 58      $��1��6   $��0��6(   .+�59      �� .+�5:      �� -   5        $��Not Assigned��5:   %   {�.  $	��200��6N   $��10q�6[   
���   �
�������$��18(�6�   6�   5;      5<      � 5=      $��1��6   $��1��6(   .+�5>      �� .+�5?      �� -   5        $��Not Assigned��5?   %   {�.  $	��200��6N   $��10q�6[   
���   �
�������$��18(�6�   6�   5@      5A      � 5B      $��1��6   $��2��6(   .+�5C      �� .+�5D      �� -   5        $��Not Assigned��5D   %   {�.  $	��200��6N   $��10q�6[   
���   �
�������$��18(�6�   6�   5E      5F      5G      5H      5I      5J      5K      