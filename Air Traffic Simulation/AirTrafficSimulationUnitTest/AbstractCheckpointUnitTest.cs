using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{

    [TestClass]
    public class AbstractCheckpointUnitTest
    {
       
        [TestMethod]
        public void CalculateDistanceBetweenPointsTest()
        {
            Airplane test = new Airplane("Test", 3, 3, 100, "t1");
            Airplane test2 = new Airplane("Test2", 3, 3, 100, "t2");
            Assert.AreEqual(0, test.CalculateDistanceBetweenPoints(test2));
        }

        [TestMethod]
        public void CalculateTimeBetweenPointsTest()
        {
            Airplane test = new Airplane("Test", 4, 6, 100, "t1");
            Airplane test2 = new Airplane("Test2", 1, 2, 100, "t2");
            Assert.AreEqual(2.5, test.CalculateTimeBetweenPoints(test2));
        }

        [TestMethod]
        public void AddAllPossibleDestinationsTest()
        {
            //todo
        }

        [TestMethod]
        public void AddSingleDestinationTest()
        {
            Airplane test = new Airplane("Test", 4, 6, 100, "t1");
            Airplane test2 = new Airplane("Test2", 1, 2, 100, "t2");
            Airplane test3 = new Airplane("Test3", 4, 6, 100, "t3");
            test.AddSingleDestination(test2, 60);
            Assert.AreEqual(1, test.ReachableNodes.Keys.Count);
            test.AddSingleDestination(test3, 50);
            Assert.AreEqual(1, test.ReachableNodes.Keys.Count);
        }

        [TestMethod]
        public void GetLowestDistanceNodeTest()
        {
            HashSet<AbstractCheckpoint> testHash = new HashSet<AbstractCheckpoint>();
            Airplane hashvalue1 = new Airplane ("Test", 4, 6, 100, "t1");
            Airplane hashvalue2 = new Airplane("Test2", 15, 50, 100, "t2");
            hashvalue1.DistanceFromSource = 50;
            testHash.Add(hashvalue1);
            hashvalue2.DistanceFromSource = 100;
            testHash.Add(hashvalue2);

            Airplane ttest = new Airplane("TTest", 3, 9, 100, "tt");
            Assert.AreEqual(hashvalue1, ttest.GetLowestDistanceNode(testHash));
        }

        [TestMethod]
        public void CalculateMinDistanceTest()
        {
            Airplane test = new Airplane("Test", 4, 6, 100, "t1");
            Airplane test2 = new Airplane("Test2", 1, 2, 100, "t2");
            Airplane test3 = new Airplane("Test3", 1, 5, 100, "t3");
            test2.DistanceFromSource = 10;
            test3.DistanceFromSource = 20;
            LinkedList<AbstractCheckpoint> testlist = new LinkedList<AbstractCheckpoint>();
            testlist = test.CalculateMinDistance(test3, 5, test2);

            Assert.IsNotNull( testlist.Last);

            testlist = test.CalculateMinDistance(test3, 15, test2);

            Assert.IsNull(testlist);
        }


    }
}
