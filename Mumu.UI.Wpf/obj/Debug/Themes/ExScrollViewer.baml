   M S B A M L   `   `   `  ����F  BMumu.UI.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Mumu.UI.WpfMumu.UI.Wpf  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollBar.Thumb.Width  ScrollThumb_Background $  ScrollThumb_MouseOver_Background  ScrollBarThumb  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� RadiusX �� RadiusY �� Triggers P� Property	 P� Value
 �� 
TargetName  VerticalScrollBarPageButton  for_scrollbar �Name J� SnapsToDevicePixels ]�Name J� IsMouseOver ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� Triggers �� PageLeftCommand ! HorizontalScrollBarPageButton �� PageRightCommand     Mumu.UI.Wpf.ExScrollViewer ��Name � Cursor ��Name �� ScrollableHeight � Maximum �� Orientation �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility  �� VerticalOffset! � Value" �� ScrollableWidth# �� ViewportWidth,$ �� %ComputedHorizontalScrollBarVisibility% �� HorizontalOffset& :� RoutedEvent' :� 
SourceName( �� 
TargetName) �� TargetProperty	* W� To+ g� Duration, g� 	BeginTime�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      #localclr-namespace:Mumu.UI.Wpf  5      .sys&clr-namespace:System;assembly=mscorlib  5      %�  &	        &	      &	 :     &	 Y     7  7  &	     &	 �    7   7  7  7  7  7  7  '   �    7  7  X�5      6Q�62   ��5      	#90686868��6@   ��5	      #686868��6H   �� 5      "  n�6#   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � �� 5      �� 5      " n�6"   .R�5      � .+�5      �� $ 	thumbRect��5      8��  $ 3��5      $ 3��5      5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 	thumbRect��6%   8   � ��6L   5      5      5       5!      �� 5$      "  ��60   .�5%   
   ��  �@�OverridesDefaultStyle . 62   �� 5&   
    � ��
 ���� 6'   �� 5'   
    � |� .  6&   �� 5(   
    � �� .  6&   �� 5)   
    �@J�Opacity$ 0Q�6$   �� 5*   
    � �� 5+      �� 5,      " ��6"   .R�5-      �� #��z��5.      #��z��5/      #��z��50      51      53      54      �� 57      "  ��6"   .�58   
   ��  �@��IsPressAndHoldEnabled .  69   �� 59   
    �@��IsFlicksEnabled .  63   �� 5:   
    � ��
 ���� 6'   �� 5;   
    � ��$ 0,1,1,1q�6#   �� 5<   
    � ��8   6"   �� 5=   
    � ��$ 5��6%   �� 5>   
    �@J�Opacity$ 0Q�6$   �� 5?   
    � �� 5@      �� 5A      " ��6"   .R�5B      � $ Bg��6    . .+�5C      ]� $ 
PART_Track��5D      ��. #{�z 5F       5G      �� 5H   "   #��Z 6/   8�� 6\    5J      �� 5K   "   #��Z 6/   8�� 6^    5M      n� 5N   "   8�� 6(   5P      5Q      5R      5T       5U   
   P� 5V       �@��Orientation$	 
Horizontal=�6-   . �5W      ��  � ��
 ���� 6/   �� 5X       � ��$ 1,0,6,1q�6+   �� 5Y       � ��$ 5��6+   �� 5Z       � ��$ 5��6.   �� 5[       � ��$
 Auto��6*   �� 5\       �@J�Opacity$ 0Q�6,   �� 5]       � �� 5^      �� 5_      " ��6*   .R�5`      � $ Bg��6#    . .+�5a   "   ]� $ 
PART_Track��6(   #{�z 6<    5b   &   �� 5c   *   #��Z 67   8�� 6f    5e   &   �� 5f   *   #��Z 67   8�� 6g    5h   &   n� 5i   *   8�� 60   5k   #   5l      5m      5o      5p      5r      �� 5u      "    6   .�5v   
   ��  � ��
 �����6(   �� 5w   
    � ��$ 0q�6,   �� 5y   
    � ��$
 Auto=�6:   �� 5{   
    � ��$
 Auto=�68   �� 5|   
    � �� 5}      �� 5~      "   6"   .R�5      �� $ Bd��5�      
������ #��z��5�      #��z��5�       . ._�5�      � #��z��6   .+�5�      �� #��z��5�   !   #��z��5�   !   # z 5�   !   �� 5�      $ PART_VerticalScrollBar��5�   !   $��Right=�5�   !   # z 5�   !   $ Vertical=�5�   !   8��  # z 5�   !   #y�z 5�   !   #! z  5�   !   �� 5�      $ PART_HorizontalScrollBar��5�   !   $��Bottom=�5�   !   # z" 5�   !   $ 
Horizontal=�5�   !   8�� # z# 5�   !   #y�z$ 5�   !   #! z% 5�   !   5�      5�       5�      :� 5�      $& 
MouseEnter��6'   $' Bd��6@   .[�5�      �� .��5�   "   �� .��5�   &   W� $( PART_VerticalScrollBar��5�   )   $) Opacity�5�   )   $* 1X�5�   )   $+ 0:0:0.2D�5�   )   5�   #   5�      5�      :� 5�      $& 
MouseLeave��6'   $' Bd��6@   .[�5�      �� .��5�   "   �� .��5�   &   W� $, 0:0:0X�5�   )   $( PART_VerticalScrollBar��5�   )   $) Opacity�5�   )   $* 0X�5�   )   $+ 0:0:0.3D�5�   )   5�   #   5�      5�      :� 5�      $& 
MouseEnter��6'   $' Bd��6@   .[�5�      �� .��5�   "   �� .��5�   &   W� $( PART_HorizontalScrollBar��5�   )   $) Opacity�5�   )   $* 1X�5�   )   $+ 0:0:0.2D�5�   )   5�   #   5�      5�      :� 5�      $& 
MouseLeave��6'   $' Bd��6@   .[�5�      �� .��5�   "   �� .��5�   &   W� $, 0:0:1X�5�   )   $( PART_HorizontalScrollBar��5�   )   $) Opacity�5�   )   $* 0X�5�   )   $+ 0:0:0.5D�5�   )   5�   #   5�      5�      5�      5�      5�      5�      