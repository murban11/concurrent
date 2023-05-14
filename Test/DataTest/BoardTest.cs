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
            Assert.IsInstanceOfType(board, typeof(IBoard));

        }

        [TestMethod]
        public void TestBoardWidth()
        {
            IBoard board = IBoard.CreateBoard(100, 100);
            Assert.IsNotNull(board.Width);
            Assert.IsInstanceOfType(board.Width, typeof(int));
            Assert.AreEqual(board.Width, 100);
        }

        [TestMethod]
        public void TestBoardHeight()
        {
            IBoard board = IBoard.CreateBoard(100, 100);
            Assert.IsNotNull(board.Height);
            Assert.IsInstanceOfType(board.Height, typeof(int));
            Assert.AreEqual(board.Height, 100);
        }

    }
}
