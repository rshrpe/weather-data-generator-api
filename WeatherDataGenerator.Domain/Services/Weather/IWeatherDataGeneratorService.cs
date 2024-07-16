using Microsoft.AspNetCore.Http;

namespace WeatherDataGenerator.Domain.Services.DataGenerator
{
    public interface IWeatherDataGeneratorService
    {
        Task<IResult> GeneratePlainText(int days);
        Task<IResult> GenerateCsv(int days);
        Task<IResult> GenerateJson(int days);
    }
}
