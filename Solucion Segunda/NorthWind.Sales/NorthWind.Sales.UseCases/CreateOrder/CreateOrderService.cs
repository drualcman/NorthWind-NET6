﻿using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Entities.Agregates;
using NorthWind.Sales.Events;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    /// <summary>
    /// servicio para la creacion de ordenes
    /// </summary>
    public class CreateOrderService
    {
        readonly IValidator<CreateOrderDto> Validator;
        readonly ICreateOrderRepository OrderRepository;
        readonly IDomainEventHub<SpecialOrderCreatedEvent> DomainEventHub;
        readonly ILogWritableRepository LogRepository;
        readonly ICreateOrderValidationRepository ValidationRepository;

        /// <summary>
        /// recibir las abstracciones por injeccion de dependencias
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="orderRepository"></param>
        /// <param name="domainEventHub"></param>
        /// <param name="logRepository"></param>
        /// <param name="validationRepository"></param>
        public CreateOrderService(IValidator<CreateOrderDto> validator, ICreateOrderRepository orderRepository,
            IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub, ILogWritableRepository logRepository,
            ICreateOrderValidationRepository validationRepository)
        {
            Validator = validator;
            OrderRepository = orderRepository;
            DomainEventHub = domainEventHub;
            LogRepository = logRepository;
            ValidationRepository = validationRepository;
        }

        /// <summary>
        /// romper el flujo si no valida.
        /// Los metodos Guard se usan para que si no se cumple algo entonces se detenga la ejecucion.
        /// </summary>
        /// <param name="order"></param>
        public void RunValidationGuard(CreateOrderDto order)
        {
            //validar la entrada de datos
            if (!Validator.Validate(order))
            {
                throw new ValidationException(Validator.Failures);
            }

            //validar de la base de datos que no tenga un balance pendiente
            var CurrentBalance = ValidationRepository.GetCurrentBalance(order.CustomerId);

            if (CurrentBalance == null)
            {
                throw new ValidationException(
                    new List<IFailure> { new Failure("Customer", "El identificador de cliente proporcionado no existe")});
            }

            if (CurrentBalance > 0)
            {
                throw new ValidationException(
                    new List<IFailure> { new Failure("Customer", $"El cliente tiene un adeudo pendiente de {CurrentBalance}")});
            }

            //validar que haya existencias desde la base de datos
            var UnitsInStock = ValidationRepository.GetUnitsInStock(
               order.OrderDetails.Select(d => d.ProductId).ToList());

            var Failures = new List<IFailure>();

            var RequiredQuantities = order.OrderDetails
                .GroupBy(d => d.ProductId)
                .Select(d => new KeyValuePair<int, int>(d.First().ProductId,
                d.Sum(p => p.Quantity))).ToList();

            foreach (var Item in RequiredQuantities)
            {
                if (!UnitsInStock.ContainsKey(Item.Key))
                {
                    Failures.Add(new Failure(
                        "Id",
                        $"El producto {Item.Key} no existe."
                    ));
                }
                else
                {
                    if (UnitsInStock[Item.Key] < Item.Value)
                    {
                        Failures.Add(new Failure(
                            "Id",
                            $"Cantidad ({Item.Value}) no suficiente ({UnitsInStock[Item.Key]}) del producto {Item.Key}."));
                    }
                }
            }
            if (Failures.Any())
            {
                throw new ValidationException(Failures);
            }
        }

        /// <summary>
        /// Crear la orden. Como es un Guard si no se puede rompe le ejecucion con una excepcion.
        /// </summary>
        /// <returns></returns>
        public OrderAgregate RunCreateOrderGuard(CreateOrderDto order)
        {
            OrderAgregate orderAgregate = new OrderAgregate
            {
                CustomerId = order.CustomerId,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode
            };
            foreach (var item in order.OrderDetails)
            {
                orderAgregate.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
            }

            try
            {
                //registrar el inicio de creacion de la orden
                //esto siempre hay que registrarlo por eso directamente se invoca a save changes
                LogRepository.Add("Inicio de creacion de orden");
                LogRepository.SaveChanges();

                //inicar la transaccion, desde aqui o todo o nada
                OrderRepository.CreateOrder(orderAgregate);     //devuelve excepcion en caso de que haya error

                // Aqui podriamos tener una logica que nos haga cancelar la creacion de la orden
                // OrderRepository.CancelChanges();

                // registrar el log
                LogRepository.Add($"Orden {orderAgregate.Id} ha sido creada");
                LogRepository.SaveChanges();

                // como se pudo hacer todo se puede finalizar la transaction
                OrderRepository.SaveChanges();
                //finalizar transaction
            }
            catch
            {
                LogRepository.Add("Creacion de orden cancelada");
                LogRepository.SaveChanges();
                throw;
            }

            return orderAgregate;
        }

        /// <summary>
        /// Lanzar el evento de orden especial
        /// </summary>
        /// <param name="order"></param>
        public void RaiseEventIfSpecialOrder(OrderAgregate order)
        {
            if (new SpecialOrderSpecification().IsSatisfiedBy(order))
            {
                //Como se ejecuta en otro hilo esto se lanzara asincronamente pero no tenemos que esperar
                DomainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
            }
        }
    }
}
