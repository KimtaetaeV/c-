using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Test
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(2, 3);
            Rectangle r2 = new Rectangle(2, 2);
            Square s = new Square(2);
            Triangle t = new Triangle(2, 3);
            if (!r2.valid()) { Console.WriteLine("此长方形不合法！"); }
            Console.WriteLine("长方形的面积为：" + r.getArea());
            Console.WriteLine("正方形的面积为：" + s.getArea());
            Console.WriteLine("三角形的面积为：" + t.getArea());
            Console.ReadLine();
        }
    }
}
