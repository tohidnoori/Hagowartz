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
        private Human h;

        public Human() { }

        public Human(Human h)
        {
            Name= h.Name;
            FamillyName= h.FamillyName;
            Age = h.Age;
            Username= h.Username;
            Password= h.Password;
            BirthDay= h.BirthDay;
            Gender= h.Gender;
            Type= h.Type;
            Role= h.Role;
            Father = h.Father;
        }

        public String Name { get; set; }
        public String FamillyName { get; set; }
        public String Father { get; set; }
        public EGender Gender { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public EType Type { get; set; }
        public EAct Role { get; set; }
        public String BirthDay { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name:{Name},FamillyName:{FamillyName},Father:{Father},Gender:{Gender},Username:{Username},Password:{Password},Type:{Type},BirthDay:{BirthDay},Role:{Role},Age:{Age},";
        }
    }
}
