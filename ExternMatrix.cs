using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Goose3.NET
{
    class ExternMatrix
    {
        [DllImport("MyDllSecond.dll", CharSet = CharSet.Unicode)]
        public static extern double doubleRand();
        //public static extern void print();
    }
}
