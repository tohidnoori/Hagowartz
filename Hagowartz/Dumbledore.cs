using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Dumbledore:AuthorizedPersons
    {
        public List<Lesson> LessonList { get; set; }

        public int CurrentTerm { get; set; }
        public int DormNum { get; set; }
    }
}
