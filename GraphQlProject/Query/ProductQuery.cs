using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Type;

namespace GraphQlProject.Query;

public class ProductQuery : ObjectGraphType
{
    public ProductQuery(IProduct productService)
    {
        Field<ListGraphType<ProductType>>("products", resolve: _ => productService.GetAllProducts());
        Field<ProductType>("product", 
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
            resolve: _ => productService.GetProductId(_.GetArgument<int>("id")));
    }
}