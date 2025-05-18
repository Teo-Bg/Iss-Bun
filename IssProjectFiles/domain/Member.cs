using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSprojectISS.domain
{
    internal class Member : Entity<long>
    {
        public long _cnp {  get; set; }
        public string _name {  get; set; }
        public string _address {  get; set; }
        public long _phone {  get; set; }

        public Member(long cnp, string name, string address, long phone)
        {
            _cnp = cnp;
            _name = name;
            _address = address;
            _phone = phone;
        }
    }
}
