using System.ComponentModel.DataAnnotations;

namespace AccountingRetailOrders.Models;

public class Customer
{
    [Key]
    public Guid CustomarId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string PhoneNumber { get; set; }

    public List<Order>? Orders { get; set; }
}