using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

    public static class NumberTheory
    {

        private class NOD : IGettable
        {
            /// <summary>
            /// Одно из чисел вычисления НОД, будет распологаться слева
            /// </summary>
            public int A { get; set; }
            /// <summary>
            /// Одно из чисел вычисления НОД, будет распологаться справа
            /// </summary>
            public int B { get; set; }
            /// <summary>
            /// StringBuilder который используется для вывода результата(после преобразования
            /// в String с помощью .ToString())
            /// </summary>
            private StringBuilder sb = new StringBuilder();
            /// <summary>
            /// Целое число - конечный результат выполнения функции
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
            private void SolutionThisFunction()
            {
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

    }
}
