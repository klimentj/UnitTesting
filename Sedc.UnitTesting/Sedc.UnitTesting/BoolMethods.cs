using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.UnitTesting
{
    public  class BoolMethods
    {
        public bool IsLeapYear(int year)
        {
            if (year < 1)
                throw new ArgumentException("Year must be positive number");

            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                return true;
            else
                return false;
        }
    }
}
