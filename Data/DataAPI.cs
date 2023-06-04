using System.Numerics;

namespace Data
{
    internal class DataAPI : AbstractDataAPI
    {
        private readonly IBoard Board;
        private Logger logger;

        public DataAPI()
        {
            Board = new Board(414, 630);
            logger = new Logger(414, 630);
            logger.startLogging();
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

        public override void appendToLoggingQueue(IBall ball)
        {
            logger.appendToQueue(ball);
        }

        public override void Exit()
        {
            logger.Exit();
        }

    }

}
