namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Envio de correos electronicos
    /// </summary>
    public interface IMailService
    {
        ValueTask Send(string message);
    }
}
