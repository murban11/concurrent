using Data;
using System.Numerics;

namespace Logic
{
    public class BallLogic
    {
        public Boolean checkNextMove(IBall ball, IBoard board)
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

        public void changeDirection(IBall ball, IBoard board)
        {
            Vector2 NewSpeedVector = ball.SpeedVector;
            if (checkVerticalCollision(ball.Coordinates, ball.SpeedVector, ball.Radius, board.Width))
            {
                NewSpeedVector.X = -1 * ball.SpeedVector.X;
            }
            if (checkHorizontalCollision(ball.Coordinates, ball.SpeedVector, ball.Radius, board.Height))
            {
                NewSpeedVector.Y = -1 * ball.SpeedVector.Y;
            }
            ball.changeSpeedVector(NewSpeedVector);
        }

        public void updateAllPostions(IBoard board)
        {
            for (int i = 0; i < board.getBallNumber(); i++)
            {
                while(checkNextMove(board.GetBall(i), board) == false)
                {
                    changeDirection(board.GetBall(i), board);
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