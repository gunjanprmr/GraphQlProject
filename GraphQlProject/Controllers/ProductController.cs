using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQlProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProduct _productService;

    public ProductController(IProduct productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public List<Product> GetAllProducts()
    {
       return _productService.GetAllProducts();
        
    }

    [HttpPost]
    public Product AddProduct([FromBody] Product product)
    {
        return _productService.AddProduct(product);
    }

    [HttpPut("{id}")]
    public Product UpdateProduct(int id, [FromBody] Product product)
    {
        return _productService.UpdateProduct(id, product);
    }

    [HttpDelete("{id}")]
    public void DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
    }

    [HttpGet("{id}")]
    public Product GetProductId(int id)
    {
        return _productService.GetProductId(id);
    }
}