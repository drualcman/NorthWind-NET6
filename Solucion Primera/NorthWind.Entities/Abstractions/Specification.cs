using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Abstractions
{
    /// <summary>
    /// Definir especificaciones
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T>
    {
        /// <summary>
        /// Condicion que vamos a evaluar
        /// </summary>
        public abstract Expression<Func<T, bool>> ConditionExpression { get; }
        
        /// <summary>
        /// Ejecutar la condicion
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> expressionDelegate = ConditionExpression.Compile();
            return expressionDelegate(entity);
        }
    }
}
