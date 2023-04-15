using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI
{
    public abstract class AbstractDataAPI
    {
        public abstract Vector2 GetBallCoordinates(int ballID);

        public abstract Vector2 GetBallSpeedVector(int ballID);

        public abstract double GetBallWeight(int ballID);

        public abstract double GetBallRadius(int ballID);

        public abstract void SetBallSpeedVector(int ballID, Vector2 speed);

        public abstract void UpdateBallPosition(int ballID);

        public abstract int GetBoardWidth();

        public abstract int GetBoardHeight();
        public abstract int GetBallNumber();
        public abstract Board GetBoard();

        public abstract void GenerateBalls(int numberOfBalls, double radius, double weight, Vector2 maxSpeed);

        public static AbstractDataAPI CreateDataAPI()
        {
            return new DataAPI();
        }

        private class DataAPI : AbstractDataAPI
        {
            private readonly Board Board;

            public DataAPI()
            {
                Board = new Board(630, 414);
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

            public override Board GetBoard()
            {
                return Board;
            }
        }


    }
}
