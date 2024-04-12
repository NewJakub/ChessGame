using Chess;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    /// 

    public partial class GameOverMenu : UserControl
    {

        public GameOverMenu()
        {
            InitializeComponent();
            
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.StartNewGame(m.board);
            this.Visibility = Visibility.Collapsed;
            
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
