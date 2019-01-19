using System.Collections.Generic;
using System.Threading.Tasks;
using ElaApi.Model;

namespace ElaApi.Infrastructure.Repositories
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetMembersListAsync();

        Task<Member> GetMemberByDiscordId(string DiscordId);

        Task CreateMember (Member member); 

        Task<bool> UpdateMemberAsync(Member member);

    }
}
