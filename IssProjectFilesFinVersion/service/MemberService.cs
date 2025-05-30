using LRSprojectISS.domain;
using LRSprojectISS.repository.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.service
{
    internal class MemberService
    {
        private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }


        public Member GetMemberByCnp(long cnp)
        {
            var member = _repo.FindOneByCnp(cnp);
            if (member == null)
                throw new Exception("Member not found");

            return member;
        }

        public Member Login(long id, string name)
        {
            var member = _repo.FindOne(id);

            if (member == null)
            {
                throw new Exception($"Login failed: No member found with ID {id}.");
            }

            if (!string.Equals(member._name, name))
            {
                throw new Exception("Login failed: Incorrect name.");
            }

            return member;
        }
    }
}
