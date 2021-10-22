using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavyBattle1
{
    class CellOfShip
    {
        public CellOfShip(Point coord)
        {
            Coord = coord;
            Quadrants = QuadrantDefinite(coord);
        }

        internal List<Quadrants> Quadrants { get; set; }

        internal Point Coord { get; set; }

        internal bool Intact { get; set; }

        List<Quadrants> QuadrantDefinite(Point coord)
        {
            List<Quadrants> list = new List<Quadrants>();
            if (coord.x > 0 && coord.y > 0)
            {
                list.Add(NavyBattle1.Quadrants.First);
                return list;
            }
            else if (coord.x < 0 && coord.y > 0)
            {
                list.Add(NavyBattle1.Quadrants.Second);
                return list;
            }
            else if (coord.x == 0 && coord.y > 0)
            {
                list.Add(NavyBattle1.Quadrants.First);
                list.Add(NavyBattle1.Quadrants.Second);
                return list;
            }
            else if (coord.x < 0 && coord.y < 0)
            {
                list.Add(NavyBattle1.Quadrants.Third);
                return list;
            }
            else if (coord.x < 0 && coord.y == 0)                  
            {                                                 //    _-_|__ 
                list.Add(NavyBattle1.Quadrants.Second);       //       |
                list.Add(NavyBattle1.Quadrants.Third);        
                return list;
            }
            else if (coord.x > 0 && coord.y < 0)
            {
                list.Add(NavyBattle1.Quadrants.Fourth);
                return list;
            }
            else if (coord.x == 0 && coord.y < 0)
            {
                list.Add(NavyBattle1.Quadrants.Third);
                list.Add(NavyBattle1.Quadrants.Fourth);
                return list;
            }
            else if (coord.x > 0 && coord.y == 0)
            {
                list.Add(NavyBattle1.Quadrants.First);
                list.Add(NavyBattle1.Quadrants.Fourth);
                return list;
            }
            else if (coord.x == 0 && coord.y == 0)
            {
                list.Add(NavyBattle1.Quadrants.First);
                list.Add(NavyBattle1.Quadrants.Second);
                list.Add(NavyBattle1.Quadrants.Third);
                list.Add(NavyBattle1.Quadrants.Fourth);
                return list;
            }

            return list;           
        }       
    }
}
