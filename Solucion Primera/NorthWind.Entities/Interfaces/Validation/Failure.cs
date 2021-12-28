namespace NorthWind.Entities.Interfaces.Validation
{
    /// <summary>
    /// clase para implementar un fallo
    /// </summary>
    public class Failure : IFailure
    {
        /// <summary>
        /// propiedad que fallo
        /// </summary>
        public string PropertyName { get; }
        /// <summary>
        /// mensaje que con la descripcion del error
        /// </summary>
        public string ErrorMessage { get; }
        /// <summary>
        /// contruir un fallo
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="errorMessage"></param>
        public Failure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
