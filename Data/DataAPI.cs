using System.Numerics;

namespace Data
{
    internal class DataAPI : AbstractDataAPI
    {
        private readonly IBoard Board;

        public DataAPI()
        {
            Board = new Board(414, 630);
        }

        public override int GetBoardHeight()
        {
            return Board.Height;
        }

        public override int GetBoardWidth()
        {
            return Board.Width;
        }

        public override IBoard GetBoard()
        {
            return Board;
        }
    }

}
