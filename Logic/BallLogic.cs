using Data;
using System.Numerics;

namespace Logic
{
    public class BallLogic
    {
        public Boolean checkNextMove(Ball ball, Board board)
        {
            if(ball.Coordinates.X + ball.Radius < board.Width && ball.Coordinates.X - ball.Radius > 0)
            {
                if (ball.Coordinates.Y + ball.Radius < board.Height && ball.Coordinates.Y - ball.Radius > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void changeDirection(Ball ball)
        {
            /*Random rand = new();
            Ball testBall = ball;
            Vector2 position;
            do
            {
                position = new((float)(rand.NextDouble() * maxVelocity.X), (float)(rand.NextDouble() * maxVelocity.Y));
                testBall.changeSpeedVector(position);
                testBall.UpdatePosition();

            }
            while(checkNextMove(testBall, board) == false);
            ball.changeSpeedVector(position);*/
            Vector2 NewSpeedVector = new Vector2();
            NewSpeedVector.X = -1 * ball.SpeedVector.X;
            NewSpeedVector.Y = -1 * ball.SpeedVector.Y;
            ball.changeSpeedVector(NewSpeedVector);
        }

        public void updateAllPostions(Board board)
        {
            for (int i = 0; i < board.getBallNumber(); i++)
            {
                while(checkNextMove(board.GetBall(i), board) == false)
                {
                    changeDirection(board.GetBall(i));
                    if (!(checkVerticalCollision(board.GetBall(i).Coordinates, board.GetBall(i).SpeedVector, board.GetBall(i).Radius, board.Width)
                        & checkHorizontalCollision(board.GetBall(i).Coordinates, board.GetBall(i).SpeedVector, board.GetBall(i).Radius, board.Height)))
                    {
                        break;
                    }

                }
                board.GetBall(i).UpdatePosition();
            }
        }

        public bool checkVerticalCollision(Vector2 ballPosition, Vector2 ballVelocity, double ballRadius, double boardWidth)
        {
            Vector2 nextPosition = ballPosition + ballVelocity;

            return nextPosition.X - ballRadius <= 0 || nextPosition.X + ballRadius >= boardWidth;
        }

        public bool checkHorizontalCollision(Vector2 ballPosition, Vector2 ballVelocity, double ballRadius, double boardHeight)
        {
            Vector2 nextPosition = ballPosition + ballVelocity;

            return nextPosition.Y - ballRadius <= 0 || nextPosition.Y + ballRadius >= boardHeight;
        }

    }
}