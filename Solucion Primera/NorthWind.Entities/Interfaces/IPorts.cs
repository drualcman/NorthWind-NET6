namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Puerto de entrada de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPort<T>
    {
        /// <summary>
        /// Manejar los datos de entrada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ValueTask Handle(T dto);
    }

    /// <summary>
    /// Puerto sin datos de entrada
    /// </summary>
    public interface IPort
    {

        /// <summary>
        /// Manejar la entrada sin datos
        /// </summary>
        /// <returns></returns>
        ValueTask Handle();
    }
}
