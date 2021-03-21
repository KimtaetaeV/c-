using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
   
    class Program
    {
       
        static void Main(string[] args)
        {
            GenericList<int> intList = new GenericList<int>();
            Random Ram = new Random();
            for(int i = 0; i < 6; i++)
            {
                int ran = Ram.Next(2, 10);
                intList.addNode(ran);
            }

            int minTemp = 10;
            int maxTemp = 0;
            Action<int> action1 = (int s) => { Console.Write(s); };
            Action<int> action2 = (int s) => { maxTemp = s > maxTemp ? s:maxTemp; };
            Action<int> action3 = s => { minTemp = s < minTemp ? s : minTemp; };
            Console.WriteLine("遍历泛型链表：");
            intList.Foreach(action1);
            intList.Foreach(action2);
            intList.Foreach(action3);
            Console.WriteLine($"\n最大值为{maxTemp}");
            Console.WriteLine($"最小值为{minTemp}");
            Console.ReadLine();

        }
    }
}
