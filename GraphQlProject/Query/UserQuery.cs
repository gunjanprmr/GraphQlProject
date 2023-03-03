using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Type;

namespace GraphQlProject.Query;

public class UserQuery: ObjectGraphType
{
    public UserQuery(IUser userService)
    {
        Field<ListGraphType<UserType>>("users", 
            resolve: _ => userService.GetUsers());
        
        Field<UserType>("user", 
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "id"}, 
                new QueryArgument<StringGraphType> { Name = "userId"}
                ),
            resolve: _ => userService.GetUserById(
                _.GetArgument<string>("id"), 
                _.GetArgument<string>("userId")
                ));
    }
}