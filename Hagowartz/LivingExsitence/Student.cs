using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Student:AuthorizedPersons
    {
        public Student() { }
        public Student(Human a) : base(a)
        {
        }
        public List<Lesson> PassedLessons { get; set; } = new List<Lesson>();
        public int Term { get; set; }
        public string DormCode { get; set; }
        public bool DoesGoToHagowartz { get; set; } = false;
        public void GoToHagowartz()
        {
            if (!DoesGoToHagowartz)
            {
                DormCode = Dorm.makeDormCode();
                Group group = new Group();
                group.Type = (EGroupType)new Random().Next(0, 3);
                group.GroupMembers.Add(this);
                base.Group = group;
                Term = 1;
                Pet = (EPet)new Random().Next(0, 2);
                Console.WriteLine($"****Welcome to hagowartz****\n" +
                    $"Your Dorm Code:\t{DormCode}\n" +
                    $"Group Type:\t{group.Type}\n" +
                    $"Your Pet:\t{Pet}");
            }
            else
            {
                Console.WriteLine("You already gone to the hagowartz.");
            }
        }

    }
}
