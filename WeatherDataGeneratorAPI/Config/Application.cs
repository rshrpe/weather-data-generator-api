using Carter;

namespace WeatherDataGenerator.API.Config
{
    public static class Application
    {
        public static void ConfigureApplication(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.MapCarter(); 
        }
    }
}
