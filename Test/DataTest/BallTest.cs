using Data;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));

        [TestMethod]
        public void TestGetID()
        {
            Assert.AreEqual(ball.ID, 0);
        }

        [TestMethod]
        public void TestGetRadius()
        {
            Assert.AreEqual(ball.Radius, 5);
        }

        [TestMethod]
        public void TestGetWeight()
        {
            Assert.AreEqual(ball.Weight, 1);
        }

        [TestMethod]
        public void TestUpdatePositionUpdateDirectionVector()
        {
            Assert.AreEqual(ball.DirectionVector, new Vector2(1, 1));
        }
    }
}