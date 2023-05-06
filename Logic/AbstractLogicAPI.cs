using Data;
using System.Numerics;

namespace Logic
{
    public abstract class AbstractLogicAPI
    {
        public abstract void Start(int ballsNumber);

        public abstract Vector2 GetBallCoordinates(int id);

        public abstract Vector2 GetBallDirectionVector(int id);

        public abstract int GetBoxWidth();

        public abstract int GetBoxHeight();

        public abstract double GetBallRadius(int id);

        public abstract int GetBallNumber();

        public abstract void Move(int index);

        public abstract List<IBall> GetBalls();

        public static AbstractLogicAPI CreateLogicAPI(AbstractDataAPI dataAPI = default)
        {
            return new LogicAPI(dataAPI ?? AbstractDataAPI.CreateDataAPI());
        }
    }
}
