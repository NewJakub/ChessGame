using Chess;

var board = ChessBoard.LoadFromFen("rnbqkbnr/pppppppp/3Q4/8/8/8/PPPPPPPP/RNB1KBNR b KQk - 0 1");
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

//board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);
board.Move(moveValue.MinBy(entry  => entry.Value).Key);
foreach (var lll in moveValue)
{
    Console.WriteLine($"{lll.Key} + {lll.Value}");
}
Console.WriteLine(board.ToAscii());
Console.WriteLine(moveValue.MinBy(entry => entry.Value).Key);


//while (!board.IsEndGame) 
//{
//    var moves = board.Moves();
//    board.Move(moves[Random.Shared.Next(moves.Length)]);
//}

//Console.WriteLine(board.ToAscii());
//Console.WriteLine(board.WhiteKingChecked);
//Console.WriteLine(Random.Shared.Next(0, 2));

//if (board["a2"] != null)
//{
//    Console.WriteLine(fen);
//}
//foreach (Move m in board.Moves(pos))
//{
//    Console.WriteLine(m);

//}
//Console.Write(pos.File);

//var moves = board.Moves(pos);


//Move m = new Move(new Position("a2"), new Position("a3"));

//string stringSan;
//board.TryParseToSan(m, out stringSan);
//board.Move(stringSan);

board.ToAscii();
//ChessLogic c = new ChessLogic();

//char[] characters = { '┌', '─', '┐', '│', '└', '┘','\n' };
//while (!board.IsEndGame)
//{
//    Console.WriteLine(board.ToFen());
//    c.GetPlayerMove(board);
//    c.GenerateMove(board);

//    foreach (char item in characters)
//    {
//        Console.WriteLine(board.ToAscii().Replace(item, ' '));
//    }
//}

//class ChessLogic
//{
    
//    public void GenerateMove(ChessBoard board) 
//    {
//        board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);
//    }
//    public void GetPlayerMove(ChessBoard board)
//    {
//        string moveInput = Console.ReadLine();

//        if (board.IsValidMove(moveInput))
//        {
//            board.Move(moveInput);
//        }
//        else 
//        { 
//            GetPlayerMove(board);

//        }
//    }
//}