using System.ComponentModel.DataAnnotations;

namespace AccountingRetailOrders.Models;

public class OrderItem
{
    [Key]
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public Product? Product { get; set; }
}
