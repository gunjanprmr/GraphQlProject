using GraphQL.Types;

namespace GraphQlProject.Type;

public class UserInputType : InputObjectGraphType
{
    public UserInputType()
    {
        Field<StringGraphType>("id");
        Field<BooleanGraphType>("isActive");
        Field<ContactInputType>("contact");
    }
}