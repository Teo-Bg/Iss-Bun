using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.domain
{
    internal class Entity<ID>
    {
        private static readonly long serialVersionUID = 7331115341259248461L;
        public ID Id { get; set; }
    }
}
