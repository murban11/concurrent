using Data;
using System.Numerics;

namespace Logic
{
    internal class LogicAPI : AbstractLogicAPI
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

        public override List<IBall> GetBalls()
        {
            List<IBall> list = new List<IBall>();
            for (int i = 0; i < GetBallNumber(); i++)
            {
                list.Add(dataAPI.GetBoard().GetBall(i));
            }
            return list;
        }
    }
}
