using Carter;
using WeatherDataGenerator.Domain.Data.WeatherFileData;
using WeatherDataGenerator.Domain.Data.GeneratorData;
using WeatherDataGenerator.Domain.Data.GeneratorData.Weather;
using WeatherDataGenerator.Domain.Services.DataGenerator;

namespace WeatherDataGenerator.API.Config
{
    public static class Services
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCarter();

            services.AddSerilog(serilog => serilog.ReadFrom.Configuration(configuration));

            services.ConfigureBaseServices();
            services.ConfigureDataAccess();
        }

        private static void ConfigureBaseServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherDataGeneratorService, WeatherDataGeneratorService>();
        }

        private static void ConfigureDataAccess(this IServiceCollection services)
        {
            services.AddKeyedScoped<IGeneratorData, WeatherGeneratorData>("weather");
            services.AddScoped<IFileData, FileData>();
        }
    }
}
