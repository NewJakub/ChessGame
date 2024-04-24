using System;
using System.Collections.Generic;
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

            DrawBoard(board);

        }



        public void DrawBoard(ChessBoard board)
        {
            if (GameSettings.isWhite == true)
            {
                PieceGrid.Children.Clear();

                string fen = board.ToFen().Split(' ')[0].Replace("/", string.Empty);
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
            else
            {
                PieceGrid.Children.Clear();

                string fen = board.ToFen().Split(' ')[0].Replace("/", string.Empty);
                char[] charArray = fen.ToCharArray();
                Array.Reverse(charArray);
                fen = new string(charArray);
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
        } 

        private void PieceGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(PieceGrid);
            Position pos = PointToSquare(point);


            if (c == 0)
            {
                if (GameSettings.isWhite)
                {
                    if (board[pos]?.Color == null) return;

                    if (board[pos].Color == 2 && GameSettings.isWhite) return;

                    if (board[pos].Color == 1 && !GameSettings.isWhite) return;

                }
                else if (!GameSettings.isWhite)
                {
                    if (board[pos]?.Color == null) return;

                    if (board[pos].Color == 2 && GameSettings.isWhite) return;

                    if (board[pos].Color == 1 && !GameSettings.isWhite) return;

                }

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

                board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);

                DrawBoard(board);
            }
        }
        private void ShowGameOverMenu()
        {
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
    }
}
