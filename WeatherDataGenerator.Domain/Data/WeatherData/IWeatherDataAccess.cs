using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.WeatherData
{
    public interface IWeatherDataAccess
    {
        DataResult<IEnumerable<IWeatherLog>> GenerateDataByDays(int days);
    }
}