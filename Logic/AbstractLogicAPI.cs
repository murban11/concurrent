using Data;
using System.Numerics;

namespace Logic
{
    public abstract class AbstractLogicAPI : IObserver<IBall>, IObservable<int>
    {
        public abstract void Start(int ballsNumber);

        public abstract Vector2 GetBallCoordinates(int id);

        public abstract Vector2 GetBallDirectionVector(int id);

        public abstract int GetBoxWidth();

        public abstract int GetBoxHeight();

        public abstract double GetBallRadius(int id);

        public abstract int GetBallNumber();

        public abstract List<IBall> GetBalls();

        public static AbstractLogicAPI CreateLogicAPI(AbstractDataAPI dataAPI)
        {
            if (dataAPI == null)
            {
                return new LogicAPI(AbstractDataAPI.CreateDataAPI());
            }
            else
            {
                return new LogicAPI(dataAPI);
            }
        }

        public abstract void OnCompleted();

        public abstract void OnError(Exception error);

        public abstract void OnNext(IBall value);

        public abstract IDisposable Subscribe(IObserver<int> observer);
    }
}
