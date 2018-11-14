using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;
using System.Drawing;

namespace AirTrafficSimulationUnitTest
{

    [TestClass]
    public class CellUnitTest
    {
        
        [TestMethod]
        public void CellTest()
        {
            Cell test = new Cell(1, 1, 1);
            Assert.AreEqual(test.id, 1);
            Assert.AreEqual(test.x, 1);
            Assert.AreEqual(test.y, 1);
        }

        [TestMethod]
        public void ContainsPointTest()
        {
            Cell test = new Cell(1, 1, 1);
            Assert.IsTrue(test.ContainsPoint(5, 5));
            Assert.IsFalse(test.ContainsPoint(100, 100));
        }

        [TestMethod]
        public void GetCenterTest()
        {
            Cell test = new Cell(10, 10, 10);
            Point testPoint = test.GetCenter();
            Assert.AreEqual(testPoint.X, 16);
            Assert.AreEqual(testPoint.Y, 16);
        }



    }
}
