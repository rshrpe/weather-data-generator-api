using MathNet.Numerics;
using MathNet.Numerics.Random;
using WeatherDataGenerator.Domain.Utility;

namespace WeatherDataGenerator.Domain.Models.Weather
{
    /// <summary>
    /// Represents a single record of weather data. This includes Longitude, Latitude, Temperature, Temperature Unit, Windspeed, Windspeed Unit, Windspeed Direction and Precipitation
    /// </summary>
    public class WeatherLogRecord : IWeatherLog
    {
        public decimal Longitude { get; } = GenerateCoordinates(180.0f).Round(6);
        public decimal Latitude { get; } = GenerateCoordinates(90.0f).Round(6);
        public float Temperature { get; } = 0.0f;
        public string TemperatureUnit { get; } = "C";
        public float Windspeed { get; } = GenerateWindspeed().Round(1);
        public string WindspeedUnit { get; } = "km/h";
        public string WindspeedDirection { get; } = WindSpeeds.ElementAt(Random.Shared.Next(0, WindSpeeds.Length - 1));
        public int Precipitation { get; } = Random.Shared.Next(0, 100);

        public WeatherLogRecord()
        {
            Temperature = GenerateTemperature(Latitude).Round(1);
        }

        private static readonly string[] WindSpeeds = ["N", "E", "S", "W", "NE", "SE", "SW", "NW"];
        private static readonly float[] WindspeedDistributions = MathUtility.GenerateGuassianDistribution(6.0f, 5.0f).ToArray();

        private static decimal GenerateCoordinates(float range) {
            decimal decimalRange = (decimal)range;
            return (-decimalRange) + (Random.Shared.NextDecimal() * (decimalRange * 2));
        }

        private static float GenerateTemperature(decimal latitude) => MathUtility.Map((float)Math.Abs(latitude), 0.0f, 90.0f, 45.0f, -60.0f);        

        private static float GenerateWindspeed() => WindspeedDistributions.ElementAt(Random.Shared.Next(0, WindspeedDistributions.Length -1));        
        public string ToLog() => $"{Longitude:N6}\t{Latitude:N6}\t{Temperature:N1}\t{TemperatureUnit}\t{Windspeed:N1}\t{WindspeedUnit}\t{WindspeedDirection}\t{Precipitation}\n";
    }
}
