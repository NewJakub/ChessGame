using Chess;

var board = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All };
string fen = board.ToFen().Split(' ')[0].Replace("/", string.Empty);

Position pos = new Position("a2");
Position pos1 = new Position("a4");


while (!board.IsEndGame) 
{
    var moves = board.Moves();
    board.Move(moves[Random.Shared.Next(moves.Length)]);
}

Console.WriteLine(board.ToAscii());
Console.WriteLine(board.WhiteKingChecked);
Console.WriteLine(board.BlackKingChecked);

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

class ChessLogic
{
    
    public void GenerateMove(ChessBoard board) 
    {
        board.Move(board.Moves()[Random.Shared.Next(board.Moves().Length)]);
    }
    public void GetPlayerMove(ChessBoard board)
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
}