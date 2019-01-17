using GraphQL.Types;
using NHLStats.Core.Data;
using NHLStats.Data;


namespace NHLStats.Api.Models
{
    public class NHLStatsQuery : ObjectGraphType
    {
        public NHLStatsQuery(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            Name ="NHLQuery";
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => playerRepository.Get(context.GetArgument<int>("id")));

            Field<PlayerType>(
                "randomPlayer",
                resolve: context => playerRepository.GetRandom());

            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => playerRepository.All());

            Field<ListGraphType<TeamType>>("teams", resolve: c => teamRepository.All());
        }
    }
}