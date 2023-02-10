using GraphQlProject.Mutations;
using GraphQlProject.Query;

namespace GraphQlProject.Schema;

public class ProductSchema : GraphQL.Types.Schema
{
    public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
    {
        Query = productQuery;
        Mutation = productMutation;
    }
}