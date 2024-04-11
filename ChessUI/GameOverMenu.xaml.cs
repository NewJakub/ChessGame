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
        public event Action<Option> OptionSelected;

        public GameOverMenu()
        {
            InitializeComponent();
            
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected.Invoke(Option.Restart);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
