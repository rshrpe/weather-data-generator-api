using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WeatherDataGenerator.Domain.Data.WeatherFileData;
using WeatherDataGenerator.Domain.Data.GeneratorData;
using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Services.DataGenerator
{
    public class WeatherDataGeneratorService([FromKeyedServices("weather")] IGeneratorData generatorData, IFileData fileData) : IWeatherDataGeneratorService
    {
        private readonly IGeneratorData _generatorData = generatorData;
        private readonly IFileData _fileData = fileData;

        /// <summary>
        /// Service layer wrapper for generating an enumerable of weather log files for a given number of days. The data is generated into an in memory stream and a resulting file output. 
        /// </summary>
        /// <param name="days"></param>s
        /// <returns>An IResult in the form of a file.</returns>
        public async Task<IResult> GeneratePlainText(int days)
        {
            if (days < 1) return Results.BadRequest("The provided days must be 1 or greater.");
            if (days > 28) return Results.BadRequest("The provided days must be 28 or less.");

            DataResult<IEnumerable<IWeatherLog>> generatedData = generatorData.Generate(days);
            if (generatedData.Error != null || generatedData.Data == null) return Results.BadRequest(generatedData.Error);

            DataResult<byte[]> fileData = _fileData.GeneratePlainText(generatedData.Data);
            if (fileData.Error != null || fileData.Data == null) return Results.BadRequest(fileData.Error);

            return Results.File(fileData.Data, fileDownloadName: "data.WIS");
        }

        public async Task<IResult> GenerateCsv(int days)
        {
            if (days < 1) return Results.BadRequest("The provided days must be 1 or greater.");
            if (days > 28) return Results.BadRequest("The provided days must be 28 or less.");

            DataResult<IEnumerable<IWeatherLog>> generatedData = generatorData.Generate(days);
            if (generatedData.Error != null || generatedData.Data == null) return Results.BadRequest(generatedData.Error);

            DataResult<byte[]> fileData = _fileData.GenerateCsv(generatedData.Data);
            if (fileData.Error != null || fileData.Data == null) return Results.BadRequest(fileData.Error);

            return Results.File(fileData.Data, fileDownloadName: "data.csv");
        }

        public async Task<IResult> GenerateJson(int days)
        {
            if (days < 1) return Results.BadRequest("The provided days must be 1 or greater.");
            if (days > 28) return Results.BadRequest("The provided days must be 28 or less.");

            DataResult<IEnumerable<IWeatherLog>> generatedData = generatorData.Generate(days);
            if (generatedData.Error != null || generatedData.Data == null) return Results.BadRequest(generatedData.Error);

            DataResult<byte[]> fileData = _fileData.GenerateJson(generatedData.Data);
            if (fileData.Error != null || fileData.Data == null) return Results.BadRequest(fileData.Error);

            return Results.File(fileData.Data, fileDownloadName: "data.json");
        }
    }
}