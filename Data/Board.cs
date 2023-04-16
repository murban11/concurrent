using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Board
    {
        
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int BallNumber { get; private set; }

        private readonly List<Ball> balls = new List<Ball>();
        private List<Ball> Balls { get { return balls; } }

        public Board(int Width, int Height) {
            this.Width = Width;
            this.Height = Height;
        }

        private Ball createBall(int id, double radius, double weight, Vector2 maxVelocity)
        {
            Random rand = new();
            Vector2 initialPosition = new((float)(rand.NextDouble() * (Width - radius) + 10.1F), (float)(rand.NextDouble() * (Height - radius) + 10.1F));
            Vector2 initialSpeed = new((float)(rand.NextDouble() * maxVelocity.X), (float)(rand.NextDouble() * maxVelocity.Y));

            return new Ball(id, initialPosition, radius, weight, initialSpeed);
        }

        public void generateBalls(int numberOfBalls, double radius, double weight, Vector2 maxVelocity)
        {
            BallNumber = numberOfBalls;
            for (int i = 0; i < numberOfBalls; i++)
            {
                Balls.Add(createBall(i, radius, weight, maxVelocity));
            }
        }

        public int getBallNumber()
        {
            return BallNumber;
        }

        public void addBall (Ball ball)
        {
            Balls.Add(ball);
        }

        public Ball GetBall(int id)
        {
            return Balls[id];
        }
    }
}
