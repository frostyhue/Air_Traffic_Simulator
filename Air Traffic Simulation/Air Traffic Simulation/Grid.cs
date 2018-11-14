using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Air_Traffic_Simulation
{
    public class Grid
    {
        public List<Cell> listOfCells = new List<Cell>();
        private int xs = 0, ys = 0, id = 1;

        /// <summary>
        /// The number of columns the grid is going to have.
        /// </summary>
        public int ColumnsOfCells { get; private set; }

        /// <summary>
        /// The number of rows the grid is going to have.
        /// </summary>
        public int RowsOfCells { get; private set; }

        /// <summary>
        /// The total number of cells the grid is going to have.
        /// </summary>
        private readonly int totalNumberOfCells;

        /// <summary>
        /// The amount of pixels which corresponds on a nautical mile
        /// per our grid, when we are considering horizontal movement.
        /// </summary>
        public static double PixelsPerMileHorizontally;

        /// <summary>
        /// The amount of pixels which corresponds on a nautical mile
        /// per our grid, when we are considering vertical movement.
        /// </summary>
        public static double PixelsPerMileVertically;

        public Grid(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.ColumnsOfCells = pictureBoxWidth / Cell.Width;
            this.RowsOfCells = pictureBoxHeight / Cell.Width;
            this.totalNumberOfCells = this.ColumnsOfCells * this.RowsOfCells;

            //that's the diameter of the space covered between the inner sides
            //of the BORDER cells; our grid is based on real life numbers and in real life
            //this outermost zone starts from 20 miles away from the airport - thus, the total
            //diameter of our airspace is 40 miles
            int diameterOfAirspaceInMiles = 40;

            int diameterOfAirspaceInPixelsHorizontally = (ColumnsOfCells - 1) * Cell.Width;

            int diameterOfAirspaceInPixelsVertically = (RowsOfCells - 1) * Cell.Width;

            PixelsPerMileHorizontally = (double) diameterOfAirspaceInPixelsHorizontally / diameterOfAirspaceInMiles;
            PixelsPerMileVertically = (double) diameterOfAirspaceInPixelsVertically / diameterOfAirspaceInMiles;
        }

        /// <summary>
        /// Returns cell of the grid
        /// </summary>
        /// <param name="xmouse"></param>
        /// <param name="ymouse"></param>
        /// <returns></returns>
        public Cell GetCell(int xmouse, int ymouse)
        {
            foreach (Cell c in this.listOfCells)
            {
                if (c.x == xmouse && c.y == ymouse)
                {
                    return c;
                }
            }

            return null;
        }

        /// <summary>
        /// This method will paint a grid with different types of zones
        /// </summary>
        public void MakeGrid()
        {
            Cell c;
            for (int i = 1; i <= totalNumberOfCells; i++)
            {
                if (i % ColumnsOfCells != 0)
                {
                    c = new Cell(id, xs, ys);
                    listOfCells.Add(c);
                    xs = xs + Cell.Width;
                    id = id + 1;
                }
                else
                {
                    c = new Cell(id, xs, ys);
                    listOfCells.Add(c);
                    xs = 0;
                    ys = ys + Cell.Width;
                    id = id + 1;
                }

                assignZoneToCell(c);
            }
        }

        /// <summary>
        /// Assigns zone to the cell
        /// </summary>
        /// <param name="c"></param>
        private void assignZoneToCell(Cell c)
        {
            if ((c.id % ColumnsOfCells >= Math.Floor(0.9 * ColumnsOfCells / 2)) &&
                (c.id % ColumnsOfCells <= ColumnsOfCells - Math.Floor(0.9 * ColumnsOfCells / 2)) &&
                (c.id > (Math.Floor(0.9 * RowsOfCells / 2) - 1) * ColumnsOfCells) &&
                (c.id < (RowsOfCells - Math.Floor(0.9 * RowsOfCells / 2)) * ColumnsOfCells))
            {
                c.Type = CellType.FINAL;
            }
            else if ((c.id % ColumnsOfCells >= Math.Floor(0.7 * ColumnsOfCells / 2)) &&
                     (c.id % ColumnsOfCells <= ColumnsOfCells - Math.Floor(0.7 * ColumnsOfCells / 2)) &&
                     (c.id > Math.Floor((0.7 * RowsOfCells / 2) - 1) * ColumnsOfCells) &&
                     (c.id < (RowsOfCells - Math.Floor(0.7 * RowsOfCells / 2)) * ColumnsOfCells))
            {
                c.Type = CellType.LOWER;
            }
            else if ((c.id % ColumnsOfCells >= Math.Floor(0.4 * ColumnsOfCells / 2)) &&
                     (c.id % ColumnsOfCells <= ColumnsOfCells - Math.Floor(0.4 * ColumnsOfCells / 2)) &&
                     (c.id > Math.Floor((0.4 * RowsOfCells / 2) - 1) * ColumnsOfCells) &&
                     (c.id < (RowsOfCells - Math.Floor(0.4 * RowsOfCells / 2)) * ColumnsOfCells))
            {
                c.Type = CellType.MIDDLE;
            }
            else if (c.id <= this.ColumnsOfCells)
            {
                c.Type = CellType.BORDER;
            }
            else if (c.id % this.ColumnsOfCells == 1)
            {
                c.Type = CellType.BORDER;
            }
            else if (c.id % this.ColumnsOfCells == 0)
            {
                c.Type = CellType.BORDER;
            }
            else if (c.id > this.ColumnsOfCells * (this.RowsOfCells - 1))
            {
                c.Type = CellType.BORDER;
            }
            else
            {
                c.Type = CellType.UPPER;
            }
        }
    }
}