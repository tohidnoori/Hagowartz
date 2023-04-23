using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    public enum EPet
    { Cat, Dog, Rat }

    public enum EAct
    { Teacher, Student }

    internal class AuthorizedPersons:Human
    {
        public int RoomNum { get; set; }
        public Group Group { get; set; }
        public bool HavingLuggage { get; set; }
        public EPet pet { get; set; }
        public EAct Act { get; set; }
        public String BirthDay { get; set; }
        public  List<String> Letter { get; set; }
    }
}
