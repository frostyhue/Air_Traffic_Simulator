using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{
    [TestClass]
    public class AirstripUnitTest
    {
        [TestMethod]
        public void AirstripTest()
        {
            Airstrip test = new Airstrip("test", 1, 1, true, 1);
            Assert.AreEqual(test.Name, "test");
            Assert.AreEqual(test.CoordinateX, 1);
            Assert.AreEqual(test.CoordinateY, 1);
            Assert.AreEqual(test.IsFree, true);
            Assert.AreEqual(test.TakeOffDirection, 1);

        }

        [TestMethod]
        public void SwitchDirectionsTest()
        {
            Airstrip test = new Airstrip("test", 1, 1, true, 1);
            test.SwitchDirections();
            Assert.AreEqual(test.TakeOffDirection, 181);
        }


        [TestMethod]
        public void SetStatusTest()
        {
            //todo
        }

    }
}
