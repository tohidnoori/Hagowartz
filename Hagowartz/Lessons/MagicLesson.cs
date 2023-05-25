using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class MagicLesson:Lesson
    {
        public MagicLesson(Lesson l) : base(l)
        {
        }
        public MagicLesson()
        {

        }
        public List<String> MagicTerm1List { get; set; }
        public List<String> MagicTerm2List { get; set; }
        public List<String> MagicTerm3List { get; set; }
        public List<String> MagicTerm4List { get; set; }
    }
}
