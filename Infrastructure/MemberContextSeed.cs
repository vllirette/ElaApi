using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ElaApi.Models;
using MongoDB.Driver;

namespace ElaApi.Infrastructure
{
    public class MemberContextSeed
    {
        private static MemberContext ctx;

        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var config = applicationBuilder
                .ApplicationServices.GetRequiredService<IOptions<Settings>>();

            ctx = new MemberContext(config);

            if (!ctx.Members.Database.GetCollection<Member>(nameof(Member)).AsQueryable().Any())
            {
                await SetMemberTable();
            }
        }

        static async Task SetMemberTable()
        {
            var memberList = new List<Member>();

            var member1 = new Member()
            {
                DiscordId = "12345",
                TotalPoints = 0,
                CurrentPoints = 0
            };
            memberList.Add(member1);

            var member2= new Member()
            {
                DiscordId = "67890",
                TotalPoints = 0,
                CurrentPoints = 0
            };
            memberList.Add(member2);

            await ctx.Members.InsertManyAsync(memberList);
        }
    }
}