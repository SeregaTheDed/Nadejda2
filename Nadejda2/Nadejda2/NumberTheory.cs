using System;
using System.Collections.Generic;
using System.Text;

namespace Nadejda2
{
    interface IGettable
    {
        int GetValue();
        string Solution { get; set; }
    }
    public static class NumberTheory
    {
        private class NOD : IGettable
        {
            public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public string Solution { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }

    }
}
