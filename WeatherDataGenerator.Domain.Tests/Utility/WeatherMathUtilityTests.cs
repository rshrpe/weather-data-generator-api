using WeatherDataGenerator.Domain.Utility;

namespace WeatherDataGenerator.Domain.Tests.Utility
{
    [TestClass]
    public class WeatherMathUtilityTests
    {
        [TestMethod]
        public void GenerateGuassianDistribution_DefaultArrayLengthCorrect_AreEqual()
        {
            // Arrange
            var avg = 50.0f;
            var std = 10.0f;
            var standardCount = 5400;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std);

            // Assert
            Assert.AreEqual(result.Count(), standardCount);
        }

        [TestMethod]
        public void GenerateGuassianDistribution_ArrayLengthCorrect_AreEqual()
        {
            // Arrange
            var avg = 50.0f;
            var std = 10.0f;
            var standardCount = 5400;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std);

            // Assert
            Assert.AreEqual(result.Count(), standardCount);
        }

        [TestMethod]
        public void GenerateGuassianDistribution_MinArrayLengthCorrect_AreEqual()
        {
            // Arrange
            var avg = 50.0f;
            var std = 10.0f;
            var standardCount = 1;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std, standardCount);

            // Assert
            Assert.AreEqual(result.Count(), 100);
        }

        [TestMethod]
        public void GenerateGuassianDistribution_MaxArrayLengthCorrect_AreEqual()
        {
            // Arrange
            var avg = 50.0f;
            var std = 10.0f;
            var standardCount = 120000;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std, standardCount);

            // Assert
            Assert.AreEqual(result.Count(), 10000);
        }

        [TestMethod]
        public void GenerateGuassianDistribution_ValuesInCorrectLowerRange_IsFalse()
        {
            // Arrange
            var avg = 50.0f;
            var std = 2.0f;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std);

            // Assert
            Assert.IsFalse(result.Any(x => x < 40.0f));
        }

        [TestMethod]
        public void GenerateGuassianDistribution_ValuesInCorrectHigherRange_IsFalse()
        {
            // Arrange
            var avg = 50.0f;
            var std = 2.0f;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std);

            // Assert
            Assert.IsFalse(result.Any(x => x > 60.0f));
        }

        [TestMethod]
        public void GenerateGuassianDistribution_ContainNegativeValues_IsTrue()
        {
            // Arrange
            var avg = 1.0f;
            var std = 10.0f;

            // Act
            var result = WeatherMathUtility.GenerateGuassianDistribution(avg, std);

            // Assert
            Assert.IsTrue(result.Any(x => x < 0.0f));
        }

        [TestMethod]
        public void Map_LowValueIsCorrectlyMapped_AreEqual()
        {
            // Arrange
            var current = 0.0f;

            // Act
            var result = WeatherMathUtility.Map(current, 0.0f, 100.0f, -200.0f, 400.0f);

            // Assert
            Assert.AreEqual(result, -200.0f);
        }

        [TestMethod]
        public void Map_HighValueIsCorrectlyMapped_AreEqual()
        {
            // Arrange
            var current = 100.0f;

            // Act
            var result = WeatherMathUtility.Map(current, 0.0f, 100.0f, -200.0f, 200.0f);

            // Assert
            Assert.AreEqual(result, 200.0f);
        }
    }
}
