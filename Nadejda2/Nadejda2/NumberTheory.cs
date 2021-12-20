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
        #region Разложение числа на множители <Проверено>
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
        #region Обратный элемент
        public class InverseEl : ISolutable
        {
            public long a;
            public long m;
            private StringBuilder sb = new StringBuilder();
            private long inverse;

            public InverseEl(long a,long b)
            {
                this.a = a;
                m = b;
                Solution();
            }
            private void Solution()
            {
                if (GetNod(a,m).GetValue() != 1)
                {
                    sb.Append($"Числа {a} и {m} не взаимно простые => обратного к {a} нет");
                }
                else
                {
                    List<long> mnoj = new List<long>();
                    while (true)
                    {
                        if (a>m)
                        {
                            sb.AppendLine($"{a}={m}*{a / m}+{a % m}");
                            mnoj.Add(a / m);
                            if (a % m != 1)
                                a %= m;
                            else
                                break;
                        }
                        else
                        {
                            sb.AppendLine($"{m}={a}*{m / a}+{m % a}");
                            mnoj.Add(m / a);
                            if (m % a != 1)
                                m %= a;
                            else
                                break;
                        }
                    }
                    if (m < a)
                    {
                        m += a;
                        a = m - a;
                        m -= a;
                    }
                    string forAnsw = $"1={m}-{a}*{m / a}";
                    sb.Append(forAnsw);
                    forAnsw=forAnsw.Remove(0,2);
                    bool lamp = true;
                    for (int i = mnoj.Count - 2; i >= 0; i--)
                    {
                        if (lamp)
                        {
                            for (int j = 0; j < forAnsw.Length; j++)
                            {
                                if ((j==0||forAnsw[j-1] != '*') &&char.IsDigit(forAnsw[j]))
                                {
                                    int j1 = j;
                                    string num = "";
                                    while (j1 != forAnsw.Length && char.IsDigit(forAnsw[j1]))
                                    {
                                        num += forAnsw[j1];
                                        j1++;
                                    }
                                    if (num == a.ToString())
                                    {
                                        forAnsw=forAnsw.Remove(j, num.Length);
                                        forAnsw = forAnsw.Insert(j, $"({a + m * mnoj[i]}-{m}*{mnoj[i]})");
                                    }
                                    j = j1;
                                }
                            }
                            lamp = false;
                            a += m * mnoj[i];
                        }
                        else
                        {
                            for (int j = 0; j < forAnsw.Length; j++)
                            {
                                if ((j == 0 || forAnsw[j - 1] != '*') && char.IsDigit(forAnsw[j]))
                                {
                                    int j1 = j;
                                    string num = "";
                                    while (j1 != forAnsw.Length && char.IsDigit(forAnsw[j1]))
                                    {
                                        num += forAnsw[j1];
                                        j1++;
                                    }
                                    if (num == m.ToString())
                                    {
                                        forAnsw = forAnsw.Remove(j, num.Length);
                                        forAnsw = forAnsw.Insert(j, $"({m + a * mnoj[i]}-{a}*{mnoj[i]})");
                                    }
                                    j = j1;
                                }
                            }
                            lamp = true;
                            m += a * mnoj[i];
                        }
                        sb.Append("="+forAnsw);
                    }
                    sb.AppendLine();
                    inverse = a;
                    for (int i = 0; i < GetEulerFunc(m).GetValue() - 2; i++)
                    {
                        inverse *= a;
                        inverse %= m;
                    }
                    //inverse = (long)Math.Pow(a, GetEulerFunc(m).GetValue() - 1) % m;
                    sb.AppendLine($"Группируем, коэффициент перед {a} равен {inverse}");
                }
            }
            public string GetSolution()
            {
                return sb.ToString();
            }
            public long GetValue()
            {
                return inverse;
            }
        }
        public static InverseEl GetInverse(long a, long b)
        {
            return new InverseEl(a, b);
        }
        #endregion
        #region Функция Эйлера
        public class EulerFunc:ISolutable
        {
            public long n;
            private long result;
            private StringBuilder sb = new StringBuilder();
            public EulerFunc(long n)
            {
                this.n = n;
                Solution();
            }
            private void Solution()
            {
                if (n < 1)
                {
                    result = 0;
                    sb.Append("Аргумент функции должен быть больше 0");
                }
                else
                {
                    var multipliers = GetMultipliersOfNumber(n);
                    var nums = multipliers.GetList();
                    sb.Append(multipliers.GetSolution());
                    sb.Append($"fE({n})=1");
                    result = 1;
                    for (int i = 0, count = 0; i < nums.Count; i++)
                    {
                        if (i != nums.Count - 1 && nums[i] == nums[i + 1])
                        {
                            count++;
                        }
                        else
                        {
                            if (count == 0)
                            {
                                sb.Append($"*fE({nums[i]})={nums[i]-1}");
                                result *= nums[i] - 1;
                            }
                            else
                            {
                                count++;
                                sb.Append($"*fE({nums[i]}^{count})={Math.Pow(nums[i], count)}-{Math.Pow(nums[i], count - 1)}={Math.Pow(nums[i], count)- Math.Pow(nums[i], count-1)}");
                                result *= (long)(Math.Pow(nums[i], count) - Math.Pow(nums[i], count - 1));
                                count = 0;
                            }
                        }
                    }
                }
            }
            public string GetSolution()
            {
                return sb.ToString();
            }
            public long GetValue()
            {
                return result;
            }
        }
        public static EulerFunc GetEulerFunc(long n)
        {
            return new EulerFunc(n);
        }
        #endregion
        #region Символ Лежандра
        public class LegendreSymbol:ISolutable
        {
            public long a;
            public long p;
            private StringBuilder sb=new StringBuilder();
            private long result;
            public LegendreSymbol(long a,long p)
            {
                this.a = a;
                this.p = p;
                Solution();
            }
            private void Solution()
            {
                sb.Append($"Быстрое решение, критерий Эйлера: ({a}/{p})={a}^(({p}-1)/2) (mod {p})={a}^{(p-1)/2}(mod {p})=");
                result = a;
                for(int i=0;i<(p-1)/2-1;i++)
                {
                    result *= a;
                    result %= p;
                }
                if (result == p - 1)
                    result = -1;
                sb.Append(result);
            }
            public string GetSolution()
            {
                return sb.ToString();
            }
            public long GetValue()
            {
                return result;
            }
        }
        public static LegendreSymbol GetLegendreSymbol(long a,long p)
        {
            return new LegendreSymbol(a, p);
        }
        #endregion
    }
}
