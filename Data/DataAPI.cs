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
        /*public override void GenerateBalls(int numberOfBalls, double radius, double weight, Vector2 direction)
        {
            Board.generateBalls(numberOfBalls, radius, weight, direction);
        }

        public override Vector2 GetBallCoordinates(int ballID)
        {
            return Board.GetBall(ballID).Coordinates;
        }

        public override double GetBallRadius(int ballID)
        {
            return Board.GetBall(ballID).Radius;
        }

        public override Vector2 GetBallDirectionVector(int ballID)
        {
            return Board.GetBall(ballID).DirectionVector;
        }

        public override double GetBallWeight(int ballID)
        {
            return Board.GetBall(ballID).Weight;
        }*/

        public override int GetBoardHeight()
        {
            return Board.Height;
        }

        public override int GetBoardWidth()
        {
            return Board.Width;
        }
        /*public override int GetBallNumber()
        {
            return Board.getBallNumber();
        }

        public override void SetBallDirectionVector(int ballID, Vector2 direction)
        {
            Board.GetBall(ballID).DirectionVector = direction;
        }*/

        public override IBoard GetBoard()
        {
            return Board;
        }
    }

}
