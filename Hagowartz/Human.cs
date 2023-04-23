using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    public enum EType
    { Half_blood, Pure_blood, Muggle_blood }
    internal class Human
    {
        public String Name { get; set; }
        public String FamillyName { get; set; }
        public String Father { get; set; }
        public String Gender { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public EType Type { get; set; }
        public String BirthDay { get; set; }
        public int Age { get; set; }
    }
}
