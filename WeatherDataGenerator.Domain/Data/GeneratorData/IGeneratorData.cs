using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.GeneratorData
{
    public interface IGeneratorData
    {
        DataResult<IEnumerable<IWeatherLog>> Generate(int days);
    }
}
