using Data;
using System.Numerics;

namespace Logic
{
    internal class LogicAPI : AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;
        private BallLogic logic;
        private List<IBall> balls;
        private IObserver<int> observer = null;

        public LogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
        }

        public override void Start(int ballsNumber)
        {
            balls = new List<IBall>();
            for(int i = 0; i < ballsNumber; i++)
            {
                Random rand = new();
                Vector2 initialPosition = new((float)(rand.NextDouble() * (dataAPI.GetBoardWidth() - 2 * 10) + 10.1F),
                    (float)(rand.NextDouble() * (dataAPI.GetBoardWidth() - 2 * 10) + 10.1F));
                Vector2 initialDirection = new((float)(rand.NextDouble() * 2), (float)(rand.NextDouble() * 2));
                IBall ball = IBall.CreateBall(i, initialPosition, 10, 1, initialDirection);
                ball.Subscribe(this);
                balls.Add(ball);
            }
            logic = new BallLogic();
        }
        public override Vector2 GetBallCoordinates(int id)
        {
            return balls[id].Coordinates;
        }
        public override Vector2 GetBallDirectionVector(int id)
        {
            return balls[id].DirectionVector;
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
            return balls[id].Radius;
        }

        public override int GetBallNumber()
        {
            return balls.Count();
        }

        public override List<IBall> GetBalls()
        {
            return balls;
        }

        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(IBall ball)
        {
            int ballCount = balls.Count();
            //int index = -1;

            for(int i = 0; i < ballCount; i++)
            {
                IBall other = balls[i];

                /*if (ball == other)
                {
                    index = i;
                    continue;
                }*/

                logic.changeDirection(ball, dataAPI.GetBoard());
            }

            //observer.OnNext(index);
        }

        public override IDisposable Subscribe(IObserver<int> observer)
        {
            this.observer = observer;
            return new Unsubscriber(this.observer);
        }

        private class Unsubscriber : IDisposable
        {
            private IObserver<int> _observer;

            public Unsubscriber(IObserver<int> observer)
            {
                _observer = observer;
            }

            public void Dispose()
            {
                _observer = null;
            }
        }
    }
}
