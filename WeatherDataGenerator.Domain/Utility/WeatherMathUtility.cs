using MathNet.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;

namespace WeatherDataGenerator.Domain.Utility
{
    public static class WeatherMathUtility
    {
        /// <summary>
        /// Generates coordinates for a given range between -range and range.
        /// </summary>
        /// <param name="range"></param>
        /// <returns>A decimal.</returns>
        public static decimal GenerateEarthCoordinates(float range)
        {
            decimal decimalRange = (decimal)range;
            return (-decimalRange) + (Random.Shared.NextDecimal() * (decimalRange * 2));
        }

        /// <summary>
        /// Generate a normal distribution of values given an average and standard deviation with a sample size of n between 100 and 10000.
        /// </summary>
        /// <param name="avg"></param>
        /// <param name="std"></param>
        /// <param name="size"></param>
        /// <returns>An IEnumerable of floating point values.</returns>
        public static IEnumerable<float> GenerateGuassianDistribution(float avg, float std, int size = 5400)
        {
            size = Math.Clamp(size, 100, 10000);

            double[] distributions = new double[size];
            Normal.Samples(Random.Shared, distributions, avg, std);
            Sorting.Sort(distributions);

            return distributions.Select(x => (avg - std) < 0.0f ? (float)x : (float)Math.Abs(x));
        }

        /// <summary>
        /// Maps the current value for a given range to a target range of values
        /// </summary>
        /// <param name="current"></param>
        /// <param name="sourceMin"></param>
        /// <param name="sourceMax"></param>
        /// <param name="targetMin"></param>
        /// <param name="targetMax"></param>
        /// <returns>A floating point number constrained between a target range from a source range</returns>
        public static float Map(float current, float sourceMin, float sourceMax, float targetMin, float targetMax) => targetMin + (targetMax - targetMin) * ((current - sourceMin) / (sourceMax - sourceMin));
    }
}
