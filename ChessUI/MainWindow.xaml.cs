﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Position chosenPos;
        public Position chosenFinalPos;
        public ChessBoard board = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All };
        public bool chosenPiece = false;
        
        public MainWindow()
        {
            InitializeComponent();
               
            DrawBoard(board);
            board.Move("e4");
            DrawBoard(board);
            
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && !IsMenuOnScreen())
            {
                PauseMenu pauseMenu = new PauseMenu();
                MenuContainer.Content = pauseMenu;            
            }    
        }
        
        private bool IsMenuOnScreen()
        {
            return MenuContainer.Content != null;
        }

        private void MovePiece(ChessBoard board )
        {
           
            var moves = board.Moves(chosenPos);
            Move m = new Move(chosenPos, chosenFinalPos);
            board.Move(m);

            DrawBoard(board);
            
        }

        private void GenerateMove(ChessBoard board)
        {
            board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);
        }
        private void GetPlayerMove(ChessBoard board)
        {
            string moveInput = Console.ReadLine();

            if (board.IsValidMove(moveInput))
            {
                board.Move(moveInput);
            }
            else
            {
                GetPlayerMove(board);
            }
            
            
        }
        private void DrawBoard(ChessBoard board)
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

            if (!chosenPiece)
            {
                chosenPos = pos;
                chosenPiece = true;
            }
            else
            {
                chosenFinalPos = pos;
                chosenPiece = false;
                MovePiece(board);
            }
            
            
            
            
        }

        private Position PointToSquare(Point point)
        {
            double squareSideLength = PieceGrid.ActualHeight / 8;
            short column = (short)(point.X  / squareSideLength);
            short row = (short)((point.Y / squareSideLength));

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
    }
}
