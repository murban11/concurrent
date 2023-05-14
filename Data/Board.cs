
namespace Data
{
    internal class Board : IBoard
    {
        
        public override int Width { get; set; }
        public override int Height { get; set; }

        public Board(int Width, int Height) {
            this.Width = Width;
            this.Height = Height;
        }

    }
}
