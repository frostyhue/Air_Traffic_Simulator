using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Air_Traffic_Simulation
{
    public class Cell
    {
        public int id;
        public int x, y;

        /// <summary>
        /// The side of the cell, width = height.
        /// </summary>
        public static int Width = 12;

        /// <summary>
        /// Marks the type of cell. Depending on this, min and max speeds and altitudes will be defined.
        /// </summary>
        public CellType Type { get; set; }

        public Cell(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Finds if the field contains point
        /// </summary>
        /// <param name="xmouse"></param>
        /// <param name="ymouse"></param>
        /// <returns></returns>
        public bool ContainsPoint(int xmouse, int ymouse)
        {
            if (xmouse < x + Width && ymouse < y + Width && xmouse >= x && ymouse >= y)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns point of the center of the cell
        /// </summary>
        /// <returns></returns>
        public Point GetCenter()
        {
            Point p = new Point(x + (Width / 2), y + (Width / 2));
            return p;
        }
    }
}
