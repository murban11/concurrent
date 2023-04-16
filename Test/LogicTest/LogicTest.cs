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
            Board board = new Board(100, 100);
            Ball ball = new Ball(0, new System.Numerics.Vector2(2, 2), 1, 1, new System.Numerics.Vector2(-5, -5));
            Ball ball1 = new Ball(0, new System.Numerics.Vector2(2, 2), 1, 1, new System.Numerics.Vector2(5, 5));
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
            Board board = new Board(100, 100);
            Ball ball = new Ball(0, new System.Numerics.Vector2(2, 2), 1, 1, new System.Numerics.Vector2(-5, -5));
            board.addBall(ball);
            ball.UpdatePosition();
            if(logic.checkNextMove(ball, board) == false)
            {
                logic.changeDirection(ball, board, new System.Numerics.Vector2(1,1));
            }
            Assert.IsTrue(logic.checkNextMove(ball, board));

        }

        [TestMethod]
        public void TestUpdateAllPositions()
        {
            BallLogic logic = new BallLogic();
            Board board = new Board(100, 100);
            Vector2 startPostion = new System.Numerics.Vector2(1, 1);
            Ball ball = new Ball(0, new System.Numerics.Vector2(2, 2), 1, 1, startPostion);
            Ball ball1 = new Ball(0, new System.Numerics.Vector2(5, 5), 1, 1, startPostion);
            board.addBall(ball);
            board.addBall(ball1);
            logic.updateAllPostions(board);
            Assert.AreNotEqual(board.GetBall(0).Coordinates, startPostion);
            Assert.AreNotEqual(board.GetBall(1).Coordinates, startPostion);
        }
    }
}