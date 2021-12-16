using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Nadejda2
{
    #region ReadMe
    /*
    Readme для DedEgor-creator
    Смотри только на статические методы у статического класса NumberTheory. 
    Смотри какие параметры у каждого статического класса, начинающегося с Get. 
    У каждого класса будет метод GetSolution - он будет возвращать стринг - это тупо все решение
    тебе больше ничего знать не надо.



    Readme для всех остальных.
    Я в вас верю, вы умные, кароче, по задумке у нас паттерн проектирования завод.
    Тип у нас есть куча классов, но получать их будет желательно через Get{Name_Of_Class}
    Позволит если что втыкать заглушки, да и проще фронт с беком совмещать.
    Для нас:
    Метод GetValue(при наличии) должен возвращать одно число - решение
    Метод GetList(при наличии) должен возвращать список - решение
    Метод GetSolution должен возвращать строку - решение с каждым шагом 


    */
    #endregion
    interface ISolutable
    {
        string GetSolution();
    }

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
        public class NOD : ISolutable
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
            /// <summary>
            /// Calculating GCD
            /// </summary>
            /// <param name="a">First num</param>
            /// <param name="b">Second num</param>
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
        public static NOD GetNod(long a, long b)
        {
            return new NOD(a, b);
        }
        #endregion
        #region Разложение числа на множители <В разработке>
        public class MultipliersOfNumber : ISolutable
        {
            public long Num { get; set; }
            /// <summary>
            /// StringBuilder which is used to output the result(after converting to String using .ToString())
            /// </summary>
            private StringBuilder sb = new StringBuilder();
            /// <summary>
            /// An list is the final list of the multipliers of a number
            /// </summary>
            private List<long> result = new List<long>();
            private void SolutionThisFunction()
            {
                if (Num <= 0)
                    throw new ArgumentException("Number must be positive value");
                var CurrentNumber = Num;
                while (CurrentNumber > 1)
                {
                    long division = 2;
                    if (CurrentNumber.IsPrime())
                    {
                        sb.AppendLine($"{CurrentNumber}|{CurrentNumber}");
                        sb.AppendLine($"1| ");
                        result.Add(CurrentNumber);
                        CurrentNumber = 1;
                    }
                    else
                    {
                        for (; division <= CurrentNumber; division++)
                        {
                            if (CurrentNumber % division == 0)
                                break;
                        }
                        sb.AppendLine($"{CurrentNumber}|{division}");
                        CurrentNumber/=division;
                        result.Add(division);
                    }
                   
                }
            }
            public List<long> GetList() => result;
            public MultipliersOfNumber(long num)
            {
                Num = num;
                SolutionThisFunction();
            }

            public string GetSolution()
            {
                return sb.ToString();
            }
        }
        public static MultipliersOfNumber GetMultipliersOfNumber(long num)
        {
            return new MultipliersOfNumber(num);
        }
        #endregion
       

    }
}
