using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{
    /// <summary>
    /// Summary description for GridUnitTest
    /// </summary>
    [TestClass]
    public class GridUnitTest
    {

        [TestMethod]
        public void GridTest()
        {
            Grid test = new Grid(24, 24);
            Assert.AreEqual(test.ColumnsOfCells, 2);
            Assert.AreEqual(test.RowsOfCells, 2);
            
        }

        [TestMethod]
        public void GetCellTest()
        {
            Grid test = new Grid(24, 24);
            test.MakeGrid();
            Assert.IsNotNull(test.GetCell(12, 12));
        }


    }
}
