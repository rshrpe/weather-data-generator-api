using Microsoft.AspNetCore.Http.HttpResults;
using WeatherDataGenerator.Domain.Services.DataGenerator;

namespace WeatherDataGenerator.Domain.Tests.Services
{
    [TestClass]
    public class WeatherDataGeneratorServiceTests
    {
        [TestMethod]
        public async Task GenerateByDays_WeatherLogFileIsInstanced_NotNull()
        {
            // Arrange
            var service = new WeatherDataGeneratorService(new WeatherDataAccess(), new FileDataAccess());

            // Act 
            var result = await service.GenerateByDays(7);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GenerateByDays_WeatherLogIsCorrectFormat_InstanceOfFileContentHttpResult()
        {
            // Arrange
            var service = new WeatherDataGeneratorService(new WeatherDataAccess(), new FileDataAccess());

            // Act 
            var result = await service.GenerateByDays(7);
            
            // Assert
            Assert.IsInstanceOfType<FileContentHttpResult>(result);
        }
    }
}
