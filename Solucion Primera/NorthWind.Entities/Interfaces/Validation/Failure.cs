namespace NorthWind.Entities.Interfaces.Validation
{
    public class Failure : IFailure
    {
        public string PropertyName { get; }

        public string ErrorMessage { get; }

        public Failure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
