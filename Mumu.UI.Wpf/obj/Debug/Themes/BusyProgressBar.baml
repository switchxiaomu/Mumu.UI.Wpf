   M S B A M L   `   `   `  ����F  BMumu.UI.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Mumu.UI.WpfMumu.UI.Wpf  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   BaseBusyProgressBarStyle �� 
TargetType!    Mumu.UI.Wpf.BusyProgressBar �� Property �� Value  MouseOverBackgroundColor �� Triggers �� Binding �� Path �� RelativeSource	 �� Mode
 �� Value �� 
TargetType ��Name ! UNEnabledInputBackgroundColor J� SnapsToDevicePixels J� OpacityMask !� Visual �Name ��Name  ProgressBarPercentConverter `� 	Converter �� AncestorType �� 
StartPoint �� EndPoint � Color � Offset  ProgressBarOffset1Converter �� ElementName  ProgressBarOffset2Converter �� Triggers �� 
TargetName P� Property P� Value A�Name  ThicknessToDoubleConverter �� 	Converter F�Name  �� StrokeEndLineCap! �� StrokeStartLineCap  RingProgressBarConverter" J� RenderTransformOrigin# N� EnterActions$ g� RepeatBehavior% �� 
TargetName& �� TargetProperty	' W� To( g� Duration) N� ExitActions* �� BasedOn   CircularBusyProgressBarStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      #localclr-namespace:Mumu.UI.Wpf  5        5      �� 5   
   $. (/Mumu.UI.Wpf;component/Style/Colors.xaml?�6   �� 5   
   $6 0/Mumu.UI.Wpf;component/Converters/Converter.xaml?�6   %�  &	        7  7  7  7  7  7  7  7  7  7  7  7  7  '   z    7   &	     7   �� 5      "   6-   .�5   
   ��  � ��$	 480��6"   �� 5   
    � ��$ 50��6#   �� 5   
    � ��$ 20(�6%   �� 5   
    �@J�SnapsToDevicePixels . 60   �� 5   
    � ��
 ���� 6'   �� 5   
    � ��$ 0q�6,   �� 5   
    � ��8   6'   �� 5   
    �@  DisplayText .  6(   �� 5   
    �@  ProgressBarStyle$ Standard=�6-    5   
   �� 5       6   �� $ ProgressBarStyle� �� *Self+$	 OneWay=�
 Standard6w   .a�5      ��  � �� 5      �� 5      " �6*   .R�5      � .+�5   "   �� $ 
PART_Track��5   %   8�� # z 5   %    5   &   !� 5    *    5!   .   �� 5"   2   
���   ���5#   5   �� *ActualWidth+ �� *TemplatedParent+��5$   5   �� *ActualHeight+ �� *TemplatedParent+5%   5   5'   +   ._�5)   &   � .+�5*   *   �� $ PART_Indicator��5+   -   $
��Left=�5,   -   #��z��5-   -   # z 5.   -   � 5/   *   $ 	Animation��50   -   }�. $y�	Collapsed=�52   -   .+�53   .   �� $ PART_GlowRect��54   1   $	��100��55   1   $��0,0,0,0q�56   1   $
��Left=�57   1   
������ ._�59   2   �� #��z��6<   5:   /   5;   +   5<   '   5=   #   �� 5>   "   
������ #��z��5@   %   #��z��5A   %   �� 5B   "   $ 
TxtPercent��5C   %   $��Center=�5D   %   $��Center=�5E   %   #��z��5F   %   #��z��5G   %   #��z��5H   %   #��z��5I   %   $y�	Collapsed=�5J   %   ��5K   &   `� 5L   *   8  .1�5M   .   �� $ Minimum�66    6E   �� $ ProgressBarL��� 5N   .   $ Maximum�66    6E   �� $ ProgressBarL��� 5O   .   $ Value�66    6C   �� $ ProgressBarL�5P   +   5R   #   �� 5S   "   $ TxtPercentWhite��5T   %   $��Center=�5U   %   $��Center=�5V   %   #��z��5W   %   #��z��5X   %   #��z��5Y   %   
�������$y�	Collapsed=�5[   %    5\   &   �� 5]   *   $	 0,0&�6>   $	 1,0&�6O   .��5^   .   � $ White��6;    5_   2   `� 5`   6   8  .1�5a   :   �� $ Minimum�6B    6Q   �� $ ProgressBarL��� 5b   :   $ Maximum�6B    6Q   �� $ ProgressBarL��� 5c   :   $ Value�6B    6O   �� $ ProgressBarL��� 5d   :   $ ActualWidth�6B    6U   �� $ ProgressBarL��� 5e   :   $ TxtPercentWhite��6B   $ ActualWidth�6`   5f   7   5h   /   � 5i   .   $ Transparent��6;    5j   2   `� 5k   6   8  .1�5l   :   �� $ Minimum�6B    6Q   �� $ ProgressBarL��� 5m   :   $ Maximum�6B    6Q   �� $ ProgressBarL��� 5n   :   $ Value�6B    6O   �� $ ProgressBarL��� 5o   :   $ ActualWidth�6B    6U   �� $ ProgressBarL��� 5p   :   $ TxtPercentWhite��6B   $ ActualWidth�6`   5q   7   5s   /   5t   +   ��5v   &   `� 5w   *   8  .1�5x   .   �� $ Minimum�66    6E   �� $ ProgressBarL��� 5y   .   $ Maximum�66    6E   �� $ ProgressBarL��� 5z   .   $ Value�66    6C   �� $ ProgressBarL�5{   +   5}   #   5       5�      �� 5�   "   $

 True��6�    6.   �� $ DisplayText� �� *Self+$	 OneWay=�.a�5�   &   �� $ 
TxtPercent��6-    � y�$ Visible=�6[   �� 5�   &   $ TxtPercentWhite��6-    � y�$ Visible=�6`   5�   #   P� 5�   "    �@�IsIndeterminate . . �5�   &   �� $ PART_Indicator��6-    � y�$ 	Collapsed=�6_   �� 5�   &   $ 	Animation��6-    � y�$ Visible=�6Z   5�   #   5�      5�      5�      �� 5�       6   �� $ ProgressBarStyle� �� *Self+$	 OneWay=�
 Circular6w   .a�5�      ��  � ��$ 64��6*   �� 5�       � ��$ 64��6+   �� 5�       � ��
 ���� 6/   �� 5�       � ��$ 6q�64   �� 5�       � ��8  60   �� 5�       � �� 5�      �� 5�      " �6*   .R�5�      � $ GrdMain��6#   .+�5�   "   A� $ Ellipse_Track��5�   %   #��z��5�   %   #��z��5�   %   ��5�   %   �� *BorderThickness+8  F� 5�   "   $ Path_Indicator��5�   %   #��z��5�   %   $  Round=�5�   %   $! Round=�5�   %   ��5�   %   �� *BorderThickness+8  ��5�   &   `� 5�   *   8 	 .1�5�   .   �� $ ActualWidth�66    6I   �� $ ProgressBarL��� 5�   .   $ ActualHeight�66    6J   �� $ ProgressBarL��� 5�   .   $ BorderThickness�66    6M   �� $ ProgressBarL��� 5�   .   $ Minimum�66    6E   �� $ ProgressBarL��� 5�   .   $ Maximum�66    6E   �� $ ProgressBarL��� 5�   .   $ Value�66    6C   �� $ ProgressBarL�5�   +   5�   #   F� 5�   "   $ Path_Animation��5�   %   $" 0.5,0.5&�5�   %   #��z��5�   %   $  Round=�5�   %   $! Round=�5�   %   $y�	Collapsed=�5�   %   ��5�   %   �� *BorderThickness+8 
 z�5�   &   �� 5�   *   
Rotate��6:   ��5�   &   `� 5�   *   8  .1�5�   .   �� $ ActualWidth�66    6I   �� $ ProgressBarL��� 5�   .   $ ActualHeight�66    6J   �� $ ProgressBarL��� 5�   .   $ BorderThickness�66    6M   �� $ ProgressBarL�5�   +   5�   #   �� 5�   "   $ 
TxtPercent��5�   %   $��Center=�5�   %   $��Center=�5�   %   #��z��5�   %   #��z��5�   %   #��z��5�   %   #��z��5�   %   $y�	Collapsed=�5�   %   ��5�   &   `� 5�   *   8  .1�5�   .   �� $ Minimum�66    6E   �� $ ProgressBarL��� 5�   .   $ Maximum�66    6E   �� $ ProgressBarL��� 5�   .   $ Value�66    6C   �� $ ProgressBarL�5�   +   5�   #   5�       5�      �� 5�   "   $

 True��6�    6.   �� $ DisplayText� �� *Self+$	 OneWay=�.a�5�   &   �� $ 
TxtPercent��6-    � y�$ Visible=�6[   5�   #   P� 5�   "    �@�IsIndeterminate . . �5�   &   �� $ Path_Indicator��6-    � y�$ 	Collapsed=�6_   �� 5�   &   $ Path_Animation��6-    � y�$ Visible=�6_   # 5�   &   �� 5�   *   .��5�   .   �� .��5�   2   W� $$ Forever��5�   5   $% Rotate��5�   5   $& Angle�5�   5   $	' 360X�5�   5   $( 0:0:2D�5�   5   5�   /   5�   +   ) 5�   &   �� 5�   *   .��5�   .   �� .��5�   2   W� $% Rotate��5�   5   $& Angle�5�   5   $( 0:0:0D�5�   5   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�      8*   "   6@   .�5�   
   ��  �@  ProgressBarStyle$ Standard=�6-   �� 5�   
    �@  DisplayText .  6(   5      �� 5     8*   "   5  	   .�5  
   ��  �@  ProgressBarStyle$ Circular=�6-   �� 5  
    �@  DisplayText .  6(   5     5	     