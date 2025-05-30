using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LRSprojectISS.domain;

namespace LRSprojectISS.repository.@interface
{
    internal interface IMemberRepository : IRepository<long, Member>
    {
        Member? FindOneByCnp(long cnp);
    }
}
