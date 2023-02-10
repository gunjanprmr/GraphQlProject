using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using GraphQlProject.Type;

namespace GraphQlProject.Mutations;

public class ProductMutation : ObjectGraphType
{
    public ProductMutation(IProduct productService)
    {
        Field<ProductType>("createProduct",
            arguments: new QueryArguments(
                new QueryArgument<ProductInputType> { Name = "product" }
            ),
            resolve: _ => productService.AddProduct(_.GetArgument<Product>("product")));

        Field<ProductType>("updateProduct",
            arguments: new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "id" },
                new QueryArgument<ProductInputType> { Name = "product" }
            ),
            resolve: _ => productService.UpdateProduct(_.GetArgument<int>("id"), _.GetArgument<Product>("product")));

        Field<StringGraphType>("deleteProduct",
            arguments: new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "id" }
            ),
            resolve: _ =>
            {
                var productId = _.GetArgument<int>("id");
                productService.DeleteProduct(productId);
                return $"The product against the {productId} has been deleted";
            }
        );
    }
}