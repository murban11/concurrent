using DataAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Board board = new Board(100, 100);
            Assert.AreEqual(board.Height, 100);
            Assert.AreEqual(board.Width, 100);
        }

        [TestMethod]
        public void TestGenerateBalls()
        {
            Board board = new Board(100, 100);
            board.generateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            Assert.AreEqual(board.GetBall(0).Radius, 5.0);
        }

        [TestMethod]
        public void TestGetBallNumber()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            Assert.AreEqual(api.GetBallNumber(), 3);
        }

        [TestMethod]
        public void TestAddBall()
        {
            Board board = new Board(100, 100);
            Ball ball = new Ball(0, new System.Numerics.Vector2(1, 1), 3, 1, new System.Numerics.Vector2(1, 1));
            board.addBall(ball);
            Assert.AreEqual(board.GetBall(0).Radius, 3.0);
        }
    }
}
