using System.ComponentModel.DataAnnotations;

namespace AccountingRetailOrders.Models;

public class Product
{
    [Key]   
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } 
    public decimal Price { get; set; }
}
