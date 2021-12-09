using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Escribir en un registro de errores
    /// </summary>
    public interface ILogWritableRepository
    {
        void Add(Log log);
        void Add(string message);
    }
}
