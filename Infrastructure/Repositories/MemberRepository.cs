using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ElaApi.Models;
using Microsoft.Extensions.Options;

namespace ElaApi.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberContext _context;

        public MemberRepository(IOptions<Settings> options)
        {
            _context = new MemberContext(options);
        }

        public async Task<List<Member>> GetMembersListAsync()
        {
            return await _context.Members.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Member> GetMemberByDiscordId(string DiscordId)
        {
            FilterDefinition<Member> filter = Builders<Member>.Filter.Eq(m => m.DiscordId, DiscordId);
            return await _context.Members.Find(filter).FirstOrDefaultAsync();
        }
    }
}