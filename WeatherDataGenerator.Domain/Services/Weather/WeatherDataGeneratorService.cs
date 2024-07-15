using Microsoft.AspNetCore.Http;
using WeatherDataGenerator.Domain.Data.FileData;
using WeatherDataGenerator.Domain.Data.WeatherData;

namespace WeatherDataGenerator.Domain.Services.DataGenerator
{
    public class WeatherDataGeneratorService(IWeatherDataAccess weatherDataAccess, IFileDataAccess fileDataAccess) : IWeatherDataGeneratorService
    {
        private readonly IWeatherDataAccess _weatherDataAccess = weatherDataAccess;
        private readonly IFileDataAccess _fileDataAccess = fileDataAccess;

        /// <summary>
        /// Service layer wrapper for generating an enumerable of weather log files for a given number of days. The data is generated into an in memory stream and a resulting file output. 
        /// </summary>
        /// <param name="days"></param>
        /// <returns>An IResult in the form of a file.</returns>
        public async Task<IResult> GenerateByDays(int days)
        {
            if (days < 1) return Results.BadRequest("The provided days must be 1 or greater.");
            if (days > 28) return Results.BadRequest("The provided days must be 28 or less.");

            var generatedData = _weatherDataAccess.GenerateDataByDays(days);
            if (generatedData.Error != null || generatedData.Data == null) return Results.BadRequest(generatedData.Error);           

            var bytestreamData = _fileDataAccess.GenerateByteStream(generatedData.Data);
            if (bytestreamData.Error != null || bytestreamData.Data == null) return Results.BadRequest(bytestreamData.Error);

            return Results.File(bytestreamData.Data, fileDownloadName: $"data.WIS");
        }
    }
}