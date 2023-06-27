using Hagowartz.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Teacher : AllowedPersons
    {
        public Teacher(Human h) : base(h) { }
        public Teacher()
        {

        }
        public bool SimultaneousTeaching { get; set; }
                public override string ToString()
        {
            return $"Fullname:{Name} {FamillyName},Father:{Father},Gender:{Gender},BirthDay:{BirthDay}";

        }

        public void ShowGroups(EGroupType e)
        {
            if (Dumbledore.Instance.groupList[(int)e].GroupMembers.Count==0)
            {
                Console.WriteLine($"\nThere is no one in {e.ToString()} group.");
            }
            else
            {
                Console.WriteLine($"\nGroup name {e}\t\tParticipants num:{Dumbledore.Instance.groupList[(int)e].GroupMembers.Count}\n");
                var i = 1;
                foreach (Student st in Dumbledore.Instance.groupList[(int)e].GroupMembers)
                {
                    Console.WriteLine($"{i}.{st.Name} {st.FamillyName}");
                    i++;
                }
            }
            
        }

        public void FinallizeStudentScores()
        {
            Console.Clear();
            Console.WriteLine("Write student username to continue");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            bool finded = false;
            for (int i = 0; i < Dumbledore.Instance.studentList.Count(); i++)
            {
                if (username == Dumbledore.Instance.studentList[i].Username)
                {
                    finded = true;
                    Student student = Dumbledore.Instance.studentList[i];
                    Console.WriteLine("Correct");
                    Thread.Sleep(700);
                    Console.Clear();
                    Console.WriteLine("Checking Student's information");
                    Thread.Sleep(400);
                    Console.WriteLine("......");
                    Thread.Sleep(400);
                    Console.WriteLine("....");
                    Thread.Sleep(400);
                    Console.WriteLine("..");
                    Console.Clear();
                    Console.WriteLine("Ok");
                    Thread.Sleep(400);
                    Console.Clear();
                    if (student.CurrentTermLessons.Count>0)
                    {
                        student.SeeExamsScores();
                        int counter = 0;
                        foreach(Lesson ls in student.CurrentTermLessons)
                        {
                            if (ls.score == 0)
                            {
                                counter++;
                            }
                        }
                        if (counter != 0)
                        {
                            Console.WriteLine($"\nWe can't finallize scores of this student cause {counter} lessons of this student is not setted.");
                        }
                        else
                        {
                            Console.WriteLine($"\nIf you wanna finallize the scores of this student write yess and enter");
                            if (Console.ReadLine() == "yes")
                            {
                                int passedCounter = 0;
                                int failedCounter = 0;
                                string passedLesson = "";
                                string failedLesson = "";

                                foreach (Lesson ls in student.CurrentTermLessons)
                                {
                                    if (ls.score < 10)
                                    {
                                        failedCounter++;
                                        failedLesson += $"{ls.Name}:{ls.score}=> :(\n";
                                        Lesson ls1 = ls;
                                        ls1.score = 0;
                                        student.FailedLessons.Add(ls1);
                                    }
                                    else
                                    {
                                        passedCounter++;
                                        passedLesson += $"{ls.Name}:{ls.score}=> :)\n";
                                       student.PassedLessons.Add(ls);
                                    }
                                }
                                student.CurrentTermLessons.Clear();
                                student.Term++;
                                Dumbledore.Instance.saveDataAsJson();
                                Console.Clear();
                                Console.WriteLine($"Student {student.Name} {student.FamillyName} passed {passedCounter} and failed {failedCounter} lessons : \n");
                                Console.WriteLine("Passed Lessons :\n");
                                Console.WriteLine(passedLesson);
                                Console.WriteLine("Failed Lessons :\n");
                                Console.WriteLine(failedLesson);
                            }
                            else
                            {
                                Console.WriteLine("You cancel the process of finallizing this student scores.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You did not choose lesson yet");
                    }

                    break;
                }
            }
            if (!finded)
            {
                Console.WriteLine("Student not found");
            }
        }

        public void AddingLessonByTeacher()
        {
            Console.Clear();
            Lesson ls = new Lesson();
            Console.WriteLine("Enter the term you wanna make lesson for: ");
            ls.OfferedTerm = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter lesson name: ");
            ls.Name = Console.ReadLine();
            Console.WriteLine("Enter lesson capicity: ");
            ls.Capicity = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Enter the time lesson will be held: ");
            ls.Time = Console.ReadLine();
            LessonMangement.Instance.AddingLessonByTeacher(ls);
            Console.WriteLine($"Your lesson has been added to term{ls.OfferedTerm} lessons");
        }
    }
}
