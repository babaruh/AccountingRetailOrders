using AccountingRetailOrders.Data;
using AccountingRetailOrders.Models;
using AccountingRetailOrders.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AccountingRetailOrders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        var products = _context.Products.ToList();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(Guid id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price
        };
        
        _context.Products.Add(product);
        _context.SaveChanges();

        return Ok(product);
    }

    [HttpPut("{id}")]
    public ActionResult<Product> UpdateProduct(Guid id, ProductDto updatedProductDto)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            return NotFound();

        product.Name = updatedProductDto.Name;
        product.Description = updatedProductDto.Description;
        product.Price = updatedProductDto.Price;

        _context.SaveChanges();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(Guid id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return NoContent();
    }
}