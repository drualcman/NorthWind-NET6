using System.Linq.Expressions;

namespace SimpleValidationApi
{
    /// <summary>
    /// Esta clase no se va a exponer es solo para manejar como fue la validacion
    /// </summary>
    internal class ValidationExpression
    {
        public Expression Expression { get; }
        public string ErrorMessage { get; }

        public ValidationExpression(Expression expression, string errorMessage)
        {
            Expression = expression;
            ErrorMessage = errorMessage;
        }
    }
}
