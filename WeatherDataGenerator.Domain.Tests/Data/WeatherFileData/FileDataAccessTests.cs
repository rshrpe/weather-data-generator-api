
using WeatherDataGenerator.Domain.Data.GeneratorData.Weather;
using WeatherDataGenerator.Domain.Data.WeatherFileData;

namespace WeatherDataGenerator.Domain.Tests.Data.WeatherfileData
{
    [TestClass]
    public class FileDataTests
    {
        [TestMethod]
        public void GeneratePlainText_DataIsPresent_IsNotNull()
        {
            // Arrange
            var fileDataAccess = new FileData();
            var generatorData = new WeatherGeneratorData();
            var data = generatorData.Generate(1);

            // Act
            var result = fileDataAccess.GeneratePlainText(data.Data!);

            // Assert
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void GeneratePlainText_ErrorIsNotPresent_IsNull()
        {
            // Arrange
            var fileDataAccess = new FileData();
            var generatorData = new WeatherGeneratorData();
            var data = generatorData.Generate(1);

            // Act
            var result = fileDataAccess.GeneratePlainText(data.Data!);

            // Assert
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void GeneratePlainText_EmptyData_IsFalse()
        {
            // Arrange
            var fileDataAccess = new FileData();
            var generatorData = new WeatherGeneratorData();
            var data = generatorData.Generate(1);

            // Act
            var result = fileDataAccess.GeneratePlainText(data.Data!);

            // Assert
            Assert.IsFalse(!result.Data!.Any());
        }
    }
}
