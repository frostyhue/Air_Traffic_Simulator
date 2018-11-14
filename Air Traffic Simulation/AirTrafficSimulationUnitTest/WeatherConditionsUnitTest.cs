using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Air_Traffic_Simulation;

namespace AirTrafficSimulationUnitTest
{
    /// <summary>
    /// Summary description for WeatherConditionsUnitTest
    /// </summary>
    [TestClass]
    public class WeatherConditionsUnitTest
    {
        [TestMethod]
        public void WeatherConditionsTest()
        {
            WeatherConditions test = new WeatherConditions(1, WindDirection.EAST, 1, 1);
            Assert.AreEqual(test.WindSpeed, 1);
            Assert.AreEqual(test.WindDirection, WindDirection.EAST);
            Assert.AreEqual(test.TemperatureC, 1);
            Assert.AreEqual(test.PrecipitationIntensity, 1);
        }

        [TestMethod]
        public void GetVisibilityTest()
        {
            WeatherConditions test = new WeatherConditions(1, WindDirection.EAST, 1, 0);
            test.PrecipitationType = PrecipitationType.CLEAR;
            Assert.AreEqual(test.GetVisibility(), 100);

            WeatherConditions test1 = new WeatherConditions(1, WindDirection.EAST, 1, 15);
            test1.PrecipitationType = PrecipitationType.RAIN;
            Assert.AreEqual(test1.GetVisibility(), 80);

            WeatherConditions test2 = new WeatherConditions(1, WindDirection.EAST, 1, 30);
            test2.PrecipitationType = PrecipitationType.RAIN;
            Assert.AreEqual(test2.GetVisibility(), 50);

            WeatherConditions test3 = new WeatherConditions(1, WindDirection.EAST, 1, 80);
            test3.PrecipitationType = PrecipitationType.RAIN;
            Assert.AreEqual(test3.GetVisibility(), 10);

            WeatherConditions test4 = new WeatherConditions(1, WindDirection.EAST, 1, 100);
            test4.PrecipitationType = PrecipitationType.RAIN;
            Assert.AreEqual(test4.GetVisibility(), 0);
        }

        [TestMethod]
        public void GetPrecipitationTypeTest()
        {
            WeatherConditions test = new WeatherConditions(1, WindDirection.EAST, 1, 21);
            Assert.AreEqual(test.GetPrecipitationType(), PrecipitationType.RAIN);

            WeatherConditions test1 = new WeatherConditions(1, WindDirection.EAST, -1, 40);
            Assert.AreEqual(test1.GetPrecipitationType(), PrecipitationType.SNOW);

            WeatherConditions test2 = new WeatherConditions(1, WindDirection.EAST, -1, 41);
            Assert.AreEqual(test2.GetPrecipitationType(), PrecipitationType.HAIL);

            WeatherConditions test3 = new WeatherConditions(1, WindDirection.EAST, 1, 0);
            Assert.AreEqual(test3.GetPrecipitationType(), PrecipitationType.CLEAR);
        }

        [TestMethod]
        public void SetProbabilityTest()
        {
            //todo
        }


       
    }
}
