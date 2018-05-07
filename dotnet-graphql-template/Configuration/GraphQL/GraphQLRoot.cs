using GraphQL.Types;
using Services;

namespace Configuration.GraphQL
{
    public class GraphQLRoot : ObjectGraphType
    {
        public GraphQLRoot(IDroidService droidService)
        {
            Name = "Query";

            Field<GraphQLDroid>("droid", resolve: context => droidService.GetDroid());
        }
    }
}