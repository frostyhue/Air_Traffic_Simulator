using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{
    /// <summary>
    /// Summary description for SavingObjectsUnitTest
    /// </summary>
    [TestClass]
    public class SavingObjectsUnitTest
    {


        [TestMethod]
        public void SavingObjectsTest()
        {
            SavingObjects test1 = new SavingObjects();
            Assert.IsNull(test1.getAirplanes);
            Assert.IsNull(test1.getCheckpoints);


            List<Airplane> gp = new List<Airplane>();
            List<Airplane> ap = new List<Airplane>();
            List<Checkpoint> cp = new List<Checkpoint>();

            gp.Add(new Airplane("Test", 3, 3, 100, "t1"));
            ap.Add(new Airplane("Testt", 4, 2, 100, "t2"));
            cp.Add(new Checkpoint("cp", 3, 4, new Cell(1, 1, 1), new List<Checkpoint>(), new Airstrip("asname", 1, 1, true, 10), new List<Checkpoint>()));


            SavingObjects test2 = new SavingObjects(ap, gp, cp);
            Assert.AreEqual(1, test2.getAirplanes.Count);
            Assert.AreEqual(1, test2.getGroundplanes.Count);
            Assert.AreEqual(1, test2.getCheckpoints.Count);

        }

    }
}
