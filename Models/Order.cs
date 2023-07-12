using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AccountingRetailOrders.Models;

public class Order
{
    [Key]
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderStatus Status { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled,
    Closed
}
