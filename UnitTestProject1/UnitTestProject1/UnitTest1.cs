using NUnit.Framework;
using System;

namespace UnitTestProject1
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void AddMethodTest()
        {
            Calculator AddObj = new Calculator();
            int Result = AddObj.Add(15, 20);

            Assert.That(Result, Is.EqualTo(35));
        }

        [Test]
        [TestCase(15, 35, 50)]
        [TestCase(10, 45, 55)]
        [TestCase(20, 50, 70)]
        public void AddMethodTest(int num1, int num2, int expected)
        {
            Calculator AddObj = new Calculator();
            int Result = AddObj.Add(num1, num2);

            Assert.AreEqual(expected, Result);
        }
    }
}
