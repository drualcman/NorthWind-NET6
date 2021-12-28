using System.Linq.Expressions;

namespace NorthWind.Entities.Interfaces.Validation
{
    /// <summary>
    /// Reglas de validacion para el modelo enviado (T)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRule<T>
    {
        /// <summary>
        /// Definir la regla de validacion
        /// </summary>
        /// <param name="requirement"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        IRule<T> AddRequirement(
            //recibe una expresion con el requerimiento a validad
            Expression<Func<T, bool>> requirement,
            //mensaje a mostrar en caso de error
            string errorMessage);

        /// <summary>
        /// Definir la regla de validacion para cuando son listas
        /// </summary>
        /// <param name="itemsValidator"></param>
        /// <returns></returns>
        IRule<T> AddCollectionItemsValidator(
            //recibe una expresion con el requerimiento a validad
            //, y T tiene una lista que otro modelo            
            Expression<Func<T, IEnumerable<IFailure>>> itemsValidator);
    }
}
