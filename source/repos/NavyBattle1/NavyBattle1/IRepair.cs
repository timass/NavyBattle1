using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavyBattle1
{
    interface IRepair
    {
        //void Repair() { }
        void Repair(int strangth, Point coord, List<CellOfShip> location) //Check, can we act for pointed coordinates and then, are giving them  to class Battlefield
        {
            Console.WriteLine("We can use possibilities of C# and realize method in interface");
        }

    }
}
