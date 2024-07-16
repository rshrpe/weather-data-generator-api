using WeatherDataGenerator.Domain.Data.WeatherData;
using WeatherDataGenerator.Domain.Models.Base;
using WeatherDataGenerator.Domain.Models.Weather.WeatherLog;

namespace WeatherDataGenerator.Domain.Tests.Data.WeatherData
{
    [TestClass]
    public class WeatherDataAccessTests
    {
        [TestMethod]
        public void GenerateDataByDays_DataIsPresent_IsNotNull()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void GenerateDataByDays_ErrorIsNotPresent_IsNull()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void GenerateDataByDays_GeneratesCorrectHourlyLogAmount_AreEqual()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.AreEqual(result.Data.Count(), days * 24);
        }

        [TestMethod]
        public void GenerateDataByDays_WeatherLogsContainWeatherRecords_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).WeatherLogRecords.Any()));
        }

        [TestMethod]
        public void GenerateDataByDays_LongitudeValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Longitude.GetType() == typeof(decimal));
        }

        [TestMethod]
        public void GenerateDataByDays_LongitudeValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Longitude.ToString().Split('.')[1].Count() == 6);
        }

        [TestMethod]
        public void GenerateDataByDays_LongitudeValuesAreWithinRange_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).WeatherLogRecords.All(r => ((EarthquakeLogRecord)r).Longitude > -180 && ((EarthquakeLogRecord)r).Longitude < 180)));
        }

        [TestMethod]
        public void GenerateDataByDays_LatitudeValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Latitude.GetType() == typeof(decimal));
        }

        [TestMethod]
        public void GenerateDataByDays_LatitudeValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Latitude.ToString().Split('.')[1].Count() == 6);
        }

        [TestMethod]
        public void GenerateDataByDays_LatitudeValuesAreWithinRange_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).WeatherLogRecords.All(r => ((EarthquakeLogRecord)r).Latitude > -90 && ((EarthquakeLogRecord)r).Latitude < 90)));
        }

        [TestMethod]
        public void GenerateDataByDays_TemperatureValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Temperature.ToString().Split('.')[1].Count() == 1);
        }

        [TestMethod]
        public void GenerateDataByDays_TemperatureValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Temperature.GetType() == typeof(float));
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedValueHasCorrectDecimalPlaces_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Windspeed.ToString().Split('.')[1].Count() == 1);
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedValueIsCorrectType_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).Windspeed.GetType() == typeof(float));
        }

        [TestMethod]
        public void GenerateDataByDays_TemperatureHasCorrectUnit_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).TemperatureUnit == "C");
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedHasCorrectUnit_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).WindspeedUnit == "km/h");
        }

        [TestMethod]
        public void GenerateDataByDays_WindspeedDirectionIsValid_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;
            string[] WindSpeeds = ["N", "E", "S", "W", "NE", "SE", "SW", "NW"];

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(WindSpeeds.Contains(((EarthquakeLogRecord)((WeatherLog)result.Data.First()).WeatherLogRecords.First()).WindspeedDirection));
        }

        [TestMethod]
        public void GenerateDataByDays_PrecipitationValuesAreWithinRange_IsTrue()
        {
            // Arrange
            var weatherDataAccess = new WeatherDataAccess();
            var days = 7;

            // Act
            var result = weatherDataAccess.GenerateDataByDays(days);

            // Assert
            Assert.IsTrue(result.Data.All(x => ((WeatherLog)x).WeatherLogRecords.All(r => ((EarthquakeLogRecord)r).Precipitation >= 0 && ((EarthquakeLogRecord)r).Precipitation <= 100)));
        }
    }
}
