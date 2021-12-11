using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nadejda2;
using System;

namespace TestMethods
{
    [TestClass]
    public class TestNod
    {
        [TestMethod]
        public void TestGetNodMethod1()
        {
            var num = NumberTheory.GetNod(1, 9).GetValue();
            Assert.AreEqual(1, num);
        }
        [TestMethod]
        public void TestGetNodMethod2()
        {
            var num = NumberTheory.GetNod(1234, 334).GetValue();
            Assert.AreEqual(2, num);
        }
        [TestMethod]
        public void TestGetNodMethod3()
        {
            var num = NumberTheory.GetNod(2048, 128).GetValue();
            Assert.AreEqual(128, num);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetNodMethodException()
        {
            NumberTheory.GetNod(-1234, 334).GetValue();
        }
    }
}