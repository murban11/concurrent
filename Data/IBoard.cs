using System.Numerics;


namespace Data
{
    public abstract class IBoard
    {
        public static IBoard CreateBoard(int Width, int Height)
        {
            return new Board(Width, Height);
        }

        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract int BallNumber { get; set; }

        private readonly List<IBall> balls;

        public abstract void generateBalls(int numberOfBalls, double radius, double weight, Vector2 maxVelocity);

        public abstract int getBallNumber();

        public abstract void addBall(IBall ball);

        public abstract IBall GetBall(int id);
    }
}
