using Newtonsoft.Json;
using System.Text;
using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.WeatherFileData
{
    public class FileData : IFileData
    {
        public DataResult<byte[]> GenerateCsv(IEnumerable<IWeatherLog> weatherLogs)
        {
            try
            {
                List<byte> data = [];
                foreach (IWeatherLog log in weatherLogs)
                    data.AddRange(Encoding.ASCII.GetBytes(log.ToCsv()));
                return new DataResult<byte[]>([.. data]);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error - FileData - GenerateCsv");
                return new DataResult<byte[]>(Error: "Error converting generated data to a csv stream.");
            }
        }

        public DataResult<byte[]> GenerateJson(IEnumerable<IWeatherLog> weatherLogs)
        {
            try
            {
                return new DataResult<byte[]>(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(weatherLogs)));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error - FileData - GenerateJson");
                return new DataResult<byte[]>(Error: "Error converting generated data to a json stream.");
            }
        }

        public DataResult<byte[]> GeneratePlainText(IEnumerable<IWeatherLog> weatherLogs)
        {
            try
            {
                List<byte> data = [];
                foreach (IWeatherLog log in weatherLogs)
                    data.AddRange(Encoding.ASCII.GetBytes(log.ToPlainText()));
                return new DataResult<byte[]>([.. data]);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error - FileData - GeneratePlainText");
                return new DataResult<byte[]>(Error: "Error converting generated data to a plain text stream.");
            }
        }
    }
}
