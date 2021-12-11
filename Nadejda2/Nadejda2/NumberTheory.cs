using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nadejda2
{
    public interface IGettable
    {
        /// <summary>
        /// Метод получения результата выполнения функции
        /// </summary>
        /// <returns>Целое число - результат работы функции</returns>
        int GetValue();
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
        public static bool IsPrime(this int num)
        {
            if (num  0)
            if (num)
        }
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
            public int A { get; set; }
            /// <summary>
            /// One of the GCD calculation numbers will be located on the right
            /// </summary>
            public int B { get; set; }
            /// <summary>
            /// StringBuilder which is used to output the result(after converting to String using .ToString())
            /// </summary>
            private StringBuilder sb = new StringBuilder();
            /// <summary>
            /// An integer is the final result of the function execution
            /// </summary>
            private int result;
            public string GetSolution()
            {
                return sb.ToString();
            }

            public int GetValue()
            {
                return result;
            }
            public NOD(int a, int b)
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
        public static IGettable GetNod(int a, int b)
        {
            return new NOD(a, b);
        }
        #endregion
        #region Разложение числа на множители !!!нету

        #endregion


    }
}
