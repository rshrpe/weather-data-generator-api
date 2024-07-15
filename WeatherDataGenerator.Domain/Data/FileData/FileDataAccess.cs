using System.Text;
using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Data.FileData
{
    public class FileDataAccess : IFileDataAccess
    {
        /// <summary>
        /// Generates an enumerable of classes and attempts to convert the data into an in memory byte stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns>A data result containing either the byte stream or the error.</returns>
        public DataResult<byte[]> GenerateByteStream(IEnumerable<IWeatherLog> values) 
        {
            try
            {
                List<byte> data = [];
                foreach (IWeatherLog value in values)
                    data.AddRange(Encoding.ASCII.GetBytes(value.ToLog()!));
                return new DataResult<byte[]>([..data]);
            }
            catch(Exception ex) 
            {
                Log.Error(ex, "Error - IFileDataAccess - GenerateByteStream");
                return new DataResult<byte[]>(Error: "Error converting generated data to a stream.");
            }
        }
    }
}
