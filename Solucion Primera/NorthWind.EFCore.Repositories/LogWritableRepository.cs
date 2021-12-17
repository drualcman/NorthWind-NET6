using NorthWind.EFCore.DataContexts;
using NorthWind.EFCore.DataContexts.Guards;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.EFCore.Repositories
{
    /// <summary>
    /// Administrar la table de log repository
    /// </summary>
    public class LogWritableRepository : ILogWritableRepository
    {
        readonly NorthWindLogContext Context;

        /// <summary>
        /// Constructor que recibe el contexto de datos
        /// </summary>
        /// <param name="context"></param>
        public LogWritableRepository(NorthWindLogContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Agregar log
        /// </summary>
        /// <param name="log"></param>
        public void Add(Log log)
        {
            Context.Add(log);
        }

        /// <summary>
        /// Agregar log con mensaje
        /// </summary>
        /// <param name="message"></param>
        public void Add(string message) =>
            Add(new Log(message));

        /// <summary>
        /// Guardar los cambios
        /// </summary>
        public void SaveChanges()
        {
            DataContextGuards.SaveChanges(Context);
        }
    }
}