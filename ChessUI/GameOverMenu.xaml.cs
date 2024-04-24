using System;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    public partial class GameOverMenu : UserControl
    {
        public BoardPage BoardPage;

        public GameOverMenu()
        {
            InitializeComponent();   
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            BoardPage = new BoardPage();
            BoardPage.MenuContainer = null;
        }
    }
}
