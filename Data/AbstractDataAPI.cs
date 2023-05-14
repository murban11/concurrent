using System.Numerics;

namespace Data
{
    public abstract class AbstractDataAPI
    {
        public abstract int GetBoardWidth();

        public abstract int GetBoardHeight();

        public abstract IBoard GetBoard();

        public static AbstractDataAPI CreateDataAPI()
        {
            return new DataAPI();
        }
    }
}
