   M S B A M L   `   `   `  ���� R  NDesert Rage, Version=1.0.5.5, Culture=neutral, PublicKeyToken=19516b28b7df7fbeG(clr-namespace:DesertRage.Controls.StatusDesertRage.Controls.Status  O KDesertRageDecorators, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Tclr-namespace:DesertRage.Decorators.UI.Bindings.Attach;assembly=DesertRageDecorators(DesertRage.Decorators.UI.Bindings.Attach �Xclr-namespace:DesertRage.Decorators.UI.Bindings.Converters;assembly=DesertRageDecorators,DesertRage.Decorators.UI.Bindings.Converters N JDesertRageResources, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullrLclr-namespace:DesertRage.Resources.Localization;assembly=DesertRageResources!DesertRage.Resources.Localization b ^SharpVectors.Converters.Wpf, Version=1.7.7.0, Culture=neutral, PublicKeyToken=b532964b8548be77fJclr-namespace:SharpVectors.Converters;assembly=SharpVectors.Converters.WpfSharpVectors.Converters W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   UnitName  	NameBlock  �� Path 	 HpBar � DataContext(    "DesertRage.Controls.Status.StatBar    Caption �� Member
    Bar    	ForeBrush �� ResourceKey 	 ApBar  TimeBar  StatsVertical A� Rows A� Columns)   #DesertRage.Controls.Status.IconStat	   Icon
   Stat  StatsHorizontal  ExperienceBar � Minimum � Value � Maximum � Orientation  SvgIcon(  "SharpVectors.Converters.SvgViewbox5  /DesertRage.Decorators.UI.Bindings.Attach.SvgBox   Source �� 	Converter?  9DesertRage.Decorators.UI.Bindings.Converters.UriConverter �� ConverterParameter   Stretch 	 SvgIconUniform 
 UnitIcon  
SlicedIcon � ColumnDefinitions � RowDefinitions  	FoeStatus A�Name �� 
TargetType �� Triggers �� Value �� Binding �� Property �� Value  
EquipPower 
 Impact �� Padding  IconNameStack �� Orientation�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     3status(clr-namespace:DesertRage.Controls.Status  _attachTclr-namespace:DesertRage.Decorators.UI.Bindings.Attach;assembly=DesertRageDecorators  g
convertersXclr-namespace:DesertRage.Decorators.UI.Bindings.Converters;assembly=DesertRageDecorators  WlocaleLclr-namespace:DesertRage.Resources.Localization;assembly=DesertRageResources  SsvgcJclr-namespace:SharpVectors.Converters;assembly=SharpVectors.Converters.Wpf  %�	  &	        7  &	 &     0�� $ HealthPointsBrush��1&	 �     0�� $ ActionPointsBrush��1&	 �     0�� $ 	TimeBrush��1&	 @    &	 �    &	     0�� $ ExperienceBrush��1&	 �    &		     &	
 �    7  &	 �    7 
 &	 H    7   7  7  &	 �    7  7  &	 v    7 
 7   �� .R��� 8��  ���� $
  Name��� .R��  �� .+�    �� $ locale:Words.HealthPoints�� �� $  Hp� 2  �� .R��  �� .+�    �� $ locale:Words.ActionPoints�� �� $  Ap� 2  �� .R��  �� .+�    �� $ locale:Words.Time�� �� $
  Time� 2  �� .R�A� $ 4��$ 1�� �� .+�  $3	 -/Resources/Media/Images/Menu/Stats/Attack.svg��
 �� $  Attack�  $4	 ./Resources/Media/Images/Menu/Stats/Defence.svg��
 �� $  Defence�  $2	 ,/Resources/Media/Images/Menu/Stats/Speed.svg��
 �� $  Speed�  $4	 ./Resources/Media/Images/Menu/Stats/Special.svg��
 �� $  Special��� .R�A� $ 1��$ 4�� �� .+�  $3	 -/Resources/Media/Images/Menu/Stats/Attack.svg��
 �� $  Attack�  $4	 ./Resources/Media/Images/Menu/Stats/Defence.svg��
 �� $  Defence�  $2	 ,/Resources/Media/Images/Menu/Stats/Speed.svg��
 �� $  Speed�  $4	 ./Resources/Media/Images/Menu/Stats/Special.svg��
 �� $  Special��� .R��  �� .+�� $��1�� �� $  Minimum� �� $  Current� �� $	  Max�$ Vertical=���2  �� .R�   �� $
��Left=� ��    $= 7/Resources/Media/Images/Locations/Total/Transparent.svg��$
 Fill=��� .R�   �� $
��Left=� ��    $= 7/Resources/Media/Images/Locations/Total/Transparent.svg��$ Uniform=��� .R��  �� $
  Icon�.+��� 8��  �� $��Center=�$��Center=��� .R��  ��  �� �� ��  �� �� �� .+��� 8��  ���� $  Size.Y����� $  Size.X��� .R��� $��2q� �� $
  Unit�
���   �
�������._�A� $ StatusPanel��$ 2��$	��100��$	��200��.+�A� $ 2��.+��� 8��  $
��Bold"��� 8�� �� 8��  �� $  Stats����� " A� �� 	 False �� $  	IsLearned�.a���  � y�$ 	Collapsed=���  � {�$ False���� .R��� $��2q�
���   �
�������._�]� 8��  .+�  $
��Left=�	 �� $
  Icon�   $= 7/Resources/Media/Images/Locations/Total/Transparent.svg��
 �� $  Power��� 8�� $	 5,0q�$
��Left=����� $  Description��� .R���  �� $ 
Horizontal=�$
��Left=�.+��� 8��  �� 8�� $
��10,0q�