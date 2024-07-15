using WeatherDataGenerator.API.Config;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.ConfigureServices(builder.Configuration);

    var app = builder.Build();
    app.ConfigureApplication();

    Log.Information("Application starting.");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start.");
}
finally
{
    Log.Information("Application shutting down.");
}