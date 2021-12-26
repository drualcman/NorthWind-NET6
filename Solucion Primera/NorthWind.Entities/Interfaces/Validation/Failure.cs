using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Validation
{
    public class Failure : IFailure
    {
        public string PropertyName { get; }

        public string ErrorMessage { get; }

        public Failure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
