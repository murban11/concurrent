using System.ComponentModel;
using System.Numerics;

namespace Data
{
    public class Ball
    {
        public int ID {  get; }
        public Vector2 Coordinates { get; private set; }        // (x, y) convention
        public double Radius { get; private set; }
        public double Weight { get; private set; }
        public Vector2 SpeedVector { get; set; }                // (x, y) convention


        public Ball(int ID, Vector2 Coordinates, double Radius, double Weight, Vector2 SpeedVector) {
            this.ID = ID;
            this.Coordinates = Coordinates;
            this.Radius = Radius;
            this.Weight = Weight;
            this.SpeedVector = SpeedVector;
        }

        public void UpdatePosition()
        {
            Coordinates = Vector2.Add(Coordinates, SpeedVector);
        }
    }
}