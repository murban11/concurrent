using LogicAPI;

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

        }

        [TestMethod]
        public void TestGetBallDirection()
        {

        }

        [TestMethod]
        public void TestGetBoxWidth()
        {

        }

        [TestMethod]
        public void TestGetBoardHeight()
        {

        }
    }
}
