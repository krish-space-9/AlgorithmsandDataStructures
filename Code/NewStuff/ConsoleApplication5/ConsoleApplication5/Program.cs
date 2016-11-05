using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        enum Color
        {
            Red, Blue, Green
        }
        static void Main(string[] args)
        {
            int state = 1;
            if((int)Color.Red==state)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("Not blue");
            }

            Console.ReadLine();
        }
    }
}
