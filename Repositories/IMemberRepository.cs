using System.Collections.Generic;
using System.Threading.Tasks;
using ElaApi.Models;

namespace ElaApi.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembers();

        Task<Member> GetMember(string DiscordId);

    }
}
