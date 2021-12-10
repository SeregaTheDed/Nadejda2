using System;
using System.Collections.Generic;
using System.Text;

namespace Nadejda2
{
    interface IGettable
    {
        int GetValue();
        string GetSolution();
    }

    public static class NumberTheory
    {

        public class NOD : IGettable
        {
            private int a { get; set; }
            private int b { get; set; }
            public string GetSolution()
            {
                throw new NotImplementedException();
            }

            public int GetValue()
            {
                throw new NotImplementedException();
            }
            public NOD(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
        }
        public static NOD GetNod(int a, int b)
        {
            return new NOD(a, b);
        }
        public static void Pop()
        {

        }
    }
}
