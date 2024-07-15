﻿using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WeatherDataGenerator.Domain.Services.DataGenerator;

namespace WeatherDataGenerator.Presentation.Weather
{
    public class WeatherModule : CarterModule
    {
        public WeatherModule() : base("/api/weather/") {}

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("generate/days", async ([FromServices] IWeatherDataGeneratorService dataGeneratorService, [FromQuery] int days = 7) => await dataGeneratorService.GenerateByDays(days));
        }
    }
}