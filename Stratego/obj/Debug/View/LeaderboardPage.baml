   M S B A M L   `   `   `  ����C  ?Stratego, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Stratego.ViewStratego.View  5      7 clr-namespace:Stratego.ViewModelStratego.ViewModel  5      #    Stratego.View.LeaderboardPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Stratego.View     5      6	viewmodel clr-namespace:Stratego.ViewModel     5        N� Title$  LeaderboardPage��5
      $	��650��6    $
��1000��6-      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont N� 
FontFamily# �  5   
    � DataContext 5      ��   ViewModelLocator �� Source# [  �� Path$ PersoonViewModel� N� 
Background 5      �� 5   
    �� ImageSource$ /old-paper.jpg��6   	 � 	Resources	 5      ��%    5      .��5      � .+�5   
   �� $
��HOME��6<     ButtonStyle2#��[ 6K   $��59,168,761,407q�6q   ��6   �� *NavigateToHomeCommand+6q   � 5!   
   $��281,168,57,52q�6   
 � ColumnDefinitions
 5#      �� 5$      $��* �6#   �� 5%      $��* �6#   .+�5'      �� $��0��6   $��10q�6'    �� SelectionMode$ Single=�5)      $��2��5*   ;   ��5(      �� *
Personen+ �� SelectedItem 5*      �� *CurrentPersoon+ �� View 5,      �� 5-      .P�5.      ��  �� Width$	 170��6)   $��Voornaam��5/   %    �� DisplayMemberBinding 50   %   �� *Naam+�� 51      $	 200��6)   $��Score��52   %    53   %   �� *Score+55      57      59      5;      5=      