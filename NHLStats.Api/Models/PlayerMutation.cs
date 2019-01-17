using GraphQL.Types;
using NHLStats.Core.Data;
using NHLStats.Core.Models;

namespace NHLStats.Api.Models
{
    public class NHLStatsMutation : ObjectGraphType
    {
        public NHLStatsMutation(IPlayerRepository playerRepository)
        {
            Name = "NHLMutation";

            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> {Name = "player"}
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return playerRepository.Add(player);
                });

            Field<PlayerType>(
                name: "editPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> {Name = "player"}
                ),
                resolve: ctx =>
                {
                    var player = ctx.GetArgument<Player>("player");
                    return playerRepository.Update(player);
                }
            );

            Field<BooleanGraphType>(
                name: "deletePlayer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"}
                ),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    playerRepository.Delete(id);
                    return true;
                }
            );
        }
    }
}