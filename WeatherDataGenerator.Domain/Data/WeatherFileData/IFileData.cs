using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.WeatherFileData
{
    public interface IFileData
    {
        DataResult<byte[]> GeneratePlainText(IEnumerable<IWeatherLog> weatherLogs);
        DataResult<byte[]> GenerateCsv(IEnumerable<IWeatherLog> weatherLogs);
        DataResult<byte[]> GenerateJson(IEnumerable<IWeatherLog> weatherLogs);
    }
}
