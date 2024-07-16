namespace WeatherDataGenerator.Domain.Models.Weather.WeatherLog
{
    public class WeatherLog : IWeatherLog
    {
        public string TimeStamp { get; set; } = string.Empty;
        public IEnumerable<IWeatherLogRecord> Records { get; set; } = [];

        public string ToCsv() => $"{TimeStamp}\n{string.Join("\n", Records.Select(r => r.ToCsv()))}\n";
        public string ToPlainText() => $"{TimeStamp}\n{string.Join("\n", Records.Select(r => r.ToPlainText()))}\n";
    }
}
