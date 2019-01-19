using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElaApi.Model;
using ElaApi.Infrastructure.Repositories;
using ElaApi.Infrastructure.Services;

namespace ElaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        //GET: api/members
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _memberService.GetAllMembers());
        }

        //GET: api/members/discordid
        [HttpGet("{discordid}", Name = "Get")]
        public async Task<IActionResult> Get(string discordid)
        {
            var member = await _memberService.GetMemberByDiscordId(discordid);

            if (member == null)
                return new NotFoundResult();
            return new ObjectResult(member);
        }

        // POST: api/members
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Member member)
        {
            await _memberService.CreateMember(member);
            return new OkObjectResult(member);
        }

        // PUT: api/members/discordid
        [HttpPut("{discordid}")]
        public async Task<IActionResult> Put(string discordid, [FromBody]Member member)
        {
            var memberFromDb = await _memberService.GetMemberByDiscordId(discordid);
            if (memberFromDb == null)
                return new NotFoundResult();
            member.Id = memberFromDb.Id;
            await _memberService.UpdateMember(member);
            return new OkObjectResult(member);
        }
    }
}