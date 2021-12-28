namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Registrar en la bitacora del sistema
    /// </summary>
    public interface IApplicationStatusLogger
    {
        void Log(string message);
    }
}
