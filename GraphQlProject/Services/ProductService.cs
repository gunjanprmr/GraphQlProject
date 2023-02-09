using GraphQlProject.Interfaces;
using GraphQlProject.Models;

namespace GraphQlProject.Services;

public class ProductService : IProduct
{
    private static List<Product> _products = new List<Product>
    {
        new Product() { Id = 0, Name = "apple", Price = 2 },
        new Product() { Id = 1, Name = "orange", Price = 3 },
    };

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product AddProduct(Product product)
    {
        _products.Add(product);
        return product;
    }

    public Product UpdateProduct(int id, Product product)
    {
        _products[id] = product;
        return product;
    }

    public void DeleteProduct(int id)
    {
        _products.RemoveAt(id);
    }

    public Product GetProductId(int id)
    {
        return _products.Find(x => x.Id == id);
    }
}