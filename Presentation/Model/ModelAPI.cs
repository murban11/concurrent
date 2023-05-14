using Data;
using Logic;
using System.Numerics;

namespace Model
{

    internal class ModelAPI : AbstractModelAPI
    {
        private AbstractLogicAPI logicAPI;
        public List<Task> tasks { get; set; } = new List<Task>();
        private readonly IDisposable unsubscriber;
        private IObserver<IBallModel> observer;

        private class Unsubscriber : IDisposable
        {
            private IObserver<IBallModel> _observer;

            public Unsubscriber(IObserver<IBallModel> observer)
            {
                _observer = observer;
            }

            public void Dispose()
            {
                _observer = null;
            }
        }

        public ModelAPI(AbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI;
            Balls = new List<IBallModel> ();
            unsubscriber = logicAPI.Subscribe(this);
        }


        public override void Start(int numberOfBalls)
        {
            logicAPI.Start(numberOfBalls);
            for (int i = 0; i < numberOfBalls; i++)
            {
                Balls.Add(new BallModel(logicAPI.GetBallCoordinates(i).X, logicAPI.GetBallCoordinates(i).Y, logicAPI.GetBallRadius(i)));
            }
        }

        public override IBallModel GetBallModel(int id)
        {
            return Balls[id];
        }

        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(int value)
        {
            IBallModel ball = Balls[value];
            Vector2 position = logicAPI.GetBallCoordinates(value);
            double radius = logicAPI.GetBallRadius(value);
            ball.Move(position.X, position.Y);
        }

        public override IDisposable Subscribe(IObserver<IBallModel> observer)
        {
            this.observer = observer;
            return new Unsubscriber(this.observer);
        }
    }
}

