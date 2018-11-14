using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Traffic_Simulation
{
    public class WeatherConditions
    {
        private double probability = 1;

        //public double Humidity
        //{ get; set; }
        public double WindSpeed
        { get; set; }
        public WindDirection WindDirection
        { get; set; }
        public double Visibility
        { get; set; }
        public double TemperatureC
        { get; set; }
        public PrecipitationType PrecipitationType
        { get; set; }
        public double PrecipitationIntensity
        { get; set; }

        public double Probability
        {
            get { return probability; }
        }

        public WeatherConditions(double windSpeed, WindDirection windDirection, double temperatureC, double precipitationIntensity)
        {
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.TemperatureC = temperatureC;
            this.PrecipitationIntensity = precipitationIntensity;
        }

        /// <summary>
        /// Returns visibility
        /// </summary>
        /// <returns></returns>
        public double GetVisibility()
        {
            if (PrecipitationType != PrecipitationType.CLEAR)
            {
                if (PrecipitationIntensity >= 10 && PrecipitationIntensity <= 25)
                {
                    return Visibility = 80;
                }
                else if (PrecipitationIntensity >= 26 && PrecipitationIntensity <= 50)
                {
                    return Visibility = 50;
                }
                else if (PrecipitationIntensity > 50 && PrecipitationIntensity <=90)
                {
                    return Visibility = 10;
                }
                else { return 0; }
            }
            return 100;
        }

        /// <summary>
        /// Returns precipitation type
        /// </summary>
        /// <returns></returns>
        public PrecipitationType GetPrecipitationType()
        {
            if (TemperatureC > 0 && PrecipitationIntensity > 20)
            {
                return PrecipitationType = PrecipitationType.RAIN;
            }
            else if (TemperatureC <= 0 && PrecipitationIntensity <= 40)
            {
                return PrecipitationType = PrecipitationType.SNOW;
            }
            else if (TemperatureC <= 0 && PrecipitationIntensity > 40)
            {
                return PrecipitationType = PrecipitationType.HAIL;
            }
            return PrecipitationType.CLEAR;
        }

        /// <summary>
        /// Sets probability based on temperature, precipitation and wind speed
        /// </summary>
        public void SetProbability()
        {
            if (TemperatureC < 0)
            {
                this.probability -= (((TemperatureC * (-0.005)) * ((TemperatureC * (-0.005))) +
                               ((PrecipitationIntensity * (0.015)) * (PrecipitationIntensity * (0.015))) +
                               ((WindSpeed * (0.01)) * (WindSpeed * (0.01)) * 2)));
            }

            if (TemperatureC >= 0 && TemperatureC <= 29)
            {
                this.probability -= (((TemperatureC * (0.007)) * ((TemperatureC * (0.007))) +
                               ((PrecipitationIntensity * (0.005)) * (PrecipitationIntensity * (0.005))) +
                               ((WindSpeed * (0.008)) * (WindSpeed * (0.008)) * 2)));
            }

            if (TemperatureC >= 30 && TemperatureC <= 39)
            {
                this.probability -= (((TemperatureC * (0.013)) * ((TemperatureC * (0.013))) +
                               ((PrecipitationIntensity * (0.005)) * (PrecipitationIntensity * (0.005))) +
                               ((WindSpeed * (0.008)) * (WindSpeed * (0.008)) * 2)));
            }

            if (TemperatureC >= 40)
            {
                this.probability -= (((TemperatureC * (0.016)) * ((TemperatureC * (0.016))) +
                               ((PrecipitationIntensity * (0.005)) * (PrecipitationIntensity * (0.005))) +
                               ((WindSpeed * (0.008)) * (WindSpeed * (0.008)) * 2)));
            }

            if (this.probability < 0)
            {
                this.probability = 0;
            }
        }
    }
}
