using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElaApi.Models;
using ElaApi.Infrastructure.Repositories;

namespace ElaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //GET: api/members
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _memberRepository.GetAllMembers());
        }

        //GET: api/members/discordid
        [HttpGet("{discordid}", Name = "Get")]
        public async Task<IActionResult> Get(string discordid)
        {
            var member = await _memberRepository.GetMemberByDiscordId(discordid);

            if (member == null)
                return new NotFoundResult();
            return new ObjectResult(member);
        }
    }
}