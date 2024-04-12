using System;
using System.DirectoryServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Chess;
namespace ChessUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Position chosenPos = new Position();
        public Position chosenFinalPos = new Position();
        public ChessBoard board = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All };
        

        public bool isWhite;
        public bool isTimerOn;
        public int c = 0;
        
        public MainWindow()
        {
            if (Random.Shared.Next(0,2) == 1) 
            {
                isWhite = false;            
            }
            else
            {
                isWhite = false;
            }
            
            InitializeComponent();
            DrawBoard(board);

            if (!isWhite) GenerateMove(board);
            if (isTimerOn)
            {
                Timer timer = new Timer();
                TimerContainer.Content = timer;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !IsMenuOnScreen())
            {
                PauseMenu pauseMenu = new PauseMenu();
                MenuContainer.Content = pauseMenu;
            }    
            else if (e.Key == Key.Escape && IsMenuOnScreen())
            {
                MenuContainer.Content = null;
            }
        }
        
        private bool IsMenuOnScreen()
        {
            return MenuContainer.Content != null;
        }
        public void makeDisapeaer()
        {
            MenuContainer.Content = null;
        }
        private void MovePiece(ChessBoard board )
        {
           
            Move m = new Move(chosenPos, chosenFinalPos);
            board.Move(m);

            DrawBoard(board);
                        
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
        public void DrawBoard(ChessBoard board)
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

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(PieceGrid);
            Position pos = PointToSquare(point);


            if (c == 0)
            {
                if (board[pos]?.Color == null) return;
                
                if (board[pos].Color == 2 && !isWhite) return;

                if (board[pos].Color == 1 && isWhite) return;

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

        private Position PointToSquare(Point point)
        {
            double squareSideLength = PieceGrid.ActualHeight / 8;
            short column = (short)(point.X  / squareSideLength);
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

        private void ShowGameOverMenu() 
        {
            GameOverMenu gameOverMenu = new GameOverMenu();
            MenuContainer.Content = gameOverMenu;
            if (board.BlackKingChecked)
            {
                gameOverMenu.ResultText.Text = "Bílý vyhrál!";
            }
            else if (board.WhiteKingChecked) 
            { 
                gameOverMenu.ResultText.Text = "Černý vyhrál!";

            }
            else
            {
                gameOverMenu.ResultText.Text = "Remíza!";

            }
        }
        public void StartNewGame(ChessBoard board)
        {
            board = new ChessBoard();
            DrawBoard(board);
        }
        

        public void StopShowingMenu()
        {
            MenuContainer.Content = null;
        }
    }
}
