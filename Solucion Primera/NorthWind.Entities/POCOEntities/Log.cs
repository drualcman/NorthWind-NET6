namespace NorthWind.Entities.POCOEntities
{
    /// <summary>
    /// Clare parafinir los logs
    /// </summary>
    public class Log
    {
        /// <summary>
        /// identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// fecha de creacion
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Constructor completo
        /// </summary>
        /// <param name="createdDate"></param>
        /// <param name="description"></param>
        public Log(DateTime createdDate, string description) =>
            (CreatedDate, Description) = (createdDate, description);
        /// <summary>
        /// Constructor simple
        /// </summary>
        /// <param name="description"></param>
        public Log(string description) : this(DateTime.Now, description) { }

    }
}
