using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;
using WeatherDataGenerator.Domain.Models.Weather.WeatherLog;
using WeatherDataGenerator.Domain.Models.Weather.WeatherLogRecord;
using WeatherDataGenerator.Domain.Utility;

namespace WeatherDataGenerator.Domain.Data.GeneratorData.Weather
{
    public class WeatherGeneratorData : IGeneratorData
    {
        public DataResult<IEnumerable<IWeatherLog>> Generate(int days)
        {
            try
            {
                IEnumerable<string> windDirections = ["N", "E", "S", "W", "NE", "SE", "SW", "NW"];

                DateTime current = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
                IEnumerable<IWeatherLog> results = Enumerable.Range(0, days * 24).Select(hour =>
                {
                    return new WeatherLog()
                    {
                        TimeStamp = current.AddHours(hour).ToString("yyyy-MM-dd HH:mm") + "UTC",
                        Records = Enumerable.Range(0, Random.Shared.Next(3, 9)).Select(r => {
                            decimal latitude = WeatherMathUtility.GenerateEarthCoordinates(90.0f);
                            IEnumerable<float> windspeedDistributions = WeatherMathUtility.GenerateGuassianDistribution(6.0f, 2.0f);

                            return new WeatherLogRecord()
                            {
                                Longitude = WeatherMathUtility.GenerateEarthCoordinates(180.0f).ToString("N6"),
                                Latitude = latitude.ToString("N6"),
                                Temperature = WeatherMathUtility.Map((float)Math.Abs(latitude), 0.0f, 90.0f, 45.0f, -60.0f).ToString("N1"),
                                TemperatureUnit = "C",
                                WindSpeed = windspeedDistributions.ElementAt(Random.Shared.Next(0, windspeedDistributions.Count())).ToString("N1"),
                                WindSpeedUnit = "km/h",
                                WindDirection = windDirections.ElementAt(Random.Shared.Next(0, windDirections.Count())),
                                Precipitation = Random.Shared.Next(0, 100).ToString(),
                                Humidity = Random.Shared.Next(0, 100).ToString()
                            };
                        })
                    };
                });

                return new DataResult<IEnumerable<IWeatherLog>>(results);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error - WeatherGeneratorData - Generate");
                return new DataResult<IEnumerable<IWeatherLog>>(Error: "Failed to generate weather data.");
            }
        }
    }
}
