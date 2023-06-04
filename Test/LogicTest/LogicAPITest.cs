using Data;
using Logic;
using System.Numerics;

namespace LogicAPITest
{
    internal class TestDataAPI : AbstractDataAPI
    {
        public override void appendToLoggingQueue(IBall ball)
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override IBoard GetBoard()
        {
            return null;
        }

        public override int GetBoardHeight()
        {
            return 100;
        }

        public override int GetBoardWidth()
        {
            return 100;
        }

        
    }

    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void TestCreateLogicAPI()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            Assert.IsInstanceOfType(LogicAPI, typeof(AbstractLogicAPI));
        }

        [TestMethod]
        public void TestGetBoxWidth()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            LogicAPI.Start(3);
            int testWidth = LogicAPI.GetBoxWidth();
            Assert.IsInstanceOfType(testWidth, typeof(int));
            Assert.IsNotNull(testWidth);
            Assert.AreEqual(testWidth, 100);
        }

        [TestMethod]
        public void TestGetBoardHeight()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            LogicAPI.Start(3);
            int testHeight = LogicAPI.GetBoxHeight();
            Assert.IsInstanceOfType(testHeight, typeof(int));
            Assert.IsNotNull(testHeight);
            Assert.AreEqual(testHeight, 100);
        }

        [TestMethod]
        public void TestGetBallRadius()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            LogicAPI.Start(1);
            Assert.IsInstanceOfType(LogicAPI.GetBallRadius(0), typeof(double));
            Assert.AreEqual(LogicAPI.GetBallRadius(0), 10);
        }

        [TestMethod]
        public void TestGetBallNumber()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            LogicAPI.Start(3);
            Assert.IsInstanceOfType(LogicAPI.GetBallNumber(), typeof(int));
            Assert.AreEqual(LogicAPI.GetBallNumber(), 3);
        }

        [TestMethod]
        public void TestGetBallCoordinates()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            LogicAPI.Start(1);
            Assert.IsInstanceOfType(LogicAPI.GetBallCoordinates(0), typeof(Vector2));
            Assert.IsNotNull(LogicAPI.GetBallCoordinates(0));
        }

        [TestMethod]
        public void TestGetBallDirectionVector()
        {
            AbstractLogicAPI LogicAPI = AbstractLogicAPI.CreateLogicAPI(new TestDataAPI());
            LogicAPI.Start(1);
            Assert.IsInstanceOfType(LogicAPI.GetBallDirectionVector(0), typeof(Vector2));
            Assert.IsNotNull(LogicAPI.GetBallCoordinates(0));
        }
    }
}
