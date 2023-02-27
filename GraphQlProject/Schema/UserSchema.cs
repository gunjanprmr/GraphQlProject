using GraphQlProject.Mutations;
using GraphQlProject.Query;

namespace GraphQlProject.Schema;

public class UserSchema : GraphQL.Types.Schema
{
    public UserSchema(UserQuery userQuery, UserMutation userMutation)
    {
        Query = userQuery;
        Mutation = userMutation;
    }
}