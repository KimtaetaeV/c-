using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class counter1
    {
        static void Main(string[] args)
        {
            String s;
            int a, b,c=0;
            Console.Write("输入进行运算的第一个数:");
            s=Console.ReadLine();
            a = Int32.Parse(s);
            Console.Write("输入进行运算的第二个数:");
            s = Console.ReadLine();
            b = Int32.Parse(s);
            Console.Write("输入运算符（+，-，*，/）:");
            s = Console.ReadLine();
            if (s == "+") { c = a + b; }
            if (s == "-") { c = a - b; }
            if (s == "*") { c = a * b; }
            if (s == "/") { c = a / b; }
            Console.WriteLine(a + s + b + "=" + c);
            Console.ReadLine();
        }
    }
}
