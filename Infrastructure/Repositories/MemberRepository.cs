using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ElaApi.Model;
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

        public async Task<bool> UpdateMemberAsync(Member member)
        {
            ReplaceOneResult updateResult = await _context.Members.ReplaceOneAsync(filter: m => m.Id == member.Id, replacement: member);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task CreateMember(Member member)
        {
            await _context.Members.InsertOneAsync(member);
        }
    }
}