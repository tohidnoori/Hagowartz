using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    public enum EGroupType
    { Hufflepuff, Gryffindor, Ravenclaw, Slytherin}
    internal class Group
    {
 
        public int Score { get; set; } = 0;
        public EGroupType Type { get; set; } = 0;
        public List<AuthorizedPersons> GroupMembers { get; set; } = new List<AuthorizedPersons>();
        public List<AuthorizedPersons> Qoidich { get; set; } = new List<AuthorizedPersons>();
    }
}
