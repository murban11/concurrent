using Data;
using System.Numerics;

namespace Logic
{
    public class BallLogic
    {

        public void checkCollisions(IBall ball, IBoard board, IBall target)
        {
            checkBallCollision(ball, target);
            Vector2 NewDirectionVector = ball.DirectionVector;
            if (checkVerticalCollisionBoard(ball.Coordinates, ball.DirectionVector, ball.Radius, board.Width))
            {
                NewDirectionVector.X = -1 * ball.DirectionVector.X;
            }
            if (checkHorizontalCollisionBoard(ball.Coordinates, ball.DirectionVector, ball.Radius, board.Height))
            {
                NewDirectionVector.Y = -1 * ball.DirectionVector.Y;
            }
            ball.changeDirectionVector(NewDirectionVector);

        }
        public void checkBallCollision(IBall ball, IBall target)
        {
            Vector2 nextPosition = ball.DirectionVector + ball.Coordinates;
            double realDistanceX = (nextPosition - target.Coordinates).Length();
            double maxDistance = ball.Radius + target.Radius;
            if (realDistanceX <= maxDistance)
            {
                Vector2 tmp = ball.DirectionVector;
                ball.changeDirectionVector(target.DirectionVector);
                target.changeDirectionVector(tmp);
            }
        }

        public bool checkVerticalCollisionBoard(Vector2 ballPosition, Vector2 ballVelocity, double ballRadius, double boardWidth)
        {
            Vector2 nextPosition = ballPosition + ballVelocity;

            return nextPosition.X - ballRadius <= 0 || nextPosition.X + ballRadius >= boardWidth;
        }

        public bool checkHorizontalCollisionBoard(Vector2 ballPosition, Vector2 ballVelocity, double ballRadius, double boardHeight)
        {
            Vector2 nextPosition = ballPosition + ballVelocity;

            return nextPosition.Y - ballRadius <= 0 || nextPosition.Y + ballRadius >= boardHeight;
        }

    }
}