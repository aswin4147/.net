using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDotNetC1
{
    internal class ImpAndExp
    {
        public void test()
        {
            // implicit conversion
            byte b = 69;
            int a = b;

            // explicit conversion
            int x = 67;
            byte z = (byte)x;
        }
    }
}
