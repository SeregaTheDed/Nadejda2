using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nadejda2
{
    public interface IGettable
    {

        /// <summary>
        /// Метод получения результата выполнения функции
        /// </summary>
        /// <returns>Целое число - результат работы функции</returns>
        long GetValue();
        /// <summary>
        /// Метод получения полного решения выполнения функции
        /// </summary>
        /// <returns>Строку, которая представляет из себя полное решение функции, может включать
        /// символы \n</returns>
        string GetSolution();
    }
    /// <summary>
    /// A class that expands the possibilities of integers in the field of algebra and number theory
    /// </summary>
    public static class NumberTheoryCheckNums 
    {
        #region Проверка на то, простое ли число <Проверено>
        /// <summary>
        /// Checking the number for simplicity
        /// </summary>
        /// <param name="num">Number for check</param>  
        /// <returns>Is it a prime number</returns>
        public static bool IsPrime(this long num)
        {
            var primes = new long[] { 2, 3, 5, 7, 11, 13, 17 };
            if (num <= 17)
                return primes.Contains(num);
            else
            {
                for (int i = 2; i < (int)Math.Sqrt(num) + 1; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Checking the number for simplicity
        /// </summary>
        /// <param name="num">Number for check</param>  
        /// <returns>Is it a prime number</returns>
        public static bool IsPrime(this int num)
        {
            return IsPrime((long)num);
        }
        #endregion


    }
    /// <summary>
    /// A class that is a list of functions in number theory.
    /// Each method has a getValue() and GetSolution() method that allow you to get the result of executing a function or its complete solution
    /// </summary>
    public static class NumberTheory
    {
        

        #region Вычисление НОД <Проверено>
        private class NOD : IGettable
        {
            /// <summary>
            /// One of the GCD calculation numbers will be located on the left
            /// </summary>
            public long A { get; set; }
            /// <summary>
            /// One of the GCD calculation numbers will be located on the right
            /// </summary>
            public long B { get; set; }
            /// <summary>
            /// StringBuilder which is used to output the result(after converting to String using .ToString())
            /// </summary>
            private StringBuilder sb = new StringBuilder();
            /// <summary>
            /// An integer is the final result of the function execution
            /// </summary>
            private long result;
            public string GetSolution()
            {
                return sb.ToString();
            }

            public long GetValue()
            {
                return result;
            }
            public NOD(long a, long b)
            {
                A = a;
                B = b;
                SolutionThisFunction();
            }
            /// <summary>
            /// Calculation of the GCD and the text representation of the solution
            /// </summary>
            /// <exception cref="ArgumentException">One of the arguments was not a positive number</exception>
            private void SolutionThisFunction()
            {
                 
                if (A <= 0)
                    throw new ArgumentException($"Argument A({A}) is not valid: must be positive value!");
                if (B <= 0)
                    throw new ArgumentException($"Argument B({B}) is not valid: must be positive value!");
                while (A != 0 && B != 0)
                {
                    sb.AppendLine($"{A}|{B}");
                    if (A > B)
                    {
                        A %= B;
                    }
                    else
                    {
                        B %= A;
                    }
                }
                sb.AppendLine($"{A}|{B}");
                result = Math.Max(A, B);
            }
        }
        public static IGettable GetNod(long a, long b)
        {
            return new NOD(a, b);
        }
        #endregion
        #region Разложение числа на множители !!!нету

        #endregion


    }
}
