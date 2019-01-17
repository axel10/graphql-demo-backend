
using GraphQL.Types;
using NHLStats.Core.Models;
using NHLStats.Core.Data;
using NHLStats.Data;

namespace NHLStats.Api.Models
{
    public class TeamType:ObjectGraphType<Team>
    {
        public TeamType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Abbreviation);
        }
    }
}
