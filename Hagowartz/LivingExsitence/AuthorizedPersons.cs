using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    public enum EPet
    { Cat, Dog, Rat }

    public enum EAct
    { Teacher, Student }

    internal class AuthorizedPersons:Human
    {
        public AuthorizedPersons() { }

        public AuthorizedPersons(Human h) : base(h) {
            BirthDay= h.BirthDay;
            Act = h.Role;
            
        }

        public int RoomNum { get; set; }
        public EGroupType Group { get; set; } 
        public bool HavingLuggage { get; set; }
        public EPet Pet { get; set; }
        public EAct Act { get; set; }
        public string BirthDay { get; set; }

        public bool HaveLetter { get; set; } = false;
        public Dictionary<String, String> Letter { get; set; } = new Dictionary<string, string>();
    
        public void showLetter()
        {
            if(HaveLetter)
             Console.WriteLine($"\nHello {Name} {FamillyName} you are wellcomed to hagowartz.\n" +
                "We are glad to see you in hagowaartz.\n" +
                "Here you can see your letter and know more information about your trip to hagowartz:\n" +
                $"Ticket Time:{Letter["Ticket Time"]}\nCabin Number:{Letter["Cabin Number"]}\nChair Number:{Letter["Chair Number"]}");
            else
                Console.WriteLine("There is no letter to show you.");
        }
    }
}
