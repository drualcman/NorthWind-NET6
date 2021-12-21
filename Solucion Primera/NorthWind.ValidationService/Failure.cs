using NorthWind.Entities.Interfaces.Validation;

namespace NorthWind.ValidationService
{
    /// <summary>
    /// Simple wraper para las fallas
    /// </summary>
    public class Failure : SimpleValidationApi.Failure, IFailure
    {
        /// <summary>
        /// inizializar
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="errorMessage"></param>
        public Failure(string propertyName, string errorMessage) : base(propertyName, errorMessage)
        {
        }
    }
}