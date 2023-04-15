using DataAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicAPI
{
    public abstract class AbstractLogicAPI
    {
        public abstract void Run(int ballsNumber);
        public abstract Vector2 GetBallCoordinates(int id);
        public abstract Vector2 GetBallDirection(int id);
        public abstract int GetBoxWidth();
        public abstract int GetBoxHeight();

        public static AbstractLogicAPI CreateLogicAPI(AbstractDataAPI dataAPI = default)
        {
            return new LogicAPI(dataAPI ?? AbstractDataAPI.CreateDataAPI());
        }

        private class LogicAPI : AbstractLogicAPI
        {
            private readonly AbstractDataAPI dataAPI;

            public LogicAPI(AbstractDataAPI dataAPI)
            {
                this.dataAPI = dataAPI;
            }

            public override void Run(int ballsNumber)
            {
                dataAPI.GenerateBalls(ballsNumber, 1, 1, new Vector2(2, 2));
                BallLogic logic = new BallLogic();
                while (true)
                {
                    logic.updateAllPostions(dataAPI.GetBoard());
                }
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
        }
    }
}
