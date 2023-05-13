using Data;
using Logic;
using System.Numerics;

namespace LogicAPITest
{

    internal class TestDataAPI : AbstractDataAPI
    {
        private IBoard board = IBoard.CreateBoard(100, 100); 

        public override IBoard GetBoard()
        {
            return board;
        }

        public override int GetBoardHeight()
        {
            return board.Height;
        }

        public override int GetBoardWidth()
        {
            return board.Width;
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
    }
}
