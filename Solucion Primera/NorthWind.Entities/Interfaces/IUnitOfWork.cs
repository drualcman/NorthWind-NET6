namespace NorthWind.Entities.Interfaces
{
    /// <summary>
    /// Persistir los datos
    /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
