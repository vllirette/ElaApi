using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ElaApi.Models;

namespace ElaApi.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberContext _context;

        public MemberRepository(MemberContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllMembers()
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