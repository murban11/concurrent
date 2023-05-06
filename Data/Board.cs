using System.Numerics;

namespace Data
{
    internal class Board : IBoard
    {
        
        public override int Width { get; set; }
        public override int Height { get; set; }
        public override int BallNumber { get; set; }
        private List<IBall> Balls { get; }

        public Board(int Width, int Height) {
            this.Width = Width;
            this.Height = Height;
            Balls = new List<IBall>();
        }

        private IBall createBall(int id, double radius, double weight, Vector2 maxVelocity)
        {
            Random rand = new();
            Vector2 initialPosition = new((float)(rand.NextDouble() * (Width - 2 * radius) + 10.1F), (float)(rand.NextDouble() * (Height - 2 * radius) + 10.1F));
            Vector2 initialSpeed = new((float)(rand.NextDouble() * maxVelocity.X), (float)(rand.NextDouble() * maxVelocity.Y));

            return new Ball(id, initialPosition, radius, weight, initialSpeed);
        }

        public override void generateBalls(int numberOfBalls, double radius, double weight, Vector2 maxVelocity)
        {
            BallNumber = numberOfBalls;
            for (int i = 0; i < numberOfBalls; i++)
            {
                Balls.Add(createBall(i, radius, weight, maxVelocity));
            }
        }

        public override int getBallNumber()
        {
            return BallNumber;
        }

        public override void addBall (IBall ball)
        {
            Balls.Add(ball);
        }

        public override IBall GetBall(int id)
        {
            return Balls[id];
        }
    }
}
