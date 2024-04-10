using Chess;

var board = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All };
string fen = board.ToFen().Split(' ')[0].Replace("/", string.Empty);
Console.WriteLine(fen);
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