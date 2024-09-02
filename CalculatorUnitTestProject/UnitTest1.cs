using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWpfProgCalculator;

namespace CalculatorUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ACalculator myCalculator = new StandardCalculator();
            myCalculator.CurrResult = 9;
            myCalculator.Power(9);
            Assert.AreEqual(myCalculator.CurrResult, 387420489);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ACalculator myCalculator = new StandardCalculator();
            myCalculator.CurrResult = 987654;
            myCalculator.Power(0);
            Assert.AreEqual(myCalculator.CurrResult, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            ACalculator myCalculator = new StandardCalculator();
            myCalculator.CurrResult = 144;
            myCalculator.Power((double) 1/2);
            Assert.AreEqual(myCalculator.CurrResult, 12);
        }
    }
}
