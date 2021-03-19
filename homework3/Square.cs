using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Square:Rectangle
    {
        private int side;
        public new int getArea()
        {
            return side*side;
 
        }

        public Square(int side):base(side,side)
        {
            this.side = side;
        }
        
    }
}
