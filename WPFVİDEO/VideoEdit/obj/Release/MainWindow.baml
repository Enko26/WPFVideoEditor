   M S B A M L   `   `   `  ����   	WPFVİDEO    WPFVideoEdit.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  
RootWindow�� � Title$ 
MainWindow��$��509.008��$��1076.971�� � WindowStyle$
 None=� � Icon$ Resources/icono2.png��$��0q� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�.��� -    �Name$ RootGrid������  �� ImageSource$5 /Resources\Awesome Wallpapers - wallhaven_cc.jpg��	 j� Stretch$	 UniformToFill=�.+��� -   
 ��Name$
 	videolist�� �� CornerRadius$ 1��$	��486��$��
950,22,0,0q�$	��Top=����	#CC000000._��� -    ��Name$ lbList��
������  J� 	AllowDrop . ���	#FF008BFF$��10(���Z� � -   $ 	gridmedya��$��
0,22,127,0q�$��2�� � ColumnDefinitions �� $
��807* ��� $	��48* ��� $	��95* �.+�r� -    r�Name$ medyacontrol�� r� UnloadedBehavior$ Manual=� .  r� LoadedBehavior$ Manual=� r� Stretch$
 Fill=�$��
10,0,-10,0q�$��3�� r� Volume �� *Value+ �� ElementName$ 	slidervol���� -   $
 bordercontrol�����	#00000000$��0q�$��22��$	��Top=�
���   �._�� -   $ GridControls��$��0,0,88,-243q� � RowDefinitions �� $	��11* ��� $
��255* � �� $
��246* ��� $	��60* ��� $
��683* �.+��� -	    ��Name$ btcikis��$��665,0,0,247q�$��0q�
������ $��18��$��18�� J� RenderTransformOrigin$ 3.032,2.389&�$��2��$��2������ $ Resources/btn_close_p.png��$
	 None=��� -
   $ 	btkücül��$��Bottom=�$��642,0,23,247q�$��0q�
������ $��18��$��18��$ 	0.5,-1.37&�$��2��$��2������ $ Resources/btn_min_p.png��9� -    9�Name$ medya��$��Medya��$
��Left=�$	��Top=� 9� 
IsExpanded .  
�������$	��117��$	��111��$��10(�   ExpanderStilo#���    J� OpacityMask
 �   �$��2����Z� .���� -   $
 bordermedios��$ 8��$
��Left=�$��97��$	��Top=�$	��109�����	#99000000._�o� -    o�Name$ 	menufiles��
������ 
�������$��10(���Z� .@�m� -    m�Name$ dosyac��$��Dosyayı Aç��m� -   $ 
cokludosya��$��Birden Fazla Dosya Aç��m� -   $ cikis��$��Çıkıs��9� -   $ ayarlar�� .  $��Ayarlar��$
��Left=�$	��Top=�
�������$	��119��$��	116,0,0,0q�$	��109��$��10(�#���   
 �   �$��2����Z� .���� -   $

 ayar��$��0,0,10,0q�$ 8��$
��Left=�$��95��$	��Top=�$��92�����	#99000000._�o� -   $ menuayar��
������ 
�������$��10(���Z� .@�m� -   $ oynat��$��Oynat��m� -   $ 	Menupause��$��Duraklat��m� -   $ önceki��$��Önceki��m� -   $ sonraki��$��Sonraki��m� -   $	 dur��$	��Dur��$ -1,1.833&�$��20��$��50��z�V� .~��� �� ��  �� Angle$ 1.745Q�T� 9� -   $
 Sess�� .  $	��Ses��$
��Left=�$	��Top=�
�������$	��119��$��7,0,0,0q�$	��107��$��10(�#���   $��1��$��2��$��2����Z� .���� -   $

 mses��$��0,0,10,0q�$ 8��$
��Left=�$��95��$	��Top=�$��92�����	#99000000._�o� -   $ menusesi��
������ 
�������$��10(���Z� .@�m� -   $ 	parcayiac��$��Parçayı Aç��m� -   $ parcalariac��$��Parçaları Aç��m� -   $ sesart��$��Ses +��m� -   $ sesazal��$��Ses -��9� -    $ video�� .  $��Video��$
��Left=�$	��Top=�
�������$	��119��$��59,0,0,0q�$��99��$��10(�#���   $��2��$��2��.���� -!   $
 bordervideo��$ 8��$
��Left=�$��95��$	��Top=�$��94�����	#99000000._�o� -"   $ 	menuvideo��
������ 
�������$��10(���Z� .@�m� -#   $ videoac��$��Videoları Aç��m� -$   $ 	fullekran��$��Tam Ekran Yap���� -%    ��Name$ lbAbout��$��Diken Desing��$
��Left=�$	��Top=�$��
466,-4,0,0q�
���   �$��Arial Rounded MT Bold)�$	��114��$��26��
���  ��$��15(�$
��Bold"�$��2��$��2��
���   � J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect      Color$	  Red��!   Opacity$	! 0.8Q��� -&   $
 BorderMedyaControls��$��0,444,127,5q����	#00000000._�� -'   $ GridControl��.+��� -(   " ��Name$" 	slidervol��$
��Left=�$	��Top=�$��57��$��831,33,0,-3q�$��30��# � Maximum$# 1Q�$ �� TickFrequency$	$ 0.1Q�% � Value$	% 0.5Q�& �� IsMoveToPointEnabled& .  
 Estilo#���  �� -)   $ lbrepeat��$��Tekrarla��$
��Left=�$��
376,18,0,0q�$	��Top=�
�������$��8(����� ' �� 
TargetType"' ��.��� ( �� Property( � y�) �� Value$) 	Collapsed=�* �� Triggers* �� + �� Binding+ �� *IsMouseOver+$ btRepeat��, �� Value, True.a��� ( � y�$) Visible=��� -*   $ lbstop��$��Duraklat��$
��Left=�$��
414,17,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btStop��, True.a��� ( � y�$) Visible=��� -+   $ lbback��$��Önceki��$
��Left=�$��
449,17,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btBack��, True.a��� ( � y�$) Visible=��� -,   $ lbPausa��$��Pausa��$
��Left=�$��
474,17,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btPausa��, True.a��� ( � y�$) Visible=��� --   $ lbPlay��$��Oynat��$
��Left=�$��
467,17,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btPlay��, True.a��� ( � y�$) Visible=��� -.   $ lbNext��$��Sonraki��$
��Left=�$��
499,17,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btNext��, True.a��� ( � y�$) Visible=��� -/   $ lbVol��$��
Ses Ayarı��$
��Left=�$��
801,23,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btVol��, True.a��� ( � y�$) Visible=��� -0   $ 
lbdesacrep��$��
Tekrar yok��$
��Left=�$��
376,18,0,0q�$	��Top=�
�������$��8(����� "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btRepeatActivo��, True.a��� ( � y�$) Visible=��� -1   $ lbSCreen��$��	Tam Ekran��$
��Left=�$��
898,24,0,0q�$	��Top=�
�������$��8(�$��52������ "' ��.��� ( � y�$) 	Collapsed=�* �� + �� *IsMouseOver+$ btScreen��, True.a��� ( � y�$) Visible=��� -2   - ��Name$- btRepeat��$
��Left=�$��20��$��
379,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$ ��Resources/btn_Repeat_p.png��$ 0.667,0.167&��� -3   $- btStop��$
��Left=�$��20��$��
417,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$��Resources/btn_stop_P.png���� -4   $- btBack��$
��Left=�$��20��$��
454,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$"��Resources/btn_previous_P.png���� -5   $- btPause��$
��Left=�$��20��$��
479,36,0,0q�$	��Top=�$��20��$��Resources/btn_pause_P.png��. �� StretchDirection$. DownOnly=��� -6   $- btPlay��$
��Left=�$��20��$��
479,35,0,0q�$	��Top=�$��20��$��Resources/btn_play_P.png��$. DownOnly=��� -7   $- btNext��$
��Left=�$��20��$��
504,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$��Resources/btn_next_P.png���� -8   $- btVol��$
��Left=�$��20��$��
808,35,0,0q�$	��Top=�$��20��$��UniformToFill=�$ ��Resources/btn_volume_P.png��
 ������� -9   $- btRepeatActivo��$y�	Collapsed=�$
��Left=�$��20��$��
379,36,0,0q�$	��Top=�$��20��$��UniformToFill=�$!��Resources/Btn_RepeatC_p.png��$ 0.667,0.167&��� -:   $- btScreen��$
��Left=�$��13��$��
917,43,0,0q�$	��Top=�$��17��$!��Resources/dimensions(2).png���� -;   $" slideravance��$
��Left=�$��	47,10,0,0q�$	��Top=�$	��841��  EstiloSlider#���  & . �� -<   $ lbtime��$��893,8,24,31q�
�������$��10(�