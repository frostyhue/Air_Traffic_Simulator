using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{
    /// <summary>
    /// Summary description for CheckpointUnitTest
    /// </summary>
    [TestClass]
    public class CheckpointUnitTest
    {

        [TestMethod]
        public void CheckpointTest()
        {
            Cell c = new Cell(1, 1, 1);
            c.Type = CellType.BORDER;
            Checkpoint test = new Checkpoint("test", 1, 1, c, new List<Checkpoint>(), new Airstrip("ttest", 1,1, true, 1),new List<Checkpoint>() );
            Assert.AreEqual(test.Name, "test");
            Assert.AreEqual(test.CoordinateX, 1);
            Assert.AreEqual(test.CoordinateY, 1);

            Assert.AreEqual(test.MinSpeed, 500);
            Assert.AreEqual(test.MaxSpeed, 800);
            Assert.AreEqual(test.MaxAltitude, 7500);
            Assert.AreEqual(test.MinAltitude, 6500);

            Cell cc = new Cell(1, 1, 1);
            cc.Type = CellType.UNASSIGNED;
            Checkpoint test1 = new Checkpoint("test", 1, 1, cc, new List<Checkpoint>(), new Airstrip("ttest", 1, 1, true, 1), new List<Checkpoint>());
            Assert.AreEqual(test1.Name, "test");
            Assert.AreEqual(test1.CoordinateX, 1);
            Assert.AreEqual(test1.CoordinateY, 1);

            Assert.AreEqual(test1.MinSpeed, 330);
            Assert.AreEqual(test1.MaxSpeed, Int32.MaxValue);
            Assert.AreEqual(test1.MaxAltitude, 8000);
            Assert.AreEqual(test1.MinAltitude, 6100);

            Cell ccc = new Cell(1, 1, 1);
            ccc.Type = CellType.UPPER;
            Checkpoint test2 = new Checkpoint("test", 1, 1, ccc, new List<Checkpoint>(), new Airstrip("ttest", 1, 1, true, 1), new List<Checkpoint>());
            Assert.AreEqual(test2.Name, "test");
            Assert.AreEqual(test2.CoordinateX, 1);
            Assert.AreEqual(test2.CoordinateY, 1);

            Assert.AreEqual(test2.MinSpeed, 310);
            Assert.AreEqual(test2.MaxSpeed, 330);
            Assert.AreEqual(test2.MaxAltitude, 6100);
            Assert.AreEqual(test2.MinAltitude, 5800);

            Cell cccc = new Cell(1, 1, 1);
            cccc.Type = CellType.MIDDLE;
            Checkpoint test3 = new Checkpoint("test", 1, 1, cccc, new List<Checkpoint>(), new Airstrip("ttest", 1, 1, true, 1), new List<Checkpoint>());
            Assert.AreEqual(test3.Name, "test");
            Assert.AreEqual(test3.CoordinateX, 1);
            Assert.AreEqual(test3.CoordinateY, 1);

            Assert.AreEqual(test3.MinSpeed, 170);
            Assert.AreEqual(test3.MaxSpeed, 190);
            Assert.AreEqual(test3.MaxAltitude, 3100);
            Assert.AreEqual(test3.MinAltitude, 2800);

            Cell ccccc = new Cell(1, 1, 1);
            ccccc.Type = CellType.LOWER;
            Checkpoint test4 = new Checkpoint("test", 1, 1, ccccc, new List<Checkpoint>(), new Airstrip("ttest", 1, 1, true, 1), new List<Checkpoint>());
            Assert.AreEqual(test4.Name, "test");
            Assert.AreEqual(test4.CoordinateX, 1);
            Assert.AreEqual(test4.CoordinateY, 1);

            Assert.AreEqual(test4.MinSpeed, 150);
            Assert.AreEqual(test4.MaxSpeed, 170);
            Assert.AreEqual(test4.MaxAltitude, 1500);
            Assert.AreEqual(test4.MinAltitude, 1200);

            Cell cccccc = new Cell(1, 1, 1);
            cccccc.Type = CellType.FINAL;
            Checkpoint test5 = new Checkpoint("test", 1, 1, cccccc, new List<Checkpoint>(), new Airstrip("ttest", 1, 1, true, 1), new List<Checkpoint>());
            Assert.AreEqual(test5.Name, "test");
            Assert.AreEqual(test5.CoordinateX, 1);
            Assert.AreEqual(test5.CoordinateY, 1);

            Assert.AreEqual(test5.MinSpeed, 120);
            Assert.AreEqual(test5.MaxSpeed, 150);
            Assert.AreEqual(test5.MaxAltitude, 300);
            Assert.AreEqual(test5.MinAltitude, 500);
        }
    }
}
