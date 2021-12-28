using NorthWind.Entities.Abstractions;
using NorthWind.Entities.Interfaces.Validation;

namespace NorthWind.Sales.DTOs.GetOrdersByDate
{
    /// <summary>
    /// validar la consulta
    /// </summary>
    public class GetOrdersByDateDtoValidator : ValidatorBase<GetOrdersByDateDto>, IValidator<GetOrdersByDateDto>
    {
        /// <summary>
        /// contruir la validacion
        /// </summary>
        /// <param name="service"></param>
        public GetOrdersByDateDtoValidator(IValidationService<GetOrdersByDateDto> service) : base(service)
        {
            AddRuleFor(o => o.OrderDate)
                .AddRequirement(o => o.OrderDate > DateTime.MinValue, "Debe proporcionar la fecha a consultar.")
                .AddRequirement(o => o.OrderDate <= DateTime.Now, "Debe proporcionar una fecha menor o igual a la fecha actual");
        }
    }

}
