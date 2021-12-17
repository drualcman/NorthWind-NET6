using NorthWind.Entities.Interfaces;
using System.Diagnostics;

namespace NorthWind.Loggers
{
    /// <summary>
    /// Log para enviar a la ventana de debug
    /// </summary>
    public class DebugStatusLogger : IApplicationStatusLogger
    {
        public void Log(string message)
        {
            Debug.Write(message);
        }
    }
}