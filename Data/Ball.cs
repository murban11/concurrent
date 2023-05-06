using System.Numerics;

namespace Data
{
    internal class Ball: IBall
    {
        public override int ID {  get; }
        public override Vector2 Coordinates { get; set; }        // (x, y) convention
        public override double Radius { get; set; }
        public override double Weight { get; set; }
        public override Vector2 DirectionVector { get; set; }                // (x, y) convention (for example in m)


        public Ball(int ID, Vector2 Coordinates, double Radius, double Weight, Vector2 DirectionVector) {
            this.ID = ID;
            this.Coordinates = Coordinates;
            this.Radius = Radius;
            this.Weight = Weight;
            this.DirectionVector = DirectionVector;
        }

        public override void UpdatePosition()
        {
            Coordinates = Vector2.Add(Coordinates, DirectionVector);
        }
        public override void changeDirectionVector(Vector2 data)
        {
            DirectionVector = data;
        }
    }
}