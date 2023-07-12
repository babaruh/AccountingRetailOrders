using AccountingRetailOrders.Data;
using AccountingRetailOrders.Models;
using AccountingRetailOrders.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AccountingRetailOrders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderItemController(AppDbContext context) => 
        _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<OrderItem>> GetOrderItems()
    {
        var orderItems = _context.OrderItems.ToList();
        return Ok(orderItems);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<OrderItem> GetOrderItem(Guid id)
    {
        var orderItem = _context.OrderItems.Find(id);
        if (orderItem == null)
            return NotFound();

        return Ok(orderItem);
    }

    [HttpPost]
    public ActionResult<OrderItem> CreateOrderItem(OrderItemDto orderItemDto)
    {
        var orderItem = new OrderItem
        {
            OrderId = orderItemDto.OrderId,
            ProductId = orderItemDto.ProductId,
            Quantity = orderItemDto.Quantity
        };
        
        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();

        return Ok(orderItem);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<OrderItem> UpdateOrderItem(Guid id, OrderItemDto updatedOrderItemDto)
    {
        var orderItem = _context.OrderItems.Find(id);
        if (orderItem == null)
            return NotFound();

        orderItem.Quantity = updatedOrderItemDto.Quantity;

        _context.SaveChanges();

        return Ok(orderItem);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteOrderItem(Guid id)
    {
        var orderItem = _context.OrderItems.Find(id);
        if (orderItem == null)
            return NotFound();

        _context.OrderItems.Remove(orderItem);
        _context.SaveChanges();

        return NoContent();
    }
}

