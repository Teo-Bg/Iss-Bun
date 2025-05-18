using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.domain
{
    [Flags]
    public enum Genre
    {
        None = 0,
        Romance = 1,
        Comedy = 2,
        Horror = 4,
        Fantasy = 8,
        Adventure = 16,
        SciFi = 32
    }
}
