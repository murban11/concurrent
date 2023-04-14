using Data;
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
    }
}
