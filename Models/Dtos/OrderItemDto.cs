namespace AccountingRetailOrders.Models.Dtos;

public class OrderItemDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}