using Data;

namespace DataTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            IBoard board = IBoard.CreateBoard(100, 100);
            Assert.AreEqual(board.Height, 100);
            Assert.AreEqual(board.Width, 100);
        }

        /*[TestMethod]
        public void TestGenerateBalls()
        {
            IBoard board = IBoard.CreateBoard(100, 100);
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
            IBoard board = IBoard.CreateBoard(100, 100);
            IBall ball = IBall.CreateBall(0, new System.Numerics.Vector2(1, 1), 3, 1, new System.Numerics.Vector2(1, 1));
            board.addBall(ball);
            Assert.AreEqual(board.GetBall(0).Radius, 3.0);
        }*/
    }
}
