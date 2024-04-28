using Chess;

var board = ChessBoard.LoadFromFen("rnbqkbnr/pppppppp/3Q4/8/8/8/PPPPPPPP/RNB1KBNR w KQk - 0 1");
ChessBoard b = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All };
Dictionary<Move, int> moveValue = new Dictionary<Move, int>();
b = board;
List<Move> moves = new List<Move>();
foreach (Move m in b.Moves())
{
    Console.WriteLine(m);
    moves.Add(m);
}
b.Move(moves[1]);
//board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);
Console.WriteLine(board.ToAscii()   );

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