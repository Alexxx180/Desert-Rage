   M S B A M L   `   `   `  ���� N  JDesertRageResources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullrLclr-namespace:DesertRage.Resources.Localization;assembly=DesertRageResources!DesertRage.Resources.Localization  W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   CharacterSide  �Name � DataContext � RowDefinitions  StatusPanel �� ResourceKey �� Path  TimeBar  SvgIcon �� Triggers �� Value �� Binding �� ElementName	 N� EnterActions
 C� ResourceKey J� Opacity o�Name A� Columns A� Rows � ToolTip-    'DesertRage.Resources.Localization.Words    Fight    FightDescription  VerticalCenter m� Icon  SvgIconUniform �� 
TargetType 
 Impact �� BasedOn �� Property �� Value �� RelativeSource �� AncestorType    Skills    SkillDescription    Items    ItemsDescription m� Command    Shield    ShieldDescription     Escape!    EscapeDescription"    Berserk#    BerserkDescription$ �� Triggers% �� 
TargetName�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     WlocaleLclr-namespace:DesertRage.Resources.Localization;assembly=DesertRageResources  %1	  &	        7  0�� $ 
BackAccent��17  7  7  0�� $ 
MenuOption��17  7  0�� $ TargetTemplate��17  0�� $ 
MenuOption��17  7  0�� $ SkillTemplate��10�� $ PlayerSkills��10�� $ 
MenuOption��17  7  0�� $ ItemTemplate��10�� $ PlayerItems��10�� $ 
MenuOption��17  7  0�� $ 
MenuOption��17  7  0�� $ 
MenuOption��17  7  0�� $ 
BackAccent��1�� .R�� $  BattleCharacter�� �� $��1�� �� $��0.125* ��� $��0.05* ��� $��0.675* ��� $��0.15* �.+��� 8��  ��2  �� $ Player.Hero��� 8�� $��1���� 8�� $��2�� �� $ Player.Hero.Image�����  ��  True �� $ BattleCharacter��$ DataContext.IsAct�	 �� .��C� $
 	Disappear���� 8�� $��2��$ 0Q� �� $ Player.Hero.Action�����  ��  True �� $ BattleCharacter��$ DataContext.IsAct�	 �� .��C� $
 Appear��o� $ MOptions��$��3��$y�	Collapsed=����� .R�A� $ 3��$ 2��.@�m� ��2  �� �� $
��Bold"�#�Z �� �� #�Z ���� #��Z 8��  �� 8�� $3 -/Resources/Media/Images/menu/stats/Attack.svg����2 ���� $ ViewModel.Enemies����� " m�8 	 .���  �@m�Command ��  �� *FindAncestor+ MenuItem$ DataContext.Fight���  �@m�CommandParameter ��  �� *Self+$ DataContext�m� ��2
  �� �� $
��Bold"�#�Z �� �� #�Z ���� #��Z 8��  �� 8�� $4 ./Resources/Media/Images/menu/stats/Special.svg����2 ���� $ Player.Skills���2 m� ��2  �� �� $
��Bold"�#�Z �� �� #�Z ���� #��Z 8��  �� 8�� $3 -/Resources/Media/Images/Menu/Topics/Items.svg����2 ���� $ Player.Items���2 m�  �� *Shield+��2  �� �� $
��Bold"�#�Z �� �� #�Z ���� #��Z 8��  �� 8�� $4 ./Resources/Media/Images/menu/stats/Defence.svg��m�  �� *Flee+��2 ���� #��Z  8��  �� �� $
��Bold"�#�Z  �� �� #�Z!  �� 8�� $2 ,/Resources/Media/Images/menu/stats/Speed.svg��m�  �� *Auto+��2  �� �� $
��Bold"�#�Z" �� �� #�Z# ���� #��Z" 8��  �� 8�� $; 5/Resources/Media/Images/Battle/Character/Ray/Icon.svg����2 $ ��  �� $ Time.Current�$
 1000��.a��� $% MOptions�� � y�$ Visible=�