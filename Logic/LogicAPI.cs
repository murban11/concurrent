using Data;
using System.Numerics;

namespace Logic
{
    public abstract class AbstractLogicAPI
    {
        public abstract void Start(int ballsNumber);
        public abstract Vector2 GetBallCoordinates(int id);
        public abstract Vector2 GetBallDirection(int id);
        public abstract int GetBoxWidth();
        public abstract int GetBoxHeight();
        public abstract double GetBallRadius(int id);

        public abstract int GetBallNumber();

        public abstract void Move();

        public abstract List<Ball> GetBalls();

        public static AbstractLogicAPI CreateLogicAPI(AbstractDataAPI dataAPI = default)
        {
            return new LogicAPI(dataAPI ?? AbstractDataAPI.CreateDataAPI());
        }

        private class LogicAPI : AbstractLogicAPI
        {
            private readonly AbstractDataAPI dataAPI;
            private BallLogic logic;

            public LogicAPI(AbstractDataAPI dataAPI)
            {
                this.dataAPI = dataAPI;
            }

            public override void Start(int ballsNumber)
            {
                dataAPI.GenerateBalls(ballsNumber, 10, 1, new Vector2(3, 3));
                logic = new BallLogic();
            }

            public override Vector2 GetBallCoordinates(int id)
            {
                return dataAPI.GetBallCoordinates(id);
            }

            public override Vector2 GetBallDirection(int id)
            {
                return dataAPI.GetBallSpeedVector(id);
            }

            public override int GetBoxWidth()
            {
                return dataAPI.GetBoardWidth();
            }

            public override int GetBoxHeight()
            {
                return dataAPI.GetBoardHeight();
            }

            public override double GetBallRadius(int id)
            {
                return dataAPI.GetBallRadius(id);
            }

            public override int GetBallNumber()
            {
                return dataAPI.GetBallNumber();
            }

            public override void Move()
            {
                logic.updateAllPostions(dataAPI.GetBoard());
            }

            public override List<Ball> GetBalls()
            {
                List<Ball> list = new List<Ball>();
                for (int i = 0; i < GetBallNumber(); i++)
                {
                    list.Add(dataAPI.GetBoard().GetBall(i));
                }
                return list;
            }
        }
    }
}
