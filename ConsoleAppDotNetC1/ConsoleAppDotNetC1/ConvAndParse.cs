using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDotNetC1
{
    internal class ConvAndParse
    {
        public void test()
        {
            string str = null;
            int x = Convert.ToInt32(str);
            Console.WriteLine(x);

            string str1 = null;
            int x1 = int.Parse(str1);
            Console.WriteLine(x1);

            string Uname = null;

            if (int.TryParse(Uname, out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No res");
            }
        }
    }
}
