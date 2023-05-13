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
            Vector2 NewDirectionVector = ball.DirectionVector;
            if (checkVerticalCollision(ball.Coordinates, ball.DirectionVector, ball.Radius, board.Width))
            {
                NewDirectionVector.X = -1 * ball.DirectionVector.X;
            }
            if (checkHorizontalCollision(ball.Coordinates, ball.DirectionVector, ball.Radius, board.Height))
            {
                NewDirectionVector.Y = -1 * ball.DirectionVector.Y;
            }
            ball.changeDirectionVector(NewDirectionVector);
        }

        public void updateBallPosition(IBoard board, int index)
        {
            /*while(checkNextMove(board.GetBall(index), board) == false)
            {
                changeDirection(board.GetBall(index), board);
                if (!(checkVerticalCollision(board.GetBall(index).Coordinates, board.GetBall(index).DirectionVector, board.GetBall(index).Radius, board.Width)
                    & checkHorizontalCollision(board.GetBall(index).Coordinates, board.GetBall(index).DirectionVector, board.GetBall(index).Radius, board.Height)))
                {
                    break;
                }

            }*/
            ///board.GetBall(index).UpdatePosition();
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