   M S B A M L   `   `   `  ����C  ?Stratego, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Stratego.ViewStratego.View  5   	   7 clr-namespace:Stratego.ViewModelStratego.ViewModel  5   	       Stratego.View.HomePage   5      %localclr-namespace:Stratego.View  5   	   .	viewmodel clr-namespace:Stratego.ViewModel  5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     N� Title$  STRATEGO��5      $	��650��6   $
��1000��6%      MaterialDesignBody#���   5   
   $��Regular"�5   
   $��13(�5   
   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   
      TextRenderingMode$
 Auto=�5   
    N� ShowsNavigationUI .    MaterialDesignFont N� 
FontFamily# �  5   
    � DataContext 5
      ��   ViewModelLocator �� Source# [  �� Path$ SessieViewModel� N� 
Background 5      �� 5   
   	 �� ImageSource$	 /old-paper.jpg��6   .��5      � .+�5   
   �� $��NEW GAME��6     ButtonStyle1#��[ 6$   $��294,432,526,143q�6u   
 J� RenderTransformOrigin$
 0.433,1.656&�6�   ��6J   �� *NavigateToSetupCommand+6�   �� 5   
   $��LEADERBOARD��6     ButtonStyle2#��[ 6'   $��526,432,294,143q�6~   ��6M   �� *NavigateToLeaderBoardCommand+6~   �� 5    
     ButtonStyle3#��[ 6<   $��ADMIN��6b   $��410,531,410,44q�6r   ��6   �� *NavigateToAdminCommand+6r   #  MaterialDesignThemes.Wpf.Card  5$   
   $��32q�6   $��16,16,16,223q�6+   $��
2147483645��6A   ��5&      �� 5'       �� Color$ #73B2F5��6"    �� Opacity$ 0Q�62   .��5)      �� $��0,-29,0,-15.667q�6   ��5*      �� 5+       �� 	UriSource$ /stratego_trim.png?�6#   5-      5.      52      53      