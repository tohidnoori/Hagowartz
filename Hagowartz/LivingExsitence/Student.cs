using Hagowartz.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    
    internal class Student: AllowedPersons
    {
        public Student() { }
        public Student(Human a) : base(a)
        {
            

        }
        public List<Lesson> PassedLessons { get; set; } = new List<Lesson>();
        public List<Lesson> FailedLessons { get; set; } = new List<Lesson>();
        public List<Lesson> CurrentTermLessons { get; set; } = new List<Lesson>();
        public int Term { get; set; } = 1;
        public string DormCode { get; set; }
        public bool DoesGoToHagowartz { get; set; } = false;
        public void GoToHagowartz()
        {
            if (!DoesGoToHagowartz)
            {
                DormCode = Dorm.makeDormCode();
                Group = (EGroupType)new Random().Next(0, 3);
                Dumbledore.Instance.groupList[(int)Group].GroupMembers.Add(this);
                Term = 1;
                Pet = (EPet)new Random().Next(0, 2);
                Console.WriteLine($"\n****Welcome to hagowartz****\n" +
                    $"Your Dorm Code:\t{DormCode}\n" +
                    $"Group Type:\t{Group}\n" +
                    $"Your Pet:\t{Pet}");
                DoesGoToHagowartz= true;
                Dumbledore.Instance.saveDataAsJson();
            }
            else
            {
                Console.WriteLine("You already gone to the hagowartz.");
            }
        }

        public void ChoosePresentedLessons()
        {
            Console.Clear();
            if(HaveLetter && DoesGoToHagowartz)
            {
                Console.WriteLine($"Name : {Name} {FamillyName}\t Current Term: {Term}");
                Console.WriteLine("You can choose all of these lessons listed below: \n");
                List<Lesson> offeredTermLessons= LessonMangement.Instance.giveLessons(Term);
                if(offeredTermLessons.Count > 0)
                {
                    foreach (Lesson lesson in offeredTermLessons)
                    {
                        Console.WriteLine($"{lesson.Name}\t Time: {lesson.Time}\t");
                    }
                    foreach (Lesson lesson in FailedLessons)
                    {
                        Console.WriteLine($"{lesson.Name}\t Time: {lesson.Time}\t");
                    }
                    Console.Write("If you wanna choose these lessons for this term type and enter yes: ");
                    string temp = Console.ReadLine();
                    if (temp == "yes")
                    {
                        Console.Clear();
                        Console.WriteLine("\nLoading...");
                        Thread.Sleep(1000);
                        CurrentTermLessons.Clear();
                        CurrentTermLessons = offeredTermLessons;
                        foreach (Lesson lesson in FailedLessons)
                        {
                            CurrentTermLessons.Add(lesson);
                        }
                        FailedLessons.Clear();
                        Console.WriteLine($"Ok\nYour Term {Term} lesson has been added.\n");
                        Dumbledore.Instance.saveDataAsJson();

                    }
                    else
                    {
                        Console.WriteLine("Ok you cancel the process of choosing lessons for your current term:");
                    }
                }
                else
                {
                    Console.WriteLine("WRONG INPUT FOR TERM");
                }
            }
            else
            {
                Console.WriteLine("You dont allow to choose lessons.");
            }
        }

        public void TakeExam(int score)
        {
            Console.Clear();
           if(CurrentTermLessons.Count > 0)
            {
                Console.WriteLine("Your current lessons are these choose one of them and take exam:");
                int i = 1;
                foreach (Lesson lesson in CurrentTermLessons)
                {
                    Console.WriteLine($"{lesson.Name} enter({i})");

                    i++;
                }
                int choosenLessonForExam = int.Parse(Console.ReadLine());
                if (choosenLessonForExam >= 1 && choosenLessonForExam <= CurrentTermLessons.Count)
                {

                    if (CurrentTermLessons[choosenLessonForExam - 1].score==0) {
                        Console.WriteLine($"If you wanna take exam for the {CurrentTermLessons[choosenLessonForExam - 1].Name} enter y");
                        if (Console.ReadLine() == "y")
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Loading...");
                            Thread.Sleep(1000);
                            Console.WriteLine("Your Exam Finished");
                            CurrentTermLessons[choosenLessonForExam - 1].score = score;
                            Console.WriteLine($"Your exam score is {CurrentTermLessons[choosenLessonForExam - 1].score}");
                            Dumbledore.Instance.saveDataAsJson();
                        }
                        else
                        {
                            Console.WriteLine("You cancel the process of taking exam");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You aleary taken the exam of this lesson.");
                    }
                }
                else
                    Console.WriteLine("INCORRECT INPUT ENTER NUMBER TO CHOOSE LESSON");
            }
            else
            {
                Console.WriteLine("You must choose lessons first");
            }
        }

        public void SeeExamsScores()
        {
            Console.Clear();
            if(CurrentTermLessons.Count== 0)
            {
                Console.WriteLine("You did not choose lesson yet");
            }
            else
            {
                foreach (Lesson lesson in CurrentTermLessons)
                {
                    string score = lesson.score > 0 ? lesson.score.ToString() : "Not Set";
                    Console.WriteLine($"Name : {lesson.Name} Score: {score}");
                }
            }
        }

        public void SendMessageToDumbleDore()
        {
            Console.Clear();
            Console.WriteLine("Type your message : ");
            string message = Console.ReadLine();
            Message m = new Message()
            {
                MessageText = message,
                studentUsername = Username,
                studentName= Name,
                sendTime= DateTime.Now,
            };
            Dumbledore.Instance.messageList.Add(m);
            Console.WriteLine("\nYour message has been sent.");

        }

        public override string ToString()
        {
            return $"Fullname:{Name} {FamillyName},Father:{Father},Gender:{Gender},BirthDay:{BirthDay},Group:{Group}";

        }

    }
}
