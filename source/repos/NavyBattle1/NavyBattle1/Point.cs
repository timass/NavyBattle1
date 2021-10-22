using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavyBattle1
{
    struct Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int x { get; set; }

        internal int y { get; set; }

        public static bool operator ==(Point coor1, Point coor2)
        {
            return (coor1.x == coor2.x && coor1.y == coor2.y);
        }

        public static bool operator !=(Point coor1, Point coor2)
        {
            return (coor1.x != coor2.x || coor1.y != coor2.y);
        }    
        
    }
}
