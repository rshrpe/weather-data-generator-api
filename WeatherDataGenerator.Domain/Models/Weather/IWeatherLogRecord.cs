namespace WeatherDataGenerator.Domain.Models.Weather
{
    public interface IWeatherLogRecord 
    {
        public string ToPlainText();
        public string ToCsv();
    }
}
