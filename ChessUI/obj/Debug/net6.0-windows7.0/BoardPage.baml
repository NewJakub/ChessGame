   M S B A M L   `   `   `  ����B  >ChessUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChessUIChessUI  5   	       ChessUI.BoardPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ChessUI     5   	   -   5          N� Title$  	BoardPage��5	   	    N� 
Background
 �����.��5      � -   5         �Name$ 	BoardGrid��5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5!   
   � $��1��6   $��0��5"      $��8��5#      $��5��5$      .+�5%      A� -   5         A�Name$ 	PieceGrid��5%       A� Rows$ 8��5&       A� Columns$ 8��5'      $	��450��5)      $	��450��5*      ��5+      �� 5,       �� ImageSource$ Assets/board.png��6!   5.      5/      �� 50   
   -   5        	 ��Name$	 MenuContainer��50      $��0��51      $��0��52      $��7��53      $��8��54      �� 56   
   -   5        
 ��Name$
 PauseButton��56      $��50��58      $��50��59      
�������$��0q�5;      $��2��5<      .��5=      �� .+�5>      �� $��Assets/settings-icon.png��6   5?      5@      �� 5A   
   -   5         ��Name$ 
MenuBorder��5E      $��1��5A      $��1��5B      $��5��5C      $��6��5D      $y�	Collapsed=�5F      ._�5H      �� $	��500��6   $	��250��5I         BorderStyle#��[  5J      ._�5K      �  5L      �� 5M      �� 5N      �� 5O       5Q      �� 5R      .+�5U      �� -   5         ��Name$ 
ResultText��5U       $��
ResultText��5V        	TextStyle#��[ 5W      �� 5X      -   5        $
 NewGameButton��5X      $��1��5Y        ButtonStyle#��[ 5[      $	��300��5\      $��60��5]      .��5^      	Nová hra6   �� 5_      -	   5        $
 
QuitButton��5_      $��2��5`      #��[ 5b      $	��300��5c      $��60��5d      .��5e      Opustit aplikaci6$   5f      5g      5h      �� 5i   
   -
   5        $ 	TimerText��5j      $��40(�5i      $��5��5k      $��2��5l      $��2��5m      $��Center=�5n      $��Center=�5o      $y�Hidden=�5p      00:006/   5s      5t      