using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Chess;
namespace ChessUI
{    
    public partial class BoardPage : Page
    {
        public static GameSettings GameSettings { get; set; }
        public GameSettings gameSettings { get; set; }
        
        public Position chosenPos = new Position();
        public Position chosenFinalPos = new Position();
        public ChessBoard board = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All };

        public int c = 0;

        public BoardPage()
        {

            InitializeComponent();

            if (GameSettings.isTimerOn == true) TimerText.Visibility = Visibility.Visible;
            if (!GameSettings.isWhite)
            {
                GenerateMove(board);
            }
            DrawBoard(board);
            PauseMenu.GameSettings = GameSettings; 

        }

        public void DrawBoard(ChessBoard board)
        {
            PieceGrid.Children.Clear();
            string fen = board.ToFen().Split(' ')[0].Replace("/", string.Empty);
            if (!GameSettings.isWhite)
            {
                char[] charArray = fen.ToCharArray();
                Array.Reverse(charArray);
                fen = new string(charArray);
            }
            foreach (char item in fen)
            {
                Image image = new Image();
                switch (item)
                {
                    case 'P':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/w_pawn.png", UriKind.Relative));
                        break;
                    case 'R':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/w_rook.png", UriKind.Relative));

                        break;
                    case 'B':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/w_bishop.png", UriKind.Relative));

                        break;
                    case 'N':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/w_knight.png", UriKind.Relative));

                        break;
                    case 'K':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/w_king.png", UriKind.Relative));

                        break;
                    case 'Q':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/w_queen.png", UriKind.Relative));

                        break;
                    case 'p':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/b_pawn.png", UriKind.Relative));

                        break;
                    case 'r':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/b_rook.png", UriKind.Relative));

                        break;
                    case 'b':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/b_bishop.png", UriKind.Relative));

                        break;
                    case 'n':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/b_knight.png", UriKind.Relative));

                        break;
                    case 'k':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/b_king.png", UriKind.Relative));

                        break;
                    case 'q':
                        PieceGrid.Children.Add(image);
                        image.Source = new BitmapImage(new Uri(@"Assets/b_queen.png", UriKind.Relative));

                        break;
                    default:
                        for (int i = 0; i < char.GetNumericValue(item); i++)
                        {
                            Image image1 = new Image();
                            PieceGrid.Children.Add(image1);
                        }
                        break;
                }
            }
        } 

        private void PieceGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(PieceGrid);
            Position pos = PointToSquare(point);


            if (c == 0)
            {
                
                if (board[pos]?.Color == null) return;
                if (board[pos].Color == 2 && GameSettings.isWhite) return;
                if (board[pos].Color == 1 && !GameSettings.isWhite) return;

                chosenPos = pos;
                c++;
            }
            else if (c == 1)
            {
                c++;
                chosenFinalPos = pos;



                if (GetPlayerMove(new Move(chosenPos, chosenFinalPos), board)) GenerateMove(board);
                chosenPos = new Position();
                chosenFinalPos = new Position();
                c = 0;
            }
        }

        private bool GetPlayerMove(Move move, ChessBoard board)
        {
            if (board.IsValidMove(move))
            {
                board.Move(move);
                DrawBoard(board);

                if (board.IsEndGame)
                {
                    ShowGameOverMenu();
                }
                return true;
            }
            return false;
        }
        
        private void GenerateMove(ChessBoard board)
        {
            if (board.IsEndGame)
            {
                ShowGameOverMenu();
            }
            else
            {
                Dictionary<Move, int> moveValue = new Dictionary<Move, int>();
                foreach (Move m in board.Moves())
                {
                    ChessBoard b = ChessBoard.LoadFromFen(board.ToFen());
                    b.Move(m);
                    int boardValue = 0;
                    string fen = b.ToFen().Split(' ')[0].Replace("/", string.Empty);
                    foreach (char p in fen)
                    {
                        switch (p)
                        {
                            case 'P':
                                boardValue++;
                                break;
                            case 'R':
                                boardValue += 5;
                                break;
                            case 'B':
                                boardValue += 3;
                                break;
                            case 'N':
                                boardValue += 3;
                                break;
                            case 'K':
                                boardValue += 1000;
                                break;
                            case 'Q':
                                boardValue += 9;
                                break;
                            case 'p':
                                boardValue--;
                                break;
                            case 'r':
                                boardValue -= 5;
                                break;
                            case 'b':
                                boardValue -= 3;
                                break;
                            case 'n':
                                boardValue -= 3;
                                break;
                            case 'k':
                                boardValue -= 1000;
                                break;
                            case 'q':
                                boardValue -= 9;
                                break;
                            default:
                                continue;
                        }
                    }
                    moveValue.Add(m, boardValue);
                }

                if(GameSettings.isWhite) board.Move(moveValue.MinBy(entry => entry.Value).Key);
                else board.Move(moveValue.MaxBy(entry => entry.Value).Key);
                DrawBoard(board);
                //ChessBoard b = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All }; 
                //Dictionary<Move, int> moveValue = new Dictionary<Move, int>();
                //b = board;
                //foreach (Move m in b.Moves())
                //{
                //    b = board;

                //    //b.Move(m);
                //    int boardValue = 0;
                //    string fen = b.ToFen().Split(' ')[0].Replace("/", string.Empty);
                //    foreach (char p in fen)
                //    {
                //        switch (p)
                //        {
                //            case 'P':
                //                boardValue++;
                //                break;
                //            case 'R':
                //                boardValue += 5;
                //                break;
                //            case 'B':
                //                boardValue += 3;
                //                break;
                //            case 'N':
                //                boardValue += 3;
                //                break;
                //            case 'K':
                //                boardValue += 1000;
                //                break;
                //            case 'Q':
                //                boardValue += 9;
                //                break;
                //            case 'p':
                //                boardValue--;
                //                break;
                //            case 'r':
                //                boardValue -= 5;
                //                break;
                //            case 'b':
                //                boardValue -= 3;
                //                break;
                //            case 'n':
                //                boardValue -= 3;
                //                break;
                //            case 'k':
                //                boardValue -= 1000;
                //                break;
                //            case 'q':
                //                boardValue -= 9;
                //                break;
                //            default:
                //                continue;
                //        }
                //    }
                //    moveValue.Add(m, boardValue);
                //}

                ////board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);
                //board.Move(moveValue.MaxBy(entry => entry.Value).Key);
                //DrawBoard(board);
            }
        }
        
        private void ShowGameOverMenu()
        {
            GameSettings.isGamePaused = true;
            MenuBorder.Visibility = Visibility.Visible;
            if (board.BlackKingChecked) 
                ResultText.Text = "Bílý vyhrál!";

            else if (board.WhiteKingChecked) 
                ResultText.Text = "Černý vyhrál!";

            else 
                ResultText.Text = "Remíza!";
        }
        
        private Position PointToSquare(Point point)
        {
            double squareSideLength = PieceGrid.ActualHeight / 8;
            short column = (short)(point.X / squareSideLength);
            short row = (short)(point.Y / squareSideLength);
            if (GameSettings.isWhite) 
            {
                switch (row)
                {
                    case 0:
                        row = 7;
                        break;
                    case 1:
                        row = 6;
                        break;
                    case 2:
                        row = 5;
                        break;
                    case 3:
                        row = 4;
                        break;
                    case 4:
                        row = 3;
                        break;
                    case 5:
                        row = 2;
                        break;
                    case 6:
                        row = 1;
                        break;
                    case 7:
                        row = 0;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (column)
                {
                    case 0:
                        column = 7;
                        break;
                    case 1:
                        column = 6;
                        break;
                    case 2:
                        column = 5;
                        break;
                    case 3:
                        column = 4;
                        break;
                    case 4:
                        column = 3;
                        break;
                    case 5:
                        column = 2;
                        break;
                    case 6:
                        column = 1;
                        break;
                    case 7:
                        column = 0;
                        break;
                    default:
                        break;
                }
            }
            

            return new Position(column, row);
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow.FindName("MainFrame") as Frame).Source = null;
            (Application.Current.MainWindow.FindName("MainFrame") as Frame).Source = new Uri("Settings.xaml", UriKind.Relative);

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        //Application.Current?.Shutdown(); ??????????????????

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            PauseMenu pauseMenu = new PauseMenu();
            MenuContainer.Content = pauseMenu;
            GameSettings.isGamePaused = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(GameSettings.isTimerOn) 
            {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Tick += dtTicker;
                dispatcherTimer.Start();
            }
        }

        private int increment = 0;

        private void dtTicker(object sender, EventArgs e)
        {
            if (!GameSettings.isGamePaused)
            {
                increment++;
                DateTime dt;
                dt = new DateTime(2008, 1, 1, 18, (int)MathF.Floor(increment / 60), increment % 60);
                TimerText.Text = dt.ToString("mm:ss", CultureInfo.InvariantCulture);
            }
        }
    }
}
