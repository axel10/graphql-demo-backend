using System;
using GraphQL.Types;
using NHLStats.Core.Data;
using NHLStats.Core.Models;

namespace NHLStats.Api.Models
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType(ISkaterStatisticRepository skaterStatisticRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.BirthPlace, true);
            Field(x => x.Height, true);
            Field(x => x.WeightLbs, true);
//            Field<StringGraphType>("birthDate", resolve: context => context.Source.BirthDate.ToString());
            Field<StringGraphType>("birthDate",
                resolve: context =>
                    TimeZoneInfo.ConvertTimeFromUtc(context.Source.BirthDate, TimeZoneInfo.Local).ToString());
            Field<ListGraphType<SkaterStatisticType>>("skaterSeasonStats",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => skaterStatisticRepository.Get(context.Source.Id),
                description: "Player's skater stats");
        }
    }
}