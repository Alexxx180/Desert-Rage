   M S B A M L   `   `   `  ���� O  KDesertRageDecorators, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Xclr-namespace:DesertRage.Decorators.UI.Bindings.Converters;assembly=DesertRageDecorators,DesertRage.Decorators.UI.Bindings.Converters  J FDesertRageModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullzNclr-namespace:DesertRage.Model.Locations.Battle.Stats;assembly=DesertRageModel'DesertRage.Model.Locations.Battle.Stats R NDesert Rage, Version=1.0.5.5, Culture=neutral, PublicKeyToken=19516b28b7df7fbe'clr-namespace:DesertRage
DesertRage N JDesertRageResources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullrLclr-namespace:DesertRage.Resources.Localization;assembly=DesertRageResources!DesertRage.Resources.Localization G(clr-namespace:DesertRage.Controls.StatusDesertRage.Controls.Status 9!clr-namespace:DesertRage.ControlsDesertRage.Controls    DesertRage.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     o
convertersXclr-namespace:DesertRage.Decorators.UI.Bindings.Converters;assembly=DesertRageDecorators     `statsNclr-namespace:DesertRage.Model.Locations.Battle.Stats;assembly=DesertRageModel     *localclr-namespace:DesertRage     _localeLclr-namespace:DesertRage.Resources.Localization;assembly=DesertRageResources     ;status(clr-namespace:DesertRage.Controls.Status     6controls!clr-namespace:DesertRage.Controls     -     �Name$
  This�� � Title$ Desert rage��$
��1080��$
��1920�� � WindowStyle$
 None=� � WindowState$ 	Maximized=� � 
ResizeMode$ NoResize=�.��� 
���   � � DataContext ��  �� ElementName$
 This��.+�$  DesertRage.Controls.SoundGroup  -     Name$ 
SoundTrack�� ��  �� Path$( "Adventure.Human.Player.Preferences�	   Music	 �� $ Music�
   Sound
 �� $ Sound�   Noise �� $ Noise��� -    ��Name$ Display��   
StretchAll#��[  ���� $
 View��� 
���   � J� IsHitTestVisible$ False�� J� Opacity �� $; 5Adventure.Human.Player.Preferences.Brightness.Current� �� 	Converter B   <DesertRage.Decorators.UI.Bindings.Converters.InvertConverter   �� ConverterParameter$	 100��� -    �Name$ 
PauseLabel������  �� 
TargetType" �  
BackAccent �� BasedOn# [  �� Triggers ��  �� Binding �� $ IsPaused� �� Value	 False.a���  �� Property � y� �� Value$ 	Collapsed=� � ColumnDefinitions �� �� �� .+�� $��40q� � RowDefinitions �� �� �� .+�(�   DesertUnicode#��[ .���� -  'DesertRage.Resources.Localization.Words   Pause#��Z  �� Padding$ 10q�� $��1�� �� �� �� .+��� -     WhiteOption#��[ .��(� #��[ .����    Resume#��Z d� -    d�Name$
 Info��#��[ $��1��.��(� #��[ .����    Hints#��Z �� -   #��[ $��2��.��(� #��[ .����     Exit#��Z  ! � ToolTip$! Shift + Esc��� $��1��$��40q�y��� $
 Info��$ 	IsChecked� F   @DesertRage.Decorators.UI.Bindings.Converters.VisibilityConverter   �� $
��0.1* ��� $
��0.8* ��� $
��0.1* �.+�� $��1��y��� $
 Info��$ 	IsChecked�" � 	Resources"   KeyboardKey��%   '��       7  �� " ��8    �� �� .+�� $��20q� �� �� ��  �� �� �� .+��� $��2��._�A� # A� Rows$# 2��.+�(� .���� $��E��(� .���� $��Enter���� $��1��$��1��._�A� $# 2��.+�(� .���� $��W��(� .���� $	��▲���� $��2��._�A� $# 2��.+�(� .���� $��A��(� .���� $	��←���� $��2��$��1��._�A� $# 2��.+�(� .���� $��S��(� .���� $	��▼���� $��2��$��2��._�A� $# 2��.+�(� .���� $��D��(� $��1��.���� $	��→��� $��20q�$��1�� �� �� ��  �� �� �� .+��� ._�A� $# 2��.+�(� .���� $	��Esc���� $��1��$��2��._�A� $# 2��.+�(� .���� $��Shift��(� .���� $	��↑���� $��2��$��2��._�A� $# 2��.+�(� .���� $
��Ctrl��� $��2��$��40q�y��� $
 Info��$ 	IsChecked�    �� $��0.15* ��� $
��0.7* ��� $��0.15* �.+�A� $��1��$# 9��.+�(�  
 Impact#��[ .���� $ 5q��� $   HealthPoints#�Z$  �� $�
 > 0 = ☺��(  "DesertRage.Controls.Status.StatBar  %   Caption% �� & �� Member$& locale:Words.HealthPoints��
'   Bar' 4  .DesertRage.Model.Locations.Battle.Stats.Slider  
(   Max$	( 100H�)   Current$	) 100H�*   	ForeBrush* �� + �� ResourceKey$+ HealthPointsBrush��(� #��[ .���� ,   Skills#��Z, $ 5q�  % �� $& locale:Words.ActionPoints��'   $( 40H�$) 40H�* �� $+ ActionPointsBrush���  �� $��0.175* ��� $��0.825* �.+���   SvgIcon#��[ $4 ./Resources/Media/Images/menu/skills/Poison.svg��(� #��[ $��1��.���� -   UseAntidote#��Z- $ 5q�(� #��[ .���� .   Cases#��Z. $ 5q�o� ���� .R�A� / A� Columns$/ 3��$# 2��.@�m� ���� $+ 
MenuOption��! �� �� $
��Bold"�0   Fight#�Z0 �� �� 1   FightDescription#�Z1 ���� #��Z0   VerticalCenter#��[ 2 m� Icon2 ��   SvgIconUniform#��[ $3 -/Resources/Media/Images/menu/stats/Attack.svg��m� ���� $+ 
MenuOption��! �� �� $
��Bold"�#�Z, �� �� 3   SkillDescription#�Z3 ���� #��Z, #��[ 2 �� #��[ $4 ./Resources/Media/Images/menu/stats/Special.svg��m� ���� $+ 
MenuOption��! �� �� $
��Bold"�4   Items#�Z4 �� �� 5   ItemsDescription#�Z5 ���� #��Z4 #��[ 2 �� #��[ $3 -/Resources/Media/Images/Menu/Topics/Items.svg��m� ���� $+ 
MenuOption��! �� �� $
��Bold"�6   Shield#�Z6 �� �� 7   ShieldDescription#�Z7 ���� #��Z6 #��[ 2 �� #��[ $4 ./Resources/Media/Images/menu/stats/Defence.svg��m� ���� $+ 
MenuOption������ 8   Escape#��Z8 #��[ ! �� �� $
��Bold"�#�Z8 �� �� 9   EscapeDescription#�Z9 2 �� #��[ $2 ,/Resources/Media/Images/menu/stats/Speed.svg��m� ���� $+ 
MenuOption��! �� �� $
��Bold"�:   Berserk#�Z: �� �� ;   BerserkDescription#�Z; ���� #��Z: #��[ 2 �� #��[ $; 5/Resources/Media/Images/Battle/Character/Ray/Icon.svg������ $+ 
BackAccent���  �� $��0.175* ��� $��0.825* �.+��� #��[ $3 -/Resources/Media/Images/menu/stats/Attack.svg��(� #��[ $��1��.���� <   BreakUp#��Z< $ 5q��  �� $��0.175* ��� $��0.825* �.+��� #��[ $2 ,/Resources/Media/Images/menu/stats/Speed.svg��(� #��[ $��1��.���� =   Tears#��Z= $ 5q��� -   > ��Name$> Curtain��$ False������ ? �� EndPoint$? 1,0.5&�@ �� 
StartPoint$@ 0,0.5&�.��� -	   FillCurtain��A � Color$A Black��B � Offset$B 0Q�� -
   BorderCurtain��$A Transparent��$B 0Q�C � TriggersC :� D :� RoutedEvent$D local:MainWindow.Escaping��[��� .���� -   .���� $+ BorderCurtainLeftToRight���� $+ FillCurtainLeftToRight��