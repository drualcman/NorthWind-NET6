﻿using NorthWind.Entities.Abstractions;
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
    public class CreateOrderDetailDtoValidator : 
        ValidatorBase<CreateOrderDetailDto>
        // visualmente estaria mejor aqui para ver que implementa el IValidator
        // y quitarlo de la implementacion en la clase base
        //, IValidator<CreateOrderDetailDto>
    {

        /// <summary>
        /// Pasar el servicio de validacion a la clase base
        /// </summary>
        /// <param name="service"></param>
        public CreateOrderDetailDtoValidator(IValidationService<CreateOrderDetailDto> service) 
            : base(service)
        {
            AddRuleFor(od => od.ProductId, true)
                .AddRequirement(od => od.ProductId > 0, "Debe especificar el identificador del producto.");
            AddRuleFor(od => od.Quantity, true)
                .AddRequirement(od => od.Quantity > 0, "Debe especificar la cantidad ordenada del producto.");
            AddRuleFor(od => od.UnitPrice, true)
                .AddRequirement(od => od.UnitPrice > 0, "Debe especificar el precio del producto.");
            AddRuleFor(od => od, true)
                .AddRequirement(od => od.UnitPrice > 0 && od.Quantity > 0 && od.ProductId > 0, "Debe especificar los datos del detalle de la orden.");
        }
    }
}
