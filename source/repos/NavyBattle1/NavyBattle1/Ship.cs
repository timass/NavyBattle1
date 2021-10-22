using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavyBattle1
{
    abstract class Ship
    {
        //internal CellOfShip Cell;
        internal List<CellOfShip> CeelsShip { get; set; } = new List<CellOfShip>();

        internal int Size { get; set; }    
        
        internal int Speed { get; set; }

        internal Directions DirectionOfMove { get; set; }

        internal int Strength { get; set; }

        public static bool operator ==(Ship ship1, Ship ship2)
        {
            return (ship1.ToString() == ship2.ToString() && ship1.Size == ship2.Size
                    && ship1.Speed == ship1.Speed);
        }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            return (ship1.ToString() != ship2.ToString() && ship1.Size != ship2.Size
                    && ship1.Speed != ship1.Speed);
        }

        public override int GetHashCode() //?
        {
            return Size.GetHashCode();
        }

        public override bool Equals(object obj)//?
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            else return true;            
        }

    }
}

