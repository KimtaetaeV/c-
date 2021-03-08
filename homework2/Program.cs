using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
       


        static void Main(string[] args)
        {
            int[] arr = { 5, 6, 2, 8, 9 };
            int m1 = arr[0];
            int m2 = arr[0];
            int sum = 0;
            int aver;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] >= m1)
                    m1 = arr[i];
            }
            Console.WriteLine("最大为：" + m1);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] <= m2)
                    m2 = arr[i];
            }
            Console.WriteLine("最小为：" + m2);
            foreach (int num in arr)
            {
                sum += num;
            }
            Console.WriteLine("和为：" + sum);
            aver = sum / arr.Length;
            Console.WriteLine("平均值为：" + aver);

            Console.WriteLine("\nPress any key to quit.");
            Console.ReadKey();

        }
    }
}
