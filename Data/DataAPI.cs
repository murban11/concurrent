using System.Numerics;

namespace Data
{
    internal class DataAPI : AbstractDataAPI
    {
        private readonly IBoard Board;

        public DataAPI()
        {
            Board = new Board(414, 630);
        }
        public override void GenerateBalls(int numberOfBalls, double radius, double weight, Vector2 maxSpeed)
        {
            Board.generateBalls(numberOfBalls, radius, weight, maxSpeed);
        }

        public override Vector2 GetBallCoordinates(int ballID)
        {
            return Board.GetBall(ballID).Coordinates;
        }

        public override double GetBallRadius(int ballID)
        {
            return Board.GetBall(ballID).Radius;
        }

        public override Vector2 GetBallSpeedVector(int ballID)
        {
            return Board.GetBall(ballID).SpeedVector;
        }

        public override double GetBallWeight(int ballID)
        {
            return Board.GetBall(ballID).Weight;
        }

        public override int GetBoardHeight()
        {
            return Board.Height;
        }

        public override int GetBoardWidth()
        {
            return Board.Width;
        }
        public override int GetBallNumber()
        {
            return Board.getBallNumber();
        }

        public override void SetBallSpeedVector(int ballID, Vector2 speed)
        {
            Board.GetBall(ballID).SpeedVector = speed;
        }

        public override void UpdateBallPosition(int ballID)
        {
            Board.GetBall(ballID).UpdatePosition();
        }

        public override IBoard GetBoard()
        {
            return Board;
        }
    }

}
