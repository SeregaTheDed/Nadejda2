using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nadejda2;
using System;
using System.Linq;
using System.Collections.Generic;

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
    [TestClass]
    public class TestIsPrime
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var primes = new long[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657, 1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811, 1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987, 1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 2111, 2113, 2129, 2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 2267, 2269, 2273, 2281, 2287, 2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 2383, 2389, 2393, 2399, 2411, 2417, 2423, 2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617, 2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741, 2749, 2753, 2767, 2777, 2789, 2791, 2797, 2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903, 2909, 2917, 2927, 2939, 2953, 2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079, 3083, 3089, 3109, 3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257, 3259, 3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 3413, 3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 3557, 3559, 3571 };
            var list = new List<long>();
            int i = 2;
            while (list.Count != 500)
            {
                if (i.IsPrime())
                    list.Add(i);
                i++;
            }
            for (i = 0; i < primes.Length; i++)
            {
                Assert.AreEqual(primes[i], list[i]);
            }
        }
    }
    [TestClass]
    public class TestMultipliersOfNumber
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Random rand = new();
            for (int i = 0; i < 100; i++)
            {
                long LastNum = rand.NextInt64(2, long.MaxValue);
                var GettedDivisions = NumberTheory.GetMultipliersOfNumber(LastNum).GetList();
                long NewNum = GettedDivisions.Aggregate((x, y) => x * y);
                Assert.AreEqual(LastNum, NewNum);
            }
        }
    }
    [TestClass]
    public class TestInverse
    {
        [TestMethod]
        public void TestMethod()
        {
            var num = NumberTheory.GetInverse(63, 5).GetValue();
            Assert.AreEqual(2, num);
        }
        [TestMethod]
        public void NotPrimeToEachOther()
        {
            var exeption = NumberTheory.GetInverse(34, 111000).GetSolution();
            Assert.AreEqual("Числа 34 и 111000 не взаимно простые => обратного к 34 нет", exeption);
        }
    }
    [TestClass]
    public class TestEulerFunc
    {
        [TestMethod]
        public void PrimeN()
        {
            var num = NumberTheory.GetEulerFunc(23).GetValue();
            Assert.AreEqual(22, num);
        }
        [TestMethod]
        public void PrimePowN()
        {
            var num = NumberTheory.GetEulerFunc(25).GetValue();
            Assert.AreEqual(20, num);
        }
        [TestMethod]
        public void NotPrimeN()
        {
            var num = NumberTheory.GetEulerFunc(150).GetValue();
            Assert.AreEqual(40, num);
        }
        [TestMethod]
        public void BigNotPrimeN()
        {
            var num = NumberTheory.GetEulerFunc(1508834).GetValue();
            Assert.AreEqual(754416, num);
        }
    }
    [TestClass]
    public class TestLegendreSymbol
    {
        [TestMethod]
        public void ResultZero()
        {
            var num = NumberTheory.GetLegendreSymbol(10, 500).GetValue();
            Assert.AreEqual(0, num);
        }
        [TestMethod]
        public void ResultOne()
        {
            var num = NumberTheory.GetLegendreSymbol(10, 13).GetValue();
            Assert.AreEqual(1, num);
        }
        [TestMethod]
        public void ResultMinusOne()
        {
            var num = NumberTheory.GetLegendreSymbol(1350, 1381).GetValue();
            Assert.AreEqual(-1, num);
        }
    }
    [TestClass]
    public class TestLessDegree
    {
        [TestMethod]
        public void WithFerma()
        {
            var num = NumberTheory.GetLessDegree(2, 1024, 13).GetValue();
            Assert.AreEqual(4, num);
        }
        [TestMethod]
        public void WithEuler()
        {
            var num = NumberTheory.GetLessDegree(13, 1000, 100).GetValue();
            Assert.AreEqual(0, num);
        }
    }
    [TestClass]
    public class TestComparasion
    {
        [TestMethod]
        public void OneSolution()
        {
            var num = NumberTheory.GetComparison(13, 2, 4).GetList()[0];
            Assert.AreEqual(2, num);
        }
        [TestMethod]
        public void NoSolution()
        {
            var num = NumberTheory.GetComparison(13, 2, 39).GetList().Count;
            Assert.AreEqual(0, num);
        }
        [TestMethod]
        public void MoreThanOneSolution()
        {
            var num = NumberTheory.GetComparison(420, 462, 511).GetList()[1];
            Assert.AreEqual(96, num);
        }
    }
    [TestClass]
    public class TestElOrder
    {
        [TestMethod]
        public void SomeValues()
        {
            var num = NumberTheory.GetElOrder(7, 25).GetValue();
            Assert.AreEqual(4, num);
        }
        [TestMethod]
        public void SomeValues1()
        {
            var num = NumberTheory.GetElOrder(5, 73).GetValue();
            Assert.AreEqual(72, num);
        }
    }
    [TestClass]
    public class TestChineseTheory
    {
        [TestMethod]
        public void SomeValues()
        {
            var num = NumberTheory.GetSystemSolution(3, new long[,] { { 5, 7 }, { 3, 11 }, { 10, 13 } }).GetValue();
            Assert.AreEqual(894, num);
        }
        [TestMethod]
        public void SomeValues1()
        {
            var num = NumberTheory.GetSystemSolution(3, new long[,] { { 1, 2 }, { 2, 3 }, { 6, 7 } }).GetValue();
            Assert.AreEqual(41, num);
        }
    }
}
