using LRSprojectISS.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.repository.@interface
{
    internal interface IRepository<ID, E> where E : Entity<ID>
    {
        E? FindOne(ID id);
        IEnumerable<E> FindAll();
    }
}
