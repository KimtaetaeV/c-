using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Triangle:Area
    {
        private int thebase;
        private int height;

        public Triangle(int a,int b)
        {
            this.thebase = a;
            this.height = b;
        }

        public int getArea()
        {
            return thebase*height/2;
        }
    }
}
