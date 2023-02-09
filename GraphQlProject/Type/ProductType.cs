using GraphQL.Types;
using GraphQlProject.Models;

namespace GraphQlProject.Type;

public class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(x => x.Id);
        Field(x => x.Name);
        Field(x => x.Price);
    }
}