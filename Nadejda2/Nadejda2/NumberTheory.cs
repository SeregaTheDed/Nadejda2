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
                    long m1 = m;
                    long a1 = a;
                    List<long> mnoj = new List<long>();
                    while (true)
                    {

                        if (a > m)
                        {
                            sb.AppendLine($"{a}={m}*{a / m}+{a % m}");
                            mnoj.Add(a / m);
                            if (a % m != 1 && a % m != 0)
                                a %= m;
                            else
                                break;
                        }
                        else
                        {
                            sb.AppendLine($"{m}={a}*{m / a}+{m % a}");
                            mnoj.Add(m / a);
                            if (m % a != 1 && m % a != 0)
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
                                        forAnsw = forAnsw.Remove(j, num.Length);
                                        forAnsw = forAnsw.Insert(j, $"({a + m * mnoj[i]}-{m}*{mnoj[i]})");
                                        int leng = $"({m + a * mnoj[i]}-{a}*{mnoj[i]})".Length - num.Length;
                                        j += leng - 1;
                                    }
                                    else
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
                                        int leng = $"({m + a * mnoj[i]}-{a}*{mnoj[i]})".Length - num.Length;
                                        j += leng - 1;
                                    }
                                    else
                                        j = j1;
                                }
                            }
                            lamp = true;
                            m += a * mnoj[i];
                        }
                        sb.Append("="+forAnsw);
                    }
                    sb.AppendLine();
                    inverse = 1;
                    for (int i = 0; i < GetEulerFunc(m1).GetValue() - 1; i++)
                    {
                        inverse *= a1;
                        inverse %= m1;
                    }
                    //inverse = (long)Math.Pow(a, GetEulerFunc(m).GetValue() - 1) % m;
                    sb.AppendLine($"Группируем, коэффициент перед {a1} равен {inverse}");
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
                                sb.AppendLine($"*fE({nums[i]})={nums[i]-1}");
                                result *= nums[i] - 1;
                            }
                            else
                            {
                                count++;
                                sb.AppendLine($"*fE({nums[i]}^{count})={Math.Pow(nums[i], count)}-{Math.Pow(nums[i], count - 1)}={Math.Pow(nums[i], count)- Math.Pow(nums[i], count-1)}");
                                result *= (long)(Math.Pow(nums[i], count) - Math.Pow(nums[i], count - 1));
                                count = 0;
                            }
                        }
                    }
                    sb.Append($"={result}");
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
        #region Сокращение степени в кольце
        public class LessDegree : ISolutable
        {
            public long a;
            public long m;
            public long degree;
            private StringBuilder sb = new StringBuilder();

            public LessDegree(long a,long m, long degree)
            {
                this.a = a;
                this.m = m;
                this.degree = degree;
                Solution();
            }
            private void Solution()
            {
                var euler = GetEulerFunc(m);
                sb.AppendLine(euler.GetSolution());
                long eulerV = euler.GetValue();
                if (eulerV==m-1)
                {
                    sb.AppendLine($"{m}-простое число, применяем малую теорему Ферма:{degree}={eulerV}*{degree/eulerV}+{degree%eulerV}");                 
                }
                else
                {
                    sb.AppendLine($"{m}-составное число, применяем теорему Эйлера:{degree}={eulerV}*{degree / eulerV}+{degree % eulerV}");                
                }
                sb.AppendLine($"Сократили до {a}^{degree % eulerV}");
                sb.Append($"{a}^{degree}(mod {m})={a}^{degree % eulerV}(mod {m})");
                degree %= eulerV;
            }
            public string GetSolution()
            {
                return sb.ToString();
            }
            public long GetValue()
            {
                return degree;
            }
        }
        public static LessDegree GetLessDegree(long a,long degree,long m)
        {
            return new LessDegree(a, m, degree);
        }
        #endregion
        #region Решений сравнений первой степени
        public class Comparison:ISolutable
        {
            public long a;
            public long b;
            public long m;
            private List<long> result;
            private StringBuilder sb = new StringBuilder();

            public Comparison(long a,long b,long m)
            {
                this.a = a;
                this.b = b;
                this.m = m;
                Solution();
            }

            public void Solution()
            {
                var nod = GetNod(a, m);
                sb.AppendLine(nod.GetSolution());
                result = new List<long>();
                if (nod.GetValue()==1)
                {
                    sb.AppendLine($"{a} и {m} взаимно простые => система имеет одно решение:");
                    InverseEl inverse = GetInverse(a,m);
                    sb.AppendLine(inverse.GetSolution());
                    result.Add(b * inverse.GetValue() % m);
                    sb.AppendLine($"x={b}*{inverse.GetValue()}(mod {m})={result[0]}");
                }
                else
                {
                    if (GetNod(b,nod.GetValue()).GetValue()==1)
                    {
                        sb.Append($"Числа {a} и {m} не взаимно простые и {b} не делится на {nod.GetValue()} => решений нет");
                    }
                    else if (b>nod.GetValue())
                    {
                        sb.AppendLine($"Числа {a} и {m} не взаимно простые, {b} делится на {nod.GetValue()} => сравнение имеет {nod.GetValue()} решений");
                        sb.AppendLine($"{a}/{nod.GetValue()}=={a/nod.GetValue()}");
                        a /= nod.GetValue();
                        sb.AppendLine($"{b}/{nod.GetValue()}=={b / nod.GetValue()}");
                        b /= nod.GetValue();
                        sb.AppendLine($"{m}/{nod.GetValue()}=={m / nod.GetValue()}");
                        m /= nod.GetValue();
                        InverseEl inverse = GetInverse(a, m);
                        sb.AppendLine(inverse.GetSolution());
                        result.Add(b * inverse.GetValue() % m);
                        sb.AppendLine($"x0={b}*{inverse.GetValue()}={result[0]}");
                        for(int i=1;i<nod.GetValue();i++)
                        {
                            sb.AppendLine($"x{i}={result[i - 1] + m}");
                            result.Add(result[i - 1] + m);
                        }
                    }
                }
            }
            public string GetSolution()
            {
                return sb.ToString();
            }
            public List<long> GetList()
            {
                return result;
            }
        }
        public static Comparison GetComparison(long a, long b, long m)
        {
            return new Comparison(a, b, m);
        }
        #endregion
        #region Вычисление порядка элемента в кольце
        public class ElOrder:ISolutable
        {
            public long element;
            public long mod;
            private StringBuilder sb = new StringBuilder();
            private long order;

            public ElOrder(long el, long mod)
            {
                element = el;
                this.mod = mod;
                Solution();
            }

            private void Solution()
            {
                if (GetNod(element,mod).GetValue()!=1)
                {
                    sb.AppendLine($"{element} и {mod} не взаимно простые, значит {element} не элемент мультипликативной группы обратимых элементов кольца");
                }
                else
                {
                    order = 0;
                    EulerFunc eulerMod = GetEulerFunc(mod);
                    sb.AppendLine(eulerMod.GetSolution());
                    sb.AppendLine("По теореме Лагранжа порядок группы делится на порядок любого элемента");
                    sb.AppendLine(GetMultipliersOfNumber(eulerMod.GetValue()).GetSolution());
                    for (int i = 1; i <= eulerMod.GetValue() / 2; i++)
                    {
                        if (eulerMod.GetValue() % i == 0)
                        {
                            var mulOfI = GetMultipliersOfNumber(i).GetList();
                            sb.Append($"{element}^{i}={element}^{String.Join("^", mulOfI)}");
                            if (i == 1)
                                sb.Remove(sb.Length - 1, 1);
                            long el1 = element;
                            for (int j = 1; j < i;j++)
                            {
                                el1 *= element;
                                el1 %= mod;
                            }
                            sb.AppendLine($"={el1}(mod {mod})");
                            if (el1 == 1)
                            {
                                sb.Append($"Значит порядок {element} в кольце Z{mod} равен {i}");
                                order = i;
                                break;
                            }
                        }
                    }
                    if (order == 0)
                    {
                        sb.AppendLine($"По теореме Эйлера {element}^fE({mod})=1(mod {mod}) => порядок равен {eulerMod.GetValue()}");
                        order = eulerMod.GetValue();
                    }
                }
            }
            public string GetSolution()
            {
                return sb.ToString();
            }
            public long GetValue()
            {
                return order;
            }
        }
        public static ElOrder GetElOrder(long element, long mod)
        {
            return new ElOrder(element, mod);
        }
        #endregion
    }
}