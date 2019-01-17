using GraphQL.Types;
using NHLStats.Data;

namespace NHLStats.Api.Models
{
    public class MyStateQuery : ObjectGraphType
    {
        public MyStateQuery(ITeamRepository repository)
        {
            Field<TeamType>("teams", resolve: c => repository.All());
        }
    }
}