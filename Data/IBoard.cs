using System.Numerics;


namespace Data
{
    public abstract class IBoard
    {
        public static IBoard CreateBoard(int Width, int Height)
        {
            return new Board(Width, Height);
        }

        public abstract int Width { get; protected set; }
        public abstract int Height { get; protected set; }

    }
}
