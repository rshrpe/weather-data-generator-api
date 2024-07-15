using Microsoft.AspNetCore.Http;

namespace WeatherDataGenerator.Domain.Services.DataGenerator
{
    public interface IWeatherDataGeneratorService
    {
        Task<IResult> GenerateByDays(int days);
    }
}
