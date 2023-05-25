using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz.Lessons
{
    internal class Sport:Lesson
    {
        public Sport()
        {

        }
        public Sport(Lesson l) : base(l)
        {
        }

        public String Type { get; set; }
    }
}
