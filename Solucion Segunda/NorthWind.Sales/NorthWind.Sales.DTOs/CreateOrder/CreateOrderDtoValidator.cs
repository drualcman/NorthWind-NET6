using NorthWind.Entities.Abstractions;
using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    /// <summary>
    /// Validador para la orden
    /// </summary>
    public class CreateOrderDtoValidator : ValidatorBase<CreateOrderDto>
    {
        /// <summary>
        /// hacer las validaciones de la orden
        /// </summary>
        /// <param name="service">validador para la orden</param>
        /// <param name="detailService">validador para el detalle</param>
        public CreateOrderDtoValidator(IValidationService<CreateOrderDto> service,
            IValidationService<CreateOrderDetailDto> detailService) : base(service)
        {
            AddRuleFor(o => o.CustomerId, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.CustomerId), "Debe proporcionar el identificador del cliente")
                .AddRequirement(o => o.CustomerId.Length == 5, "La longitud del identificador debe ser de 5 caracteres.");
            AddRuleFor(o => o.ShipAddress, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipAddress), "Debe proporcionar la direccion del envio.")
                .AddRequirement(o => o.ShipAddress.Length <= 60, "La longitud maxima de la direccion es 60 caracteres.");
            AddRuleFor(o => o.ShipCity, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipAddress), "Debe proporcionar la ciudad del envio.")
                .AddRequirement(o => o.ShipCity.Length >= 3, "Debe especificar al menos 3 caracteres de la ciudad.")
                .AddRequirement(o => o.ShipCity.Length <= 15, "La longitud maxima de la ciudad es 15 caracteres.");
            AddRuleFor(o => o.ShipCountry, true)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipAddress), "Debe proporcionar el pais del envio.")
                .AddRequirement(o => o.ShipCity.Length >= 3, "Debe especificar al menos 3 caracteres del pais.")
                .AddRequirement(o => o.ShipCity.Length <= 15, "La longitud maxima del pais es 15 caracteres.");
            AddRuleFor(o => o.ShipPostalCode, true)
                .AddRequirement(o => o.ShipPostalCode.Length <= 10, "La longitud maxima de la codigo postal es 10 caracteres.");

            AddRuleFor(o => o.OrderDetails, true)
                .AddRequirement(o => o.OrderDetails != null, "Debe especificar los productos de la orden.")
                .AddRequirement(o => o.OrderDetails.Any(), "Debe espeficicar al menos un producto de la ordem.")
                .AddCollectionItemsValidator(o =>
                    SetValidatorFor(o.OrderDetails, new CreateOrderDetailDtoValidator(detailService)));
        }
    }
}
