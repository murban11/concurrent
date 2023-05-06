using System.Numerics;

namespace Data
{
    public abstract class AbstractDataAPI
    {
        public abstract Vector2 GetBallCoordinates(int ballID);

        public abstract Vector2 GetBallDirectionVector(int ballID);

        public abstract double GetBallWeight(int ballID);

        public abstract double GetBallRadius(int ballID);

        public abstract void SetBallDirectionVector(int ballID, Vector2 direction);

        public abstract void UpdateBallPosition(int ballID);

        public abstract int GetBoardWidth();

        public abstract int GetBoardHeight();

        public abstract int GetBallNumber();

        public abstract IBoard GetBoard();

        public abstract void GenerateBalls(int numberOfBalls, double radius, double weight, Vector2 direction);

        public static AbstractDataAPI CreateDataAPI()
        {
            return new DataAPI();
        }
    }
}
