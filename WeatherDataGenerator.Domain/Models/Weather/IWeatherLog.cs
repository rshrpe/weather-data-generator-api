﻿namespace WeatherDataGenerator.Domain.Models.Weather
{
    public interface IWeatherLog
    {
        public string ToPlainText();
        public string ToCsv();
    }
}