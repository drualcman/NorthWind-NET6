using Microsoft.AspNetCore.Components.Web;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWInd.Sales.BlazorClient.Pages
{
    public partial class CreateOrderPage
    {
        /// <summary>
        /// capturar exceptiones
        /// </summary>
        ErrorBoundary ErrorBoundaryRef;

        CreateOrderDto Order = new CreateOrderDto
        {
            OrderDetails = new List<CreateOrderDetailDto>()
        };

        void Recover()
        {
            ErrorBoundaryRef?.Recover();
        }
    }
}
