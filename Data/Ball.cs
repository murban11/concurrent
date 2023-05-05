using System.Numerics;

namespace Data
{
    internal class Ball: IBall
    {
        public override int ID {  get; }
        public override Vector2 Coordinates { get; set; }        // (x, y) convention
        public override double Radius { get; set; }
        public override double Weight { get; set; }
        public override Vector2 SpeedVector { get; set; }                // (x, y) convention


        public Ball(int ID, Vector2 Coordinates, double Radius, double Weight, Vector2 SpeedVector) {
            this.ID = ID;
            this.Coordinates = Coordinates;
            this.Radius = Radius;
            this.Weight = Weight;
            this.SpeedVector = SpeedVector;
        }

        public override void UpdatePosition()
        {
            Coordinates = Vector2.Add(Coordinates, SpeedVector);
        }
        public override void changeSpeedVector(Vector2 data)
        {
            SpeedVector = data;
        }
    }
}