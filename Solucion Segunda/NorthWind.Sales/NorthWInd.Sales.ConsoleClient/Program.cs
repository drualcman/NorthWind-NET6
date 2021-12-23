using NorthWInd.Sales.ConsoleClient;
using WebExceptionHandlerAPI.Interfaces;

IoC.AddApplicationServices();

try
{
    var service = ServiceContainer.GetService<CreateOrderService>();
    service.CreateOrder();
}
catch (Exception ex)
{
    var exceptionHandler = ServiceContainer.GetService<IWebExceptionPresenter>();

    await exceptionHandler.Handle(ex?.InnerException ?? ex, true);
    new ErrorConsoleView(exceptionHandler.Content).ExecuteResult();
}
