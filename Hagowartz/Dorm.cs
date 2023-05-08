using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hagowartz
{
    public enum EGender
    {
        Male,Female
    }
    internal class Dorm
    {
        public Group Group { get; set; }
        //max floor 4
        public static int Floor = 1;
        //max room 5
        public static int Room = 1;
        //max bed 3
        public static int Bed = 1;
        public EGender Gender { get; set; }

        public static string makeDormCode()
        {
            String DormCode = string.Empty;
            if (Bed > 3)
            {
                if (Room == 5)
                {
                    Floor++;
                    Bed = 1;
                    Room = 1;
                }
                else
                {
                    Room++;
                    Bed = 1;
                }
            }
            DormCode =  $"F{Floor}R{Room}B{Bed}";
            //Console.WriteLine(DormCode);
            Bed++;
            return DormCode;
        }

    }
}
