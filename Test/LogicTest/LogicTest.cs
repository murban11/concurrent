using Data;
using Logic;
using System.Numerics;

namespace LogicTest
{
    [TestClass]
    public class LogicTest 
    {
        [TestMethod]
        public void TestCheckNextMove()
        {
            BallLogic logic = new BallLogic();
            IBoard board = IBoard.CreateBoard(100, 100);
            IBall ball = IBall.CreateBall(0, new System.Numerics.Vector2(2, 2), 1, 1, new System.Numerics.Vector2(-5, -5));
            IBall ball1 = IBall.CreateBall(0, new System.Numerics.Vector2(2, 2), 1, 1, new System.Numerics.Vector2(5, 5));
            board.addBall(ball);
            ball.UpdatePosition();
            Assert.IsFalse(logic.checkNextMove(ball, board));
            board.addBall(ball1);
            ball1.UpdatePosition();
            Assert.IsTrue(logic.checkNextMove(ball1, board));
        }

        [TestMethod]
        public void TestChangeDirection()
        {
            BallLogic logic = new BallLogic();
            IBoard board = IBoard.CreateBoard(100, 100);
            IBall ball = IBall.CreateBall(0, new System.Numerics.Vector2(2, 2), 1, 1, new System.Numerics.Vector2(-500, 2));
            board.addBall(ball);
            Vector2 startDirection = ball.DirectionVector;
            logic.changeDirection(ball, board);
            Assert.AreNotEqual(startDirection, ball.DirectionVector);

        }

        [TestMethod]
        public void TestUpdateAllPositions()
        {
            BallLogic logic = new BallLogic();
            IBoard board = IBoard.CreateBoard(100, 100);
            Vector2 startPostion = new System.Numerics.Vector2(1, 1);
            IBall ball = IBall.CreateBall(0, new System.Numerics.Vector2(2, 2), 1, 1, startPostion);
            IBall ball1 = IBall.CreateBall(0, new System.Numerics.Vector2(5, 5), 1, 1, startPostion);
            board.addBall(ball);
            board.addBall(ball1);
            logic.updateBallPosition(board, 0);
            Assert.AreNotEqual(board.GetBall(0).Coordinates, startPostion);
            Assert.AreNotEqual(board.GetBall(1).Coordinates, startPostion);
        }
    }
}