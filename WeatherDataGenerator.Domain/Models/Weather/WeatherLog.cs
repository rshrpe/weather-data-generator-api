namespace WeatherDataGenerator.Domain.Models.Weather
{
    /// <summary>
    /// Represents a single log output constisting of a timestamp and enumerable representation of weather log records.
    /// Accepts a timestamp during instantiation. 
    /// </summary>
    /// <param name="timeStamp"></param>
    public class WeatherLog(DateTime timeStamp) : IWeatherLog
    {
        public string TimeStamp { get; } = timeStamp.ToString("yyyy-MM-dd HH:mm") + "UTC";
        public IEnumerable<IWeatherLog> WeatherLogRecords { get; } = GenerateWeatherLogRecords();
        private static IEnumerable<IWeatherLog> GenerateWeatherLogRecords() => Enumerable.Range(0, Random.Shared.Next(1, 12)).Select(c => new WeatherLogRecord());
        public string ToLog() => $"{TimeStamp}\n{string.Join("", WeatherLogRecords.Select(r => r.ToLog()))}";
    }
}
