using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElaApi.Model;
using ElaApi.Infrastructure.Repositories;

namespace ElaApi.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
        }

        public async Task CreateMember(Member member)
        {
            await _memberRepository.CreateMember(member);
        }

        public async Task<bool> DeleteMember(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _memberRepository.GetMembersListAsync();
        }

        public async Task<Member> GetMemberByDiscordId(string discordId)
        {
            return await _memberRepository.GetMemberByDiscordId(discordId);
        }

        public async Task<bool> UpdateMember(Member member)
        {
            return await _memberRepository.UpdateMemberAsync(member);
        }
    }
}