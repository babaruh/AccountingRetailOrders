using AccountingRetailOrders.Data;
using AccountingRetailOrders.Models;
using AccountingRetailOrders.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountingRetailOrders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context) => 
        _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        var orders = _context.Orders.Include(o => o.OrderItems).ToList();
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Order> GetOrder(Guid id)
    {
        var order = _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.OrderId == id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public ActionResult<Order> CreateOrder(OrderDto orderDto)
    {
        var order = new Order
        {
            CustomerId = orderDto.CustomerId,
            OrderDate = DateTime.Now,
            Status = OrderStatus.Pending
        };
        
        _context.Orders.Add(order);
        _context.SaveChanges();

        return Ok(order);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Order> UpdateOrderStatus(Guid id, OrderStatus orderStatus)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();

        order.Status = orderStatus;

        _context.SaveChanges();

        return Ok(order);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteOrder(Guid id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return NoContent();
    }
}