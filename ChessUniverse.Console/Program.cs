using Chessuniverse.Library;
using static System.Console;

using System.Text;
using Chessuniverse.Library.Pieces;

OutputEncoding = Encoding.UTF8;

ChessBoard chessboard = new ChessBoard();
chessboard.SetStartPosition();
PrintBaord(chessboard);
Input();
void PrintBaord(ChessBoard chessBoard)
{

    Console.WriteLine("   A  B  C  D  E  F  G  H");
    for (int row = 0; row < 8; row++)
    {
        Write($"{8 - row} ");
        for (int col = 0; col < 8; col++)
        {
            bool isLightSquare = (row + col) % 2 == 0;
            Console.BackgroundColor = isLightSquare ? ConsoleColor.Gray : ConsoleColor.DarkGray;
            Console.ForegroundColor = isLightSquare ? ConsoleColor.Black : ConsoleColor.White;
            var piece = chessboard[row, col];
            char symbol = piece?.GetSymbol() ?? '.';

            Write($" {symbol} ");
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}
void Input()
{
    Write("Enter the start position: ");
    string? source = ReadLine();
    Write("Enter the end position: ");
    string? target = ReadLine();

    Coordinate start = new Coordinate((Letters)(source[0] - 'A'), (Numbers)('8' - source[1]));
    Coordinate end = new Coordinate((Letters)(target[0] - 'A'), (Numbers)('8' - target[1]));

    switch (chessboard[(int)start.Number, (int)start.Letter])
    {
        case Bishop:
            BishopMove(start, end);
            break;
        case King:
            KingMove(start, end);
            break;
            case Knight:
                KnightMove(start, end);
            break;
        case Pawn:
            PawnMove(start, end);
            break;
            case Rook:
                RookMove(start, end);
            break;
            case Queen:
                QueenMove(start, end);
            break;
        default:
            WriteLine("Selected piece is not implemented yet.");
            break;
    }
}
#region BishopMove
void BishopMove(Coordinate start, Coordinate end)
{
    if (chessboard[(int)start.Number, (int)start.Letter] is Bishop bishop)
    {
        if (bishop.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Bishop moved.");
        }
        else WriteLine("Bishop's move blocked or invalid. There are other interupting figure");
    }
    else WriteLine("No Bishop found at start position.");
}
#endregion
#region KingMove
void KingMove(Coordinate start, Coordinate end)
{
    if (chessboard[(int)start.Number, (int)start.Letter] is King king)
    {
        if (king.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("King moved.");
        }
        else WriteLine("King cant move, because there is another figure with the same color");
    }
    else WriteLine("No King found at start position.");
}
//void KingMove(Coordinate start, Coordinate end)
//{
//    King king = new King(PieceColor.White);
//    WriteLine(king.Move(start, end) ? "King can move" : "King cannot move");
//}
#endregion
#region KnightMove
void KnightMove(Coordinate start, Coordinate end)
{
    if (chessboard[(int)start.Number, (int)start.Letter] is Knight knight)
    {
        if (knight.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Knight moved.");
        }
        else WriteLine("Knight cant move, because there is another figure with the same color");
    }
    else WriteLine("No knight found at start position.");
}
#endregion
#region PawnMove
void PawnMove(Coordinate start, Coordinate end)
{
    if (chessboard[(int)start.Number, (int)start.Letter] is Pawn pawn)
    {
        if (pawn.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Pawn mkoved");
        }
    }
    else WriteLine("No pawn found at start position.");
}
#endregion
#region QueenMove
void QueenMove(Coordinate start, Coordinate end)
{
    if (chessboard[(int)start.Number, (int)start.Letter] is Queen queen)
    {
        if(queen.Move(start, end, chessboard)){ 
        Console.Clear();
        PrintBaord(chessboard);
            WriteLine("Queen moved");
        }
    }
    else WriteLine("No queen found at start position.");
}
#endregion
#region RookMove
void RookMove(Coordinate start, Coordinate end)
{
    if (chessboard[(int)start.Number, (int)start.Letter] is Rook rook)
    {
        if (rook.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Rook moved.");
        }
    }
    else WriteLine("No rook found at start position.");
    }
#endregion

