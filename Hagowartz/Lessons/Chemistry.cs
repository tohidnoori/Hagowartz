using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Chemistry:Lesson
    {
        public Chemistry(Lesson lesson):base(lesson) { }
        public Chemistry()
        {

        }

        public List<String> ChemistryTerm1List { get; set; }
        public List<String> ChemistryTerm2List { get; set; }
        public List<String> ChemistryTerm3List { get; set; }
        public List<String> ChemistryTerm4List { get; set; }
    }
}
