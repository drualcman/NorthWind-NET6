namespace NorthWInd.Sales.WebApi.Endpoints
{
    public static class EndpointsHelper
    {
        public static WebApplication UseApplicationEndpints(this WebApplication app)
        {
            app.MapPost("/create", new CreateOrderEndpoint().CreateOrder);
            return app;
        }
    }
}
