using Data;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));
            Assert.IsInstanceOfType(ball, typeof(IBall));
            Assert.IsNotNull(ball);
        }

        [TestMethod]
        public void TestCoordinates()
        {
            IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));
            Assert.IsInstanceOfType(ball.Coordinates, typeof(Vector2));
            Assert.IsNotNull(ball.Coordinates);
        }

        [TestMethod]
        public void TestGetID()
        {
            IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));
            Assert.IsInstanceOfType(ball.ID, typeof(int));
            Assert.IsNotNull(ball.ID);
            Assert.AreEqual(ball.ID, 0);
        }

        [TestMethod]
        public void TestGetRadius()
        {
            IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));
            Assert.IsInstanceOfType(ball.Radius, typeof(double));
            Assert.IsNotNull(ball.Radius);
            Assert.AreEqual(ball.Radius, 5);
        }

        [TestMethod]
        public void TestGetWeight()
        {
            IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));
            Assert.IsInstanceOfType(ball.Weight, typeof(double));
            Assert.IsNotNull(ball.Weight);
            Assert.AreEqual(ball.Weight, 1);
        }

        [TestMethod]
        public void TestUpdatePositionUpdateDirectionVector()
        {
            IBall ball = IBall.CreateBall(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));
            Assert.IsInstanceOfType(ball.DirectionVector, typeof(Vector2));
            Assert.IsNotNull(ball.DirectionVector);
            Assert.AreEqual(ball.DirectionVector, new Vector2(1, 1));
        }
    }
}