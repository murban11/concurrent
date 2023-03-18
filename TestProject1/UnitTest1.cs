using ClassLibrary1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {   
            Calculator calculator = new Calculator();

            Assert.AreEqual(4, calculator.add(2, 2));

        }

        [TestMethod]
        public void TestMethod2()
        {
            Calculator calculator = new Calculator();

            Assert.AreEqual(3, calculator.subtract(9, 6));
        }
    }
}