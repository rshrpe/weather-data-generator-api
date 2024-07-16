using WeatherDataGenerator.Domain.Data.GeneratorData.Weather;
using WeatherDataGenerator.Domain.Models.Weather.WeatherLog;
using WeatherDataGenerator.Domain.Models.Weather.WeatherLogRecord;

namespace WeatherDataGenerator.Domain.Tests.Data.GeneratorData.Weather
{
    [TestClass]
    public class WeatherDataAccessTests
    {
        [TestMethod]
        public void GenerateDataByDays_DataIsPresent_IsNotNull()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void GenerateDataByDays_ErrorIsNotPresent_IsNull()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void GenerateDataByDays_GeneratesCorrectHourlyLogAmount_AreEqual()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.AreEqual(result.Data.Count(), days * 24);
        }

        [TestMethod]
        public void GenerateDataByDays_WeatherLogsContainWeatherRecords_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).Records.Any()));
        }

        [TestMethod]
        public void GenerateDataByDays_LongitudeValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).Longitude.GetType() == typeof(string));
        }

        [TestMethod]
        public void GenerateDataByDays_LongitudeValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).Longitude.ToString().Split('.')[1].Count() == 6);
        }

        [TestMethod]
        public void GenerateDataByDays_LongitudeValuesAreWithinRange_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).Records.All(r => decimal.Parse(((WeatherLogRecord)r).Longitude) > -180 && decimal.Parse(((WeatherLogRecord)r).Longitude) < 180)));
        }

        [TestMethod]
        public void GenerateDataByDays_LatitudeValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).Latitude.GetType() == typeof(string));
        }

        [TestMethod]
        public void GenerateDataByDays_LatitudeValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).Latitude.ToString().Split('.')[1].Count() == 6);
        }

        [TestMethod]
        public void GenerateDataByDays_LatitudeValuesAreWithinRange_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).Records.All(r => decimal.Parse(((WeatherLogRecord)r).Latitude) > -90 && decimal.Parse(((WeatherLogRecord)r).Latitude) < 90)));
        }

        [TestMethod]
        public void GenerateDataByDays_TemperatureValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).Temperature.ToString().Split('.')[1].Count() == 1);
        }

        [TestMethod]
        public void GenerateDataByDays_TemperatureValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).Temperature.GetType() == typeof(string));
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).WindSpeed.Split('.')[1].Count() == 1);
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).WindSpeed.GetType() == typeof(string));
        }

        [TestMethod]
        public void GenerateDataByDays_TemperatureHasCorrectUnit_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).TemperatureUnit == "C");
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedHasCorrectUnit_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).WindSpeedUnit == "km/h");
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedDirectionIsValid_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;
            string[] WindSpeeds = ["N", "E", "S", "W", "NE", "SE", "SW", "NW"];

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(WindSpeeds.Contains(((WeatherLogRecord)((WeatherLog)result.Data.First()).Records.First()).WindDirection));
        }

        [TestMethod]
        public void GenerateDataByDays_PrecipitationValuesAreWithinRange_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherGeneratorData();
            var days = 7;

            // Act
            var result = weatherDataAccess.Generate(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).Records.All(r => int.Parse(((WeatherLogRecord)r).Precipitation) >= 0 && int.Parse(((WeatherLogRecord)r).Precipitation) <= 100)));
        }
    }
}
