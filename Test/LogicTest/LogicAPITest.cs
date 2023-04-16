using Data;
using Logic;
using System.Numerics;

namespace LogicAPITest
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void TestCreateLogicAPI()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            Assert.IsInstanceOfType(LogicAPI, typeof(AbstractLogicAPI));
        }

        [TestMethod]
        public void TestGetBallCoordinates()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            for (int i = 0; i < 3; i++)
            {
                var testCoordinates = LogicAPI.GetBallCoordinates(i);
                Assert.IsInstanceOfType(testCoordinates, typeof(Vector2));
                Assert.IsNotNull(testCoordinates);
            }
        }

        [TestMethod]
        public void TestGetBallDirection()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            for (int i = 0; i < 3; i++)
            {
                var testCoordinates = LogicAPI.GetBallDirection(i);
                Assert.IsInstanceOfType(testCoordinates, typeof(Vector2));
                Assert.IsNotNull(testCoordinates);
            }
        }

        [TestMethod]
        public void TestGetBallRadius()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            for (int i = 0; i < 3; i++)
            {
                var testCoordinates = LogicAPI.GetBallRadius(i);
                Assert.IsInstanceOfType(testCoordinates, typeof(double));
                Assert.IsNotNull(testCoordinates);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(1);
            Vector2 start = LogicAPI.GetBallDirection(0);
            Vector2 target = LogicAPI.GetBallCoordinates(0) + LogicAPI.GetBallDirection(0);
            LogicAPI.Move();
            Assert.AreNotEqual(start, LogicAPI.GetBallCoordinates(0));
            Assert.AreEqual(target, LogicAPI.GetBallCoordinates(0));
        }

        [TestMethod]
        public void TestGetBallNumber()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            var testCoordinates = LogicAPI.GetBallNumber();
            Assert.IsInstanceOfType(testCoordinates, typeof(int));
            Assert.IsNotNull(testCoordinates); Assert.IsNotNull(testCoordinates);
        }

        [TestMethod]
        public void TestGetBoxWidth()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            var testCoordinates = LogicAPI.GetBoxWidth();
            Assert.IsInstanceOfType(testCoordinates, typeof(int));
            Assert.IsNotNull(testCoordinates);
        }

        [TestMethod]
        public void TestGetBoardHeight()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            var testCoordinates = LogicAPI.GetBoxHeight();
            Assert.IsInstanceOfType(testCoordinates, typeof(int));
            Assert.IsNotNull(testCoordinates);
        }

        [TestMethod]
        public void TestGetBalls()
        {
            var LogicAPI = AbstractLogicAPI.CreateLogicAPI();
            LogicAPI.Start(3);
            var testCoordinates = LogicAPI.GetBalls();
            Assert.IsInstanceOfType(testCoordinates, typeof(List<Ball>));
            Assert.IsNotNull(testCoordinates);
        }
    }
}
