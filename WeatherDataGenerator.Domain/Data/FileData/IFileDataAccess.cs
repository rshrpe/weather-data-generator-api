using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.FileData
{
    public interface IFileDataAccess
    {
        DataResult<byte[]> GenerateByteStream(IEnumerable<IWeatherLog> values);
    }
}
