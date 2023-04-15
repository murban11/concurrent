using DataAPI;

using System.Numerics;

namespace LogicAPI
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

        public void changeDirection(Ball ball,Board board, Vector2 maxVelocity)
        {
            Random rand = new();
            Ball testBall = ball;
            Vector2 position;
            do
            {
                position = new((float)(rand.NextDouble() * maxVelocity.X), (float)(rand.NextDouble() * maxVelocity.Y));
                testBall.changeSpeedVector(position);
                testBall.UpdatePosition();

            }
            while(checkNextMove(testBall, board) == false);
            ball.changeSpeedVector(position);
        }

        public void updateAllPostions(Board board)
        {
            for (int i = 0; i < board.getBallNumber(); i++)
            {
                while(checkNextMove(board.GetBall(i), board) == false)
                {
                    changeDirection(board.GetBall(i), board, board.GetBall(i).SpeedVector);
                }
                board.GetBall(i).UpdatePosition();
            }
        }
    }
}