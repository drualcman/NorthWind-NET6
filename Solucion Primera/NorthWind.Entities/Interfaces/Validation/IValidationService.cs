namespace NorthWind.Entities.Interfaces.Validation
{
    /// <summary>
    /// Define quien tiene que implementar el validador
    /// Este es el servicio que debe validar. Ej. FluentValidation
    /// </summary>
    public interface IValidationService<T> : IValidator<T>
    {
    }
}
