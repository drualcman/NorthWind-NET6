using System.Reflection;

namespace NorthWind.WebExceptionHandlerPresenters
{
    /// <summary>
    /// Recoger todos los manejadores de exceptions
    /// </summary>
    public static class ExceptionHandlersPresenters
    {
        /// <summary>
        /// Recoger el aseembly actual para buscar los manejadores de excepion
        /// </summary>
        public static Assembly Assembly =>
            Assembly.GetExecutingAssembly();
    }
}
