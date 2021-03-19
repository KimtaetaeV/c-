using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{

    class Rectangle:Area
    {
        private int height;
        private int weight;
        public int getArea()
        {
            return this.height * this.weight;
        }

        public bool valid()
        {
            if (height != weight) return true;
            return false;
        }

        public Rectangle(int height,int weight)
        {
            this.height = height;
            this.weight = weight;
        }
    }
}
