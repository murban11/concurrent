using DataAPI;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Ball ball = new Ball(0, new Vector2(0, 0), 5, 1, new Vector2(1, 1));

            Assert.AreEqual(ball.ID, 0);
            Assert.AreEqual(ball.Coordinates, new Vector2(0, 0));
            Assert.AreEqual(ball.Radius, 5);
            Assert.AreEqual(ball.Weight, 1);
            Assert.AreEqual(ball.SpeedVector, new Vector2(1, 1));
        }

        [TestMethod]
        public void TestUpdatePosition()
        {
            Ball ball = new Ball(0, new Vector2(0, 0), 5, 1, new Vector2(1, -1));
            ball.UpdatePosition();
            Assert.AreEqual(ball.Coordinates, new Vector2(1, -1));
        }

        [TestMethod]
        public void TestUpdatePositionMultipleTimes()
        {
            Ball ball = new Ball(0, new Vector2(0, 0), 5, 1, new Vector2(1, -1));
            for (int i = 0; i < 5; i++)
            {
                ball.UpdatePosition();
            }
            Assert.AreEqual(ball.Coordinates, new Vector2(5, -5));
        }

        [TestMethod]
        public void TestUpdatePositionUpdateSpeedVector()
        {
            Ball ball = new Ball(0, new Vector2(0, 0), 5, 1, new Vector2(1, -1));
            ball.UpdatePosition();
            ball.SpeedVector = new Vector2(-1, 1);
            ball.UpdatePosition();
            Assert.AreEqual(ball.Coordinates, new Vector2(0, 0));
        }
    }
}