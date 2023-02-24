using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Type;

namespace GraphQlProject.Query;

public class UserQuery: ObjectGraphType
{
    public UserQuery(IUser userService)
    {
        Field<UserType>("user", 
            arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id"}),
            resolve: _ => userService.GetUserById(_.GetArgument<string>("id")));
    }
}