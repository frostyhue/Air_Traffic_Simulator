using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{
    [TestClass]
    public class AirplaneUnitTest
    {
        [TestMethod]
        public void AirplaneTest()
        {
            Airplane test = new Airplane("Test", 1, 1, 100, "t1");
            Assert.AreEqual(test.Name, "Test");
            Assert.AreEqual(test.CoordinateX, 1);
            Assert.AreEqual(test.CoordinateY, 1);
            Assert.AreEqual(test.SpeedInKts, 100);
            Assert.AreEqual(test.FlightNumber, "t1");
        }

        [TestMethod]
        public void MoveTowardsNextPointTest()
        {
            //todo
        }

        [TestMethod]
        public void calculateShortestPathTest()
        {
            //todo
        }


    }
}
