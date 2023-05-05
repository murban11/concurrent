
namespace Model
{
    public abstract class IBallModel
    {
        public abstract double X { get; set; }

        public abstract double Y { get; set; }

        public abstract double Diameter { get; set; }

        public abstract void Move(double x, double y);

        public static IBallModel BallModel(double x, double y, double radius)
        {
            return new BallModel(x, y, radius);
        }
    }
}
