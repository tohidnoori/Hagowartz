using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Teacher : AuthorizedPersons
    {
        public Teacher(Human h) : base(h) { }
        public Teacher()
        {

        }
        public bool SimultaneousTeaching { get; set; }
                public override string ToString()
        {
            return $"Fullname:{Name} {FamillyName},Father:{Father},Gender:{Gender},BirthDay:{BirthDay}";

        }

        public void ShowGroups(EGroupType e)
        {
            if (Dumbledore.Instance.groupList[(int)e].GroupMembers.Count==0)
            {
                Console.WriteLine($"\nThere is no one in {e.ToString()} group.");
            }
            else
            {
                Console.WriteLine($"\nGroup name {e}\t\tParticipants num:{Dumbledore.Instance.groupList[(int)e].GroupMembers.Count}\n");
                var i = 1;
                foreach (Student st in Dumbledore.Instance.groupList[(int)e].GroupMembers)
                {
                    Console.WriteLine($"{i}.{st.Name} {st.FamillyName}");
                    i++;
                }
            }
            
        }
    }
}
