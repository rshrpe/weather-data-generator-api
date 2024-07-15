namespace WeatherDataGenerator.Domain.Models.Base
{
    /// <summary>
    /// A model to represent how all data should be returned from a data layer to a service layer. 
    /// It includes a Data and Error property, where either should be set depending on the control flow of the data layer that populates it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Data"></param>
    /// <param name="Error"></param>
    public record DataResult<T>(T? Data = null, string? Error = null) where T : class;
}
