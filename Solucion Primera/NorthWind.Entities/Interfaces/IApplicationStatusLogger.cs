using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
