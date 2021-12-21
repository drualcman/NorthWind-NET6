namespace SimpleValidationApi
{
    /// <summary>
    /// Representar un fallo de validacion
    /// </summary>
    public class Failure
    {
        /// <summary>
        /// Propiedad
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Error mensaje
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// contrstructor que recibe el error
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="errorMessage"></param>
        public Failure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Sobre escribir el tostring para falicitar el mensaje
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{PropertyName}: {ErrorMessage}";
        }
    }
}