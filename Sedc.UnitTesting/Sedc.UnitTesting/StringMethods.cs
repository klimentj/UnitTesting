using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sedc.UnitTesting
{
    public class StringMethods
    {
        public string Reverse(string value)
        {
            //Thread.Sleep(30000);
            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public string ReverseLong(string value)
        {
            Thread.Sleep(10000);
            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
