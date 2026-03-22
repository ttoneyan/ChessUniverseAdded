using Chessuniverse.Library.Pieces;

namespace Chessuniverse.Library;

public class ChessBoard
{
    private Piece[,] _squares=new Piece[8,8];

    public Piece this[int row, int col]
    {
        get=> _squares[row, col]; 
        set=>_squares [row, col]=value;
    }

    public Piece this[string coordinate]
    {
        get
        {
            if (coordinate.Length != 2) return null;

            int col = coordinate[0] - 'A';
            int row = '8'-coordinate[1];
            if (row > 7 || row < 0 || col > 7 || col < 0) return null;
            return _squares[row, col];
        }
    }
     public void SetStartPosition()
    {
        Array.Clear(_squares, 0, _squares.Length);
        _squares[0, 0] = new Rook(PieceColor.Black);
        _squares[0, 1] = new Knight(PieceColor.Black);
        _squares[0, 2] = new Bishop(PieceColor.Black);
        _squares[0, 3] = new Queen(PieceColor.Black);
        _squares[0, 4] = new King(PieceColor.Black);
        _squares[0, 5] = new Bishop(PieceColor.Black);
        _squares[0, 6] = new Knight(PieceColor.Black);
        _squares[0, 7] = new Rook(PieceColor.Black);


        for (int col = 0; col < 8; col++)
        {
            _squares[1, col] = new Pawn(PieceColor.Black);
            _squares[6, col] = new Pawn(PieceColor.White);
        }
        _squares[7, 0] = new Rook(PieceColor.White);
        _squares[7, 1] = new Knight(PieceColor.White);
        _squares[7, 2] = new Bishop(PieceColor.White);
        _squares[7, 3] = new Queen(PieceColor.White);
        _squares[7, 4] = new King(PieceColor.White);
        _squares[7, 5] = new Bishop(PieceColor.White);
        _squares[7, 6] = new Knight(PieceColor.White);
        _squares[7, 7] = new Rook(PieceColor.White);
    }
}
