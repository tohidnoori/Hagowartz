namespace Hagowartz
{
    public class Lesson
    {
        public Lesson() { }
        public Lesson(Lesson l) { 
            Capicity= l.Capicity;
            StuNum= l.StuNum;
            Time= l.Time;
            Name= l.Name;
            OfferedTerm= l.OfferedTerm;
        }
        public int Capicity { get; set; }
        public int StuNum { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public int OfferedTerm { get; set; }

        public double score { get; set; } = 0;

    }
}