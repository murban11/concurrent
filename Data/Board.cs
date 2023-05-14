
namespace Data
{
    internal class Board : IBoard
    {
        
        public override int Width { get; protected set; }
        public override int Height { get; protected set; }

        public Board(int Width, int Height) {
            this.Width = Width;
            this.Height = Height;
        }

    }
}
