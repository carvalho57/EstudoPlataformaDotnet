using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Arrays {
    public class ComparadorDecrescente : IComparer<int>
    {
        public int Compare(int x,int y)
        {
            if(x == y) {
                return 0;
            } else if(x > y) {
                return -1;
            } else  {
                return 1;
            }
        }
    }
}