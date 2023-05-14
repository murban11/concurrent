using Data;
using Logic;
using System.Numerics;

namespace LogicTest
{
    [TestClass]
    public class LogicTest 
    {
        [TestMethod]
        public void TestCheckVerticalCollision()
        {
            BallLogic logic = new BallLogic();
            Vector2 CurrentPosition = new Vector2(98, 98);
            double ballRadius = 1;
            double boardWidth = 100;
            Assert.IsTrue(logic.checkVerticalCollision(CurrentPosition, new Vector2(10, 10), ballRadius, boardWidth));
            Assert.IsFalse(logic.checkVerticalCollision(CurrentPosition, new Vector2(0, 0), ballRadius, boardWidth));
        }

        [TestMethod]
        public void TestCheckHorizontalCollision()
        {
            BallLogic logic = new BallLogic();
            Vector2 CurrentPosition = new Vector2(98, 98);
            double ballRadius = 1;
            double boardHeight = 100;
            Assert.IsTrue(logic.checkHorizontalCollision(CurrentPosition, new Vector2(10, 10), ballRadius, boardHeight));
            Assert.IsFalse(logic.checkHorizontalCollision(CurrentPosition, new Vector2(0, 0), ballRadius, boardHeight));
        }
    }
}