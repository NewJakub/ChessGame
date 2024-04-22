using System;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public GameSettings GameSettings;


        public Settings()
        {
            InitializeComponent();
            GameSettings = new GameSettings(true, false);

        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (ColorSelector.Text == "Bílá") GameSettings.isWhite = true;
            else GameSettings.isWhite = false;

            if (ColorSelector.Text == "Ano") GameSettings.isTimerOn = true;
            else GameSettings.isTimerOn = false;
            SettingsFrame.NavigationService.Navigate(new Uri("BoardPage.xaml", UriKind.Relative));


        }


    }

    public class GameSettings
    {
        public bool _isWhite;
        public bool isWhite
        {
            get { return _isWhite; }
            set { _isWhite = value; }
        }
        public bool _isTimerOn;
        public bool isTimerOn
        {
            get { return _isTimerOn; }
            set { _isTimerOn = value; }
        }

        public GameSettings(bool IsWhite, bool IsTimerOn)
        {
            isTimerOn = IsWhite;
            isWhite = IsTimerOn;
        }


    }
}
