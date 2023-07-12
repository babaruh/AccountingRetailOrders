using AccountingRetailOrders.Data;
using AccountingRetailOrders.Models;
using AccountingRetailOrders.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AccountingRetailOrders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context) => 
        _context = context;

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        var customers = _context.Customers.ToList();
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Customer> GetCustomer(Guid id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(CustomerDto customerDto)
    {
        var customer = new Customer
        {
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Address = customerDto.Address,
            PhoneNumber = customerDto.PhoneNumber
        };
        
        _context.Customers.Add(customer);
        _context.SaveChanges();

        return Ok(customer);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Customer> UpdateCustomer(Guid id, CustomerDto updatedCustomerDto)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
            return NotFound();

        customer.FirstName = updatedCustomerDto.FirstName;
        customer.LastName = updatedCustomerDto.LastName;
        customer.Address = updatedCustomerDto.Address;
        customer.PhoneNumber = updatedCustomerDto.PhoneNumber;

        _context.SaveChanges();

        return Ok(customer);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult DeleteCustomer(Guid id)
    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
            return NotFound();

        _context.Customers.Remove(customer);
        _context.SaveChanges();

        return NoContent();
    }
}