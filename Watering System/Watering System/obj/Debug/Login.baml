   M S B A M L   `   `   `  ����J  FWatering System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Watering_SystemWatering_System  5   	       Watering_System.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:Watering_System  5   	   -   5          � Title$  Login��5	   	   $	��300��6   $	��500��6$    � 
ResizeMode$ NoResize=�60   
������  � WindowStyle$
 None=�6_    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�   .��5
      � -   5         � UseLayoutRounding .  .+�5   
   ��  �� RadiusY$ 10��6    �� RadiusX$ 10��6!   
�������6.   �� 5   
   $��Images/Background.png��6   $��UniformToFill=�6/    �� StretchDirection$ DownOnly=�6G   $��	250,0,0,0q�6c   �� 5   
   $��	250,0,0,0q�6   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6-    �� CenterX$	 0.5Q�6;   �� 5       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5       �� CenterY$	 0.5Q�6.    �� CenterX$	 0.5Q�6<   T� 5      5      .��5      �  � Color$ 	#FF009E00��6#   � 5      $ Black��6#    � Offset$ 1Q�61   � 5      $ 	#99000000��6#   $ 0.624Q�65   � 5      $ 	#DD0F7000��6#   $ 0.221Q�65   5      5      �� 5    
   $��10,20,200,10q�6   .+�5!      �� $��Login��6   $��Segoe UI Black)�6$   $��24(�6@   $	��Top=�6O   $
��Left=�6g   �� 5"       �� Orientation$ 
Horizontal=�6   $��5,0,0,0q�62   .+�5#      �� $
��Left=�6   $	��Top=�67   $	��232��6O   $
��Wrap=�6[   ���	#FF6E6E6E$!��Developed By Isuru Udayanga��6�   5$      �� 5%      $
��Left=�6   $��5,0,0,0q�63   $	��Top=�6D   $	��125��6\   $
��Wrap=�6h   ���	#FF6E6E6E$��MIT Individual Project��6�   �� 5&      $
��0,15q�6   $ 
Horizontal=�6'   .+�5'      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6*   $��Center=�69   ���#7070706k   �� 5(      -   5         ��Name$ 	txt_usnam��5(      $��ISURU��6-   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	User Name��6:   $	��200��6e   $��5q�6r   6�   5)      �� 5*      $ 
Horizontal=�6   .+�5+        $	 Key=�6*   $��Center=�65   ���#7070706g   G� 5,      -   5         G�Name$ txt_pw��5,       G� Password$	 123��6.   $ Password��6=   $	��200��6g   $��5q�6t   6�   5-      �� 5.      $��0,0,50,0q�6   .+�5/      �� -   5         ��Name$ txtbl_ststus��5/      
���  �� �� TextAlignment$ Center=�6C   6\   50      �� 51      $ 
Horizontal=�6   $
��0,30q�62   .+�52      �� -   5        $
��Left=�52      $��LOGIN��64   ���	#FF3AB740$��18(�6[   $��Impact)�6i   $	��100��6}   $��	20,10,0,0q�6�   6�   �� 53      -   5        $
��Left=�53      $
��EXIT��64   ���	#FFF03434$��18(�6Z   $��Impact)�6h   $	��100��6|   $��	10,10,0,0q�6�   6�   54      55      �� 56   
   $��Images/Hayleys_logo.png��6   $��329,233,4,3q�61   $��UniformToFill=�6F   $ DownOnly=�6^   �� 57   
   $��250,10,0,50q�6   $��Center=�6*   .+�58      �� $"��Greenhouse Management System��6   $��16(�6<   $��Center=�6J   ���	#FFEEEDED$
��Bold"�6~   $��Yu Gothic UI Semilight)�6�   �� 59      $ ��Hayleys Agriculture       ��6   $��15(�6:   ���	#FFE6E5E5$��Segoe UI Semilight)�6_   $
��Wrap=�6   $	��126��6�   $��Center=�6�   5:      5;      5<      