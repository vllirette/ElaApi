using System.Collections.Generic;
using System.Threading.Tasks;
using ElaApi.Models;

namespace ElaApi.Infrastructure.Services
{
    public interface IMemberService
    {
        Task<Member> GetMemberByDiscordId(string discordId);

        Task<List<Member>> GetAllMembers();

        Task CreateMember(Member member);

        Task<bool> DeleteMember(string id);
    }    
}