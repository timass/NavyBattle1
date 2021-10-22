using System;
using System.Collections.Generic;
using System.Linq;

namespace NavyBattle1
{
    public class Battlefield
    {
        internal List<CellOfField> Cells = new List<CellOfField>();

        internal List<Ship> Ships = new List<Ship>();

        internal int SizeField { get; set; }

        Ship this[Quadrants q, Point.x Point.y]
        {
            get
            {
                return Ships[Ship.Cell .CellOfSheep.Quadrants q, Ship.CeelsShip.CellOfSheep.Point p];
            }
            set 
            {
                Ships[index]
            }
        }

                public void FieldInit()
        {
            for (int y = SizeField; y >= -SizeField; y--)
            {
                for (int x = -SizeField; x <= SizeField; x++)
                {
                    Cells.Add(new CellOfField() { Coordinat = new Point(x, y), FreeOrBusy = true });
                }

            }

        }

        internal void BusyCell(Point coordinat, List<CellOfField> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (coordinat == cells[i].Coordinat)
                {
                    cells[i].FreeOrBusy = false;
                }

            }

        }

        internal void ClearCell(Point coordinat, List<CellOfField> cells)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (coordinat == cells[i].Coordinat)
                {
                    cells[i].FreeOrBusy = true;
                }

            }

        }

        internal bool CheckPutList(List<Point> checkPutList, List<CellOfField> cells) // checking can we put ship (busy or not cells, borders of battlefield)
        {
            foreach (var fieldCells in cells) // checking cells
            {
                foreach (var checkCells in checkPutList)
                {
                    if (fieldCells.Coordinat == checkCells && !fieldCells.FreeOrBusy)
                    {
                        return false;
                    }

                }

            }

            foreach (var checkCells in checkPutList) // checking boarders
            {
                if (Math.Abs(checkCells.x) > SizeField || Math.Abs(checkCells.y) > SizeField)
                {
                    return false;
                }

            }

            return true;
        }

        internal void BusyField(List<Point> checkPutList, List<CellOfField> fieldCells) // set busing
        {
            foreach (var item in checkPutList)
            {
                for (int i = 0; i < fieldCells.Count; i++)
                {
                    if (item == fieldCells[i].Coordinat || (Math.Abs(item.x - fieldCells[i].Coordinat.x) == 1)
                       || (Math.Abs(item.y - fieldCells[i].Coordinat.y) == 1))
                    {
                        BusyCell(fieldCells[i].Coordinat, fieldCells);
                    }

                }

            }

        }

        internal List<Point> GetPutShipPoints(Point firstCoordinat, Point secondCoordinat, Ship ship) //only ship, who has more than 1 point
        {
            List<Point> checkPutList = new List<Point>();
            //if (secondCoordinat !=nul)
            if (secondCoordinat.x == firstCoordinat.x && (secondCoordinat.y == firstCoordinat.y)) //if ship contain only 1 point user must set 2 same coordinates
            {
                 checkPutList.Add(new Point() { x = firstCoordinat.x, y = firstCoordinat.y });
            }

            else if (secondCoordinat.x > firstCoordinat.x && (secondCoordinat.y == firstCoordinat.y)) // get direction for putting
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    checkPutList.Add(new Point() { x = firstCoordinat.x++, y = firstCoordinat.y });
                }

            } 
            else if (secondCoordinat.x < firstCoordinat.x && (secondCoordinat.y == firstCoordinat.y))
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    checkPutList.Add(new Point() { x = firstCoordinat.x--, y = firstCoordinat.y });
                }

            }
            else if (secondCoordinat.x == firstCoordinat.x && (secondCoordinat.y > firstCoordinat.y))
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    checkPutList.Add(new Point() { x = firstCoordinat.x, y = firstCoordinat.y++ });
                }

            }
            else if (secondCoordinat.x == firstCoordinat.x && (secondCoordinat.y < firstCoordinat.y))
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    checkPutList.Add(new Point() { x = firstCoordinat.x, y = firstCoordinat.y-- });
                }

            }

            else Console.WriteLine("can not put ship by angle");
            return checkPutList;
        }

        internal void PutShip(Point firstCoordinat, Point secondCoordinat, Ship ship, List<CellOfField> fieldCells)// main method
        {
            List<Point> listShipPoint = GetPutShipPoints(firstCoordinat, secondCoordinat, ship);
            if (!CheckPutList(listShipPoint, Cells))
            {
                foreach (var item in listShipPoint)
                {
                    ship.CeelsShip.Add(new CellOfShip(item) { Intact = true });
                }

                BusyField(listShipPoint, Cells);
                Ships.Add(ship);
            }


            else Console.WriteLine("Imposible position");
        }

        internal void ShipMove(Ship ship, Battlefield Cells)
        { }


        internal void ActionHandler(Point coordinat, Ship ship, Actions act = Actions.Attack)
        { }

        internal List<Ship> Sort(List<Ship> ships)
        {
            List<Point> pointsAllShips = new List<Point>();
            List<Ship> orderedListOfShip = new List<Ship>();
            foreach (var ship in ships) // combine all points of all ships
            {
                foreach (var cell in ship.CeelsShip)
                {
                    pointsAllShips.Add(cell.Coord);
                }   
                
            }
            var ordereDistanceList = pointsAllShips.OrderBy(u => Math.Sqrt(u.x * u.x + u.y * u.y)); // ordere all points of all ships by hypotenuse(distance from 0.0)
            foreach (var point in ordereDistanceList) // create new list of ship for ordered list of point
            {
                foreach (var ship in ships)
                {
                    foreach (var cell in ship.CeelsShip)
                    {
                        if (cell.Coord == point)
                            orderedListOfShip.Add(ship);
                    }

                }

            }

            return orderedListOfShip;
        }

        internal void Print(List<Ship> ships)
        {
            foreach (var item in ships)
            {
                Console.WriteLine($"Size of battlefield: {SizeField}, SHIP Type: {item.ToString()}, Length: {item.Size}, Speed: {item.Speed}, Strength: {item.Strength}");
            }

        }
    }
}

