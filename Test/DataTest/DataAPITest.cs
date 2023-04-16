using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        [TestMethod]
        public void TestGetBallCoordinates()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(api.GetBallCoordinates(i).X > 10.0F & api.GetBallCoordinates(i).X < 414);
                Assert.IsTrue(api.GetBallCoordinates(i).Y > 10.0F & api.GetBallCoordinates(i).Y < 630);
            }
        }

        [TestMethod]
        public void TestGetBallRadius()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            Assert.AreEqual(api.GetBallRadius(0), 5.0);
        }

        [TestMethod]
        public void TestGetBallSpeedVector()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(api.GetBallSpeedVector(i).X < 2 & api.GetBallSpeedVector(i).Y < 2);
            }
        }

        [TestMethod]
        public void TestGetBallWeight()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            Assert.AreEqual(api.GetBallWeight(0), 1.0);
        }

        [TestMethod]
        public void TestGetBoardWidth()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            Assert.AreEqual(api.GetBoardWidth(), 414);
        }

        [TestMethod]
        public void TestGetBoardHeight()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            Assert.AreEqual(api.GetBoardHeight(), 630);
        }

        [TestMethod]
        public void TestSetBallSpeedVector()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(3, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            api.SetBallSpeedVector(0, new System.Numerics.Vector2(1, 1));
            Assert.AreEqual(api.GetBallSpeedVector(0), new System.Numerics.Vector2(1, 1));
        }

        [TestMethod]
        public void TestUpdateBallCoordinates()
        {
            AbstractDataAPI api = AbstractDataAPI.CreateDataAPI();
            api.GenerateBalls(1, 5.0, 1.0, new System.Numerics.Vector2(2, 2));
            System.Numerics.Vector2 vector = api.GetBallCoordinates(0);
            api.UpdateBallPosition(0);
            Assert.AreNotEqual(vector, api.GetBallCoordinates(0));
        }
    }
}
