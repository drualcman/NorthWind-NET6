namespace NorthWind.Sales.Entities.ValueObjects
{

    /// <summary>
    /// Utilizando los nuevos records es la misma funcionalidad que un value object inmutable pero con menos codigo
    /// en c#10 tenemos los record como struct
    /// </summary>
    /// <param name="ProductId"></param>
    /// <param name="UnitPrice"></param>
    /// <param name="Quantity"></param>
    public record struct OrderDetail(int ProductId, decimal UnitPrice, short Quantity);
}
