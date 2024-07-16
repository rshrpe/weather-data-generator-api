using Microsoft.AspNetCore.Http.HttpResults;
using WeatherDataGenerator.Domain.Data.GeneratorData.Weather;
using WeatherDataGenerator.Domain.Data.WeatherFileData;
using WeatherDataGenerator.Domain.Services.DataGenerator;

namespace WeatherDataGenerator.Domain.Tests.Services
{
    [TestClass]
    public class WeatherDataGeneratorServiceTests
    {
        [TestMethod]
        public async Task GeneratePlainText_WeatherLogFileIsInstanced_NotNull()
        {
            // Arrange
            var service = new WeatherDataGeneratorService(new WeatherGeneratorData(), new FileData());

            // Act 
            var result = await service.GeneratePlainText(7);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GeneratePlainText_WeatherLogIsCorrectFormat_InstanceOfFileContentHttpResult()
        {
            // Arrange
            var service = new WeatherDataGeneratorService(new WeatherGeneratorData(), new FileData());

            // Act 
            var result = await service.GeneratePlainText(7);
            
            // Assert
            Assert.IsInstanceOfType<FileContentHttpResult>(result);
        }
    }
}
