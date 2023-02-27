using GraphQL.Types;

namespace GraphQlProject.Type;

public class ContactInputType : InputObjectGraphType
{
    public ContactInputType()
    {
        Field<StringGraphType>("firstName");
        Field<StringGraphType>("lastName");
        Field<StringGraphType>("email");
        Field<StringGraphType>("phoneNumber");
    }
}
