namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Presentar la informacion en el formato enviado
    /// </summary>
    /// <typeparam name="FormatDataType"></typeparam>
    public interface IPresenter<FormatDataType>
    {
        /// <summary>
        /// Los datos en el formato deseado
        /// </summary>
        FormatDataType Content { get; }
    }
}
