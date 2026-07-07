using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDotNetC1
{
    internal class BoxAndUnbox
    {
        public void test()
        {
            // boxing
            int x = 67676;
            object obj = x; 

            string str = x.ToString();


            // unboxing
            string s = "10";

            int a = Convert.ToInt32(s);
        }
    }
}
