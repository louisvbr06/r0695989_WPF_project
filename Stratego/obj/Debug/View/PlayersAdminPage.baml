   M S B A M L   `   `   `  ����C  ?Stratego, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Stratego.ViewStratego.View  5   
   7 clr-namespace:Stratego.ViewModelStratego.ViewModel  5   
   $    Stratego.View.PlayersAdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   
   @d2http://schemas.microsoft.com/expression/blend/2008     5   
   -localclr-namespace:Stratego.View     5   
   g cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac	 _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am
 iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak  gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag! cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae" aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah# dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ay	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     	 
                        ! " # 5   
   l	viewmodel clr-namespace:Stratego.ViewModel     	 
                        ! " # 5   
   $	��650��5   
   $
��1000��6     N� Title$  PlayersAdminPage��5   
      MaterialDesignBody#���   6#   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont N� 
FontFamily# �  5   
    � DataContext 5   
   ��   ViewModelLocator �� Source# [  �� Path$ PersoonViewModel� N� 
Background 5      �� 5   
    �� ImageSource$ /old-paper.jpg��6   	 � 	Resources	 5      
 �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self �� RelativeSource �� Binding �� ElementName �� Value��%	  '��       '�� �     �� 5   
   "
 ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 60   �� # Z $&  (Validation.Errors)/ErrorContent�5      5      �� 5!   
   "
 ��6    5"      �� 5#       6   �� $ TextboxNaam��$ (Validation.HasError)� true6f   .a�5$      ��  � {� .  62   5%      �� 5'       6   �� $ TextboxScore��$ (Validation.HasError)� true6g   .a�5(      ��  � {� .  62   5)      5+      5,      .��5.      � .+�5/   
   � $��	0,0,678,0q�6   .+�50      �� -   5        $��TextboxNaam��50      $
��Left=�6w   $��38��6�   $��
87,281,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��180��6�   $��22(�6�   ��6)   �� *CurrentPersoon.Naam+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 6�   �� 51      -   5        $��TextboxScore��51      $
��Left=�6z   $��38��6�   $��
87,398,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��180��6�   $��22(�6�   ��6*   �� *CurrentPersoon.Score+$ TwoWay=� . 6�   �� 52      $��87,461,55,64q�6   $+��%/Stratego;component/stratego_trim.png��6*   $
��Fill=�6Y   �� 54      $��ADMIN��6A     ButtonStyle1#��[ 6Q   $��87,54,55,521q�6w   ��6   �� *NavigateToAdminCommand+6w   �� 55        ButtonStyle3#��[ 6;   $��48��6a   $��87,151,186,451q�6m   $��Center=�6�   $��Center=�6�   $��49��6�   ��6   �� *ToevoegenCommand+.��56      -  'MahApps.Metro.IconPacks.PackIconControl  2 ! ,MahApps.Metro.IconPacks.PackIconMaterialKind   Plus   Kind# Z 6,   $��24��57      $��24��58      5:      �� 5<      #��[ 6=   $��48��6c   $��154,151,119,451q�6o   $��Center=�6�   $��Center=�6�   $��49��6�   ��6   �� *VerwijderenCommand+.��5=           DeleteForever# Z 6,   $��24��5>      $��24��5?      5A      �� 5D        ButtonStyle2#��[ 6:   $��48��6`   $��218,151,55,451q�6m   $��Center=�6�   $��Center=�6�   $��49��6�   ��6   �� *WijzigenCommand+.��5E           Pencil# Z 6,   $��24��5F      $��24��5G      5H      �� 5I      $
��NAAM��6   $��Center=�6#   $��134,246,98,0q�6@   $	��Top=�6V   $��22(�6n   $��90��6|   $
��Bold"�6�   �� 5J      $��SCORE��6   $
��Left=�6$   $��134,367,0,0q�6?   $	��Top=�6T   $��90��6l   $��31��6w   $
��Bold"�6�   $��22(�6�   �� 5K      $
��Left=�6   $	��100��63   $��37,275,-364,0q�6@   $	��Top=�6W   $	��649��6o    J� RenderTransformOrigin$ 0.5,0.5&�6{   z�5L      V� 5M      .~�5N      �� �� 5O      �� 5P       �� Angle$ -90.33Q�6*   T� 5Q      5R      5T      5U      � 5Y   
   $��509,68,163,88q�6    � RowDefinitions 5Z      �� 5[      $��6* �6    �� 5\      $��7* �6     � ColumnDefinitions 5_      �� 5`      $��* �6#   �� 5a      $��* �6#   .+�5c      �� $��0,0,10,0q�6     �� SelectionMode$  Single=�5e      $��2��6.   ���	#FFFAFAFA$��2��5f   V   ��5d      �� *
Personen+! �� SelectedItem! 5f      �� *CurrentPersoon+" �� View" 5i      �� 5k      .P�5l      �� # �� Width$	# 150��6)   $
��Naam��5m   )   $ �� DisplayMemberBinding$ 5n   )   �� *Naam+�� 5o      $	# 150��6)   $��Score��5p   )   $ 5q   )   �� *Score+5t      5v      5x      5y      5z      