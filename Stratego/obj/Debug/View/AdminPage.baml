   M S B A M L   `   `   `  ����C  ?Stratego, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Stratego.ViewStratego.View  5      7 clr-namespace:Stratego.ViewModelStratego.ViewModel  5          Stratego.View.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Stratego.View     5      6	viewmodel clr-namespace:Stratego.ViewModel     5        N� Title$  	AdminPage��5
      $	��650��5      $
��1000��6      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignFont N� 
FontFamily# �  5   
    � DataContext 5   
   ��   ViewModelLocator �� Source# [  �� Path$ NavigationViewModel� N� 
Background 5      �� 5   
    �� ImageSource$ /old-paper.jpg��6   	 � 	Resources	 5      ��%    5      .��5      � .+�5   
   �� $��SESSIONS��6@     ButtonStyle1#��[ 6S   $��97,377,723,198q�6y   ��6   �� *NavigateToSessionsCommand+6y   �� 5   
   $��PLAYERS��6?     ButtonStyle2#��[ 6Q   $��97,288,723,287q�6w   ��6   �� *NavigateToPlayersCommand+6w   �� 5   
   $��BOARDS��6>     ButtonStyle3#��[ 6O   $��97,199,723,376q�6u   ��6   �� *NavigateToBoardsCommand+6u   �� 5   
   $��337,146,108,135q�6   $+��%/Stratego;component/stratego_trim.png��6)   $
��Fill=�6X   �� 5   
   $
��HOME��6<    * &MaterialDesignFloatingActionDarkButton#��[ 6K   $��63,110,881,484q�6�   ��6   �� *NavigateToHomeCommand+6�   5!      5"      