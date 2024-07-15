using WeatherDataGenerator.Domain.Data.FileData;
using WeatherDataGenerator.Domain.Models.Weather;

namespace WeatherDataGenerator.Domain.Tests.Data.FileData
{
    [TestClass]
    public class FileDataAccessTests
    {
        [TestMethod]
        public void GenerateByteStream_DataIsPresent_IsNotNull()
        {
            // Arrange
            var fileDataAccess = new FileDataAccess();
            var data = new List<WeatherLog> { new(DateTime.Now) };

            // Act
            var result = fileDataAccess.GenerateByteStream(data);

            // Assert
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void GenerateByteStream_ErrorIsNotPresent_IsNull()
        {
            // Arrange
            var fileDataAccess = new FileDataAccess();
            var data = new List<WeatherLog> { new(DateTime.Now) };

            // Act
            var result = fileDataAccess.GenerateByteStream(data);

            // Assert
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void GenerateByteStream_EmptyData_IsFalse()
        {
            // Arrange
            var fileDataAccess = new FileDataAccess();
            var data = new List<WeatherLog> {};

            // Act
            var result = fileDataAccess.GenerateByteStream(data);

            // Assert
            Assert.IsFalse(result.Data.Any());
        }
    }
}
