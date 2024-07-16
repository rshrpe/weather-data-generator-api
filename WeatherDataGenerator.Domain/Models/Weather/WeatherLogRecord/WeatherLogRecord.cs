namespace WeatherDataGenerator.Domain.Models.Weather.WeatherLogRecord
{
    public class WeatherLogRecord : IWeatherLogRecord
    {
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Temperature { get; set; } = string.Empty;
        public string TemperatureUnit { get; set; } = string.Empty;
        public string WindSpeed { get; set; } = string.Empty;
        public string WindSpeedUnit { get; set; } = string.Empty;
        public string WindDirection { get; set; } = string.Empty;
        public string Precipitation { get; set; } = string.Empty;

        public string ToCsv() => $"{Longitude},{Latitude},{Temperature},{TemperatureUnit},{WindSpeed},{WindSpeedUnit},{WindDirection},{Precipitation}";

        public string ToPlainText() => $"{Longitude}\t{Latitude}\t{Temperature}\t{TemperatureUnit}\t{WindSpeed}\t{WindSpeedUnit}\t{WindDirection}\t{Precipitation}";
    }
}
