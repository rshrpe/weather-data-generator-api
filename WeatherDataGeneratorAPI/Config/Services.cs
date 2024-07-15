using Carter;
using WeatherDataGenerator.Domain.Data.FileData;
using WeatherDataGenerator.Domain.Data.WeatherData;
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
            services.AddScoped<IWeatherDataAccess, WeatherDataAccess>();
            services.AddScoped<IFileDataAccess, FileDataAccess>();
        }
    }
}
