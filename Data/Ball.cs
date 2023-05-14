using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball: IBall
    {
        public override int ID {  get; }
        public override Vector2 Coordinates { get; protected set; }        // (x, y) convention
        public override double Radius { get; protected set; }
        public override double Weight { get; protected set; }
        public override Vector2 DirectionVector { get; set; }                // (x, y) convention (for example in m)

        private List<IObserver<Ball>> observers;

        public Ball(int ID, Vector2 Coordinates, double Radius, double Weight, Vector2 DirectionVector) {
            this.ID = ID;
            this.Coordinates = Coordinates;
            this.Radius = Radius;
            this.Weight = Weight;
            this.DirectionVector = DirectionVector;
            observers = new List<IObserver<Ball>>();
            UpdatePosition();
        }

        private async void UpdatePosition()
        {
            while (true)
            {
                Vector2 movement = new((float)(DirectionVector.X / Weight), (float)(DirectionVector.Y / Weight));
                Coordinates = Vector2.Add(Coordinates, movement);
                foreach (IObserver<Ball> observer in observers)
                {
                    observer.OnNext(this);
                }
                await Task.Delay(10);
            }
        }
        public override void changeDirectionVector(Vector2 data)
        {
            DirectionVector = data;
        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Ball>> _observers;
            private IObserver<Ball> _observer;

            public Unsubscriber(List<IObserver<Ball>> observers, IObserver<Ball> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}