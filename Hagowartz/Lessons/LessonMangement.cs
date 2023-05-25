using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Hagowartz.Lessons
{
    internal class LessonMangement
    {
        public LessonMangement() { }

        public static List<Lesson> Term1Lessons()
        {
            List<Lesson> term1Lessons= new List<Lesson>();
            Chemistry chemistry = new Chemistry();
            chemistry.Name = "Chemistry 1";
            chemistry.Time = "Tuesday 14 to 16";
            chemistry.OfferedTerm = 1;
            chemistry.Capicity = 40;

            term1Lessons.Add(chemistry);

            Math math = new Math();
            math.Name = "Math 1";
            math.Time = "Saterdayt 14 to 16";
            math.OfferedTerm = 1;
            math.Capicity = 40;

            term1Lessons.Add(math);


            Botany botany = new Botany();
            botany.Name = "Botany 1";
            botany.Time = "Monday 8 to 10";
            botany.OfferedTerm = 1;
            botany.Capicity = 60;

            term1Lessons.Add(botany);

            MagicLesson magic = new MagicLesson();
            magic.Name = "Magic 1";
            magic.Time = "Wendsday 8 to 10";
            magic.OfferedTerm = 1;
            magic.Capicity = 35;

            term1Lessons.Add(magic);

            Sport sport = new Sport();
            sport.Name = "Sport-volleyball";
            sport.Time = "Wendsday 8 to 10";
            sport.OfferedTerm = 1;
            sport.Capicity = 20;
            sport.Type = "Volleybal";

            term1Lessons.Add(sport);

            return term1Lessons;
        }

        public static List<Lesson> Term2Lessons()
        {
            List<Lesson> term2Lessons = new List<Lesson>();
            Chemistry chemistry = new Chemistry();
            chemistry.Name = "Chemistry 2";
            chemistry.Time = "Friday 14 to 16";
            chemistry.OfferedTerm = 2;
            chemistry.Capicity = 60;

            term2Lessons.Add(chemistry);

            Botany botany = new Botany();
            botany.Name = "Botany 2";
            botany.Time = "Monday 8 to 10";
            botany.OfferedTerm = 2;
            botany.Capicity = 100;

            term2Lessons.Add(botany);

            MagicLesson magic = new MagicLesson();
            magic.Name = "Magic 2";
            magic.Time = "Wendsday 8 to 10";
            magic.OfferedTerm = 2;
            magic.Capicity = 35;

            term2Lessons.Add(magic);

            Math math = new Math();
            math.Name = "Math 2";
            math.Time = "Saterdayt 14 to 16";
            math.OfferedTerm = 1;
            math.Capicity = 40;

            term2Lessons.Add(math);

            Sport sport = new Sport();
            sport.Name = "Sport-soccer";
            sport.Time = "Wendsday 8 to 10";
            sport.OfferedTerm = 2;
            sport.Capicity = 20;
            sport.Type = "Soccer";

            term2Lessons.Add(sport);

            return term2Lessons;
        }

        public static List<Lesson> Term3Lessons()
        {
            List<Lesson> term3Lessons = new List<Lesson>();
            Chemistry chemistry = new Chemistry();
            chemistry.Name = "Chemistry 3";
            chemistry.Time = "Tuesday 14 to 16";
            chemistry.OfferedTerm = 3;
            chemistry.Capicity = 40;

            term3Lessons.Add(chemistry);

            Botany botany = new Botany();
            botany.Name = "Botany 3";
            botany.Time = "Monday 8 to 10";
            botany.OfferedTerm = 3;
            botany.Capicity = 60;

            term3Lessons.Add(botany);

            MagicLesson magic = new MagicLesson();
            magic.Name = "Magic 3";
            magic.Time = "Wendsday 8 to 10";
            magic.OfferedTerm = 3;
            magic.Capicity = 35;

            term3Lessons.Add(magic);

            Sport sport = new Sport();
            sport.Name = "Sport-Boxing";
            sport.Time = "Wendsday 8 to 10";
            sport.OfferedTerm = 3;
            sport.Capicity = 20;
            sport.Type = "Boxing";

            term3Lessons.Add(sport);

            return term3Lessons;
        }

        public static List<Lesson> Term4Lessons()
        {
            List<Lesson> term4Lessons = new List<Lesson>();
            Chemistry chemistry = new Chemistry();
            chemistry.Name = "Chemistry 4";
            chemistry.Time = "Tuesday 14 to 16";
            chemistry.OfferedTerm = 4;
            chemistry.Capicity = 15;

            term4Lessons.Add(chemistry);

            Botany botany = new Botany();
            botany.Name = "Botany 4";
            botany.Time = "Monday 8 to 10";
            botany.OfferedTerm = 4;
            botany.Capicity = 50;

            term4Lessons.Add(botany);

            MagicLesson magic = new MagicLesson();
            magic.Name = "Magic 400";
            magic.Time = "Wendsday 8 to 10";
            magic.OfferedTerm = 4;
            magic.Capicity = 40;

            term4Lessons.Add(magic);

            Sport sport = new Sport();
            sport.Name = "Sport-volleyball";
            sport.Time = "Wendsday 8 to 10";
            sport.OfferedTerm = 4;
            sport.Capicity = 20;
            sport.Type = "Volleybal";

            term4Lessons.Add(sport);

            return term4Lessons;
        }

    }
}
