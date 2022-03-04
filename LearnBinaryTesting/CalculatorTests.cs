using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnBinaryLibrary;

namespace LearnBinaryTesting
{
    [TestClass]
    public class CalculatorTests
    {
        private static readonly Calculator calculator = new Calculator(50, 2);

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(calculator.Add(), 52);
        }

        [TestMethod]
        public void TestSub()
        {
            Assert.AreEqual(calculator.Sub(), 48);
        }

        [TestMethod]
        public void TestMul()
        {
            Assert.AreEqual(calculator.Mul(), 100);
        }

        [TestMethod]
        public void TestDiv()
        {
            Assert.AreEqual(calculator.Div(), 25);
        }

        [TestMethod]
        public void TestStaticAdd()
        {
            Assert.AreEqual(Calculator.Add(2, 3), 5);
        }
    }
}