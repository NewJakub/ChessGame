using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    public partial class GameOverMenu : UserControl
    {
        public GameOverMenu()
        {
            InitializeComponent();   
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
