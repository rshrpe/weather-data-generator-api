using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.WeatherData
{
    public class WeatherDataAccess : IWeatherDataAccess
    {
        /// <summary>
        /// Generates an enumerable of weather logs for a given number of days. Logs are once per hours and therefore the days passed multiplied by 24. 
        /// </summary>
        /// <param name="days"></param>
        /// <returns>A data result containing either the enumerable of weather logs or the error.</returns>
        public DataResult<IEnumerable<IWeatherLog>> GenerateDataByDays(int days)
        {
            try
            {
                DateTime current = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
                return new DataResult<IEnumerable<IWeatherLog>>(Enumerable.Range(0, days * 24).Select((c) => new WeatherLog(current.AddHours(c))));
            }
            catch(Exception ex) 
            {
                Log.Error(ex, "Error - IWeatherDataAccess - GenerateDataByDays");
                return new DataResult<IEnumerable<IWeatherLog>>(Error: "There was an error attempting to generate the weather data.");
            }
        }
    }
}
