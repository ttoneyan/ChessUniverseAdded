using Chessuniverse.Library;

namespace Chessuniverse.Library;

public abstract class Piece(PieceColor color, PieceType type)
{
    public PieceColor Color { get; set; } = color;
    public PieceType Type { get; set; } = type;

    public abstract char GetSymbol();
}

