using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ElaApi.Models;

namespace ElaApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IMemberContext _context;

        public MemberRepository(IMemberContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            return await _context.Members.Find(_ => true).ToListAsync();
        }

        public async Task<Member> GetMember(string DiscordId)
        {
            FilterDefinition<Member> filter = Builders<Member>.Filter.Eq(m => m.DiscordId, DiscordId);
            return await _context.Members.Find(filter).FirstOrDefaultAsync();
        }
    }
}