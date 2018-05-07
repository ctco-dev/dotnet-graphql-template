using System;
using GraphQL.Types;
using Services;

namespace Configuration.GraphQL
{
    public class GraphQLDroid : ObjectGraphType<Droid>
    {
        public GraphQLDroid()
        {
            Field(x => x.Id).Description("The Id of the Droid.");
            Field(x => x.Name, nullable: true).Description("The name of the Droid.");
            Field<StringGraphType>("queryId", resolve: context => DateTime.Now.Ticks.ToString())
                .Description = "current time in ticks";
        }
    }
}