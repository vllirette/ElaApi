using System.Collections.Generic;
using System.Threading.Tasks;
using ElaApi.Models;

namespace ElaApi.Infrastructure.Repositories
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMembers();

        Task<Member> GetMemberByDiscordId(string DiscordId);

    }
}
