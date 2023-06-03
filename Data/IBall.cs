using System;
using System.Numerics;

namespace Data
{
    public abstract class IBall: IObservable<IBall>
    {
        public static IBall CreateBall(int ID, Vector2 Coordinates, double Radius, double Weight, Vector2 DirectionVector)
        {
            return new Ball(ID, Coordinates, Radius, Weight, DirectionVector);
        }

        public abstract int ID { get; }
        public abstract Vector2 Coordinates { get; protected set; } 
        public abstract double Radius { get; protected set; }
        public abstract double Weight { get; protected set; }
        public abstract bool IsRunning { get; set; }
        public abstract Vector2 DirectionVector { get; set; }
        public abstract void changeDirectionVector(Vector2 data);
        public abstract IDisposable Subscribe(IObserver<IBall> observer);

        
    }
}
