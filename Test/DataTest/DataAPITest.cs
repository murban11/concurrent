using Data;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        [TestMethod]
        public void TestConstructor()
        {
            AbstractDataAPI API = AbstractDataAPI.CreateDataAPI();
            Assert.IsNotNull(API);
            Assert.IsInstanceOfType(API, typeof(AbstractDataAPI));
        }

        [TestMethod]
        public void TestGetBoard() 
        {
            AbstractDataAPI API = AbstractDataAPI.CreateDataAPI();
            Assert.IsNotNull(API.GetBoard());
            Assert.IsInstanceOfType(API.GetBoard(), typeof(IBoard));
            Assert.IsNotNull(API.GetBoard().Height);
            Assert.IsNotNull(API.GetBoard().Width);
        }

        [TestMethod]
        public void TestGetBoardHeight()
        {
            AbstractDataAPI API = AbstractDataAPI.CreateDataAPI();
            Assert.IsNotNull(API.GetBoardHeight());
            Assert.IsInstanceOfType(API.GetBoardHeight(), typeof(int));
            Assert.AreEqual(API.GetBoard().Height, API.GetBoardHeight());
        }

        [TestMethod]
        public void TestGetBoardWidth()
        {
            AbstractDataAPI API = AbstractDataAPI.CreateDataAPI();
            Assert.IsNotNull(API.GetBoardWidth());
            Assert.IsInstanceOfType(API.GetBoardWidth(), typeof(int));
            Assert.AreEqual(API.GetBoard().Width, API.GetBoardWidth());
        }

    }
}
