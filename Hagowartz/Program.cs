using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var i = 0;

            bool finded = false;
            String s = File.ReadAllText(@"E:\data.json");
            String studentFile = @"E:\students data.json";
            String teacherFile = @"E:\teachers data.json";
            String humanFile = @"E:\humans data.json";
            String groupFile = @"E:\dumbledore data.json";

            if (!File.Exists(studentFile) && !File.Exists(teacherFile))
            {
                
                ConvertJsonFileToHumanList(s);

                var studentJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.studentList);
                var teacherJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.teacherList);
                var humanJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.humanList);
                var groupJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.groupList);
                File.WriteAllText(groupFile, groupJsonText.ToString());

                File.WriteAllText(studentFile, studentJsonText.ToString());
                File.WriteAllText(teacherFile, teacherJsonText.ToString());
                File.WriteAllText(humanFile, humanJsonText.ToString());
                File.WriteAllText(groupFile, groupJsonText.ToString());
            }
            else
            {
                Dumbledore.Instance.studentList = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentFile.ToString()));
                Dumbledore.Instance.teacherList = JsonConvert.DeserializeObject<List<Teacher>>(File.ReadAllText(teacherFile.ToString()));
                Dumbledore.Instance.humanList = JsonConvert.DeserializeObject<List<Human>>(File.ReadAllText(studentFile.ToString()));
                Dumbledore.Instance.groupList = JsonConvert.DeserializeObject<List<Group>>(File.ReadAllText(groupFile.ToString()));
           
            }
            bool appIsOpen = true;
            while (appIsOpen)
            {
                Console.Clear();
                Console.WriteLine("Choose One :\n1.Dumbledore(d) \n2.Student(s) \n3.Teacher(t) \n4.Exit App(e)");
                String username, password;
                switch (Console.ReadLine())
                {
                    case "d":
                        Console.Write("Enter Dumbledore username :");
                         username = Console.ReadLine();
                        Console.Write("Enter Dumbledore password :");
                         password = Console.ReadLine();
                        if (username == Dumbledore.Instance.Username && password == Dumbledore.Instance.Password)
                        {
                            Console.WriteLine("Correct");
                            Thread.Sleep(700);
                            string dumbledoreOption = "";
                            while (dumbledoreOption != "m")
                            {
                                Console.Clear();
                                Console.WriteLine("Dumbledore Options Choose One : \n1.Give letter to the student(g) \n2.List of Students(s) \n3.List of Teachers(t) \n4.Main Menu(m)");
                                dumbledoreOption = Console.ReadLine();
                                switch (dumbledoreOption)
                                {
                                    case "g":
                                        Dumbledore.Instance.giveLetterToStudent();
                                        break;
                                    case "s":
                                        Dumbledore.Instance.showListOfStudents();
                                        break;
                                    case "t":
                                        Dumbledore.Instance.showListOfTeachers();
                                        break;
                                    case "m":
                                        Console.Write("Sending you to main menu => ");
                                        break;
                                    default:
                                        Console.WriteLine("INCORRECT INPUT");
                                        break;
                                }
                                if (dumbledoreOption != "m")
                                {
                                    Console.WriteLine("Enter to continue");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                        }
                        break;
                    case "s":
                        String studentOption = "";
                        Console.Write("Enter student username :");
                         username = Console.ReadLine();
                        Console.Write("Enter student password :");
                         password = Console.ReadLine();
                        for (i = 0 ; i < Dumbledore.Instance.studentList.Count(); i++)
                        {
                            if (username == Dumbledore.Instance.studentList[i].Username && password == Dumbledore.Instance.studentList[i].Password)
                            {
                                finded = true;
                                Console.WriteLine("Correct");
                                Thread.Sleep(700);
                                Student s1 = Dumbledore.Instance.studentList[i];
                                while (studentOption != "m")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Student options choose One : \n1.See letter(sl) \t2.Go to Hagowartz(go) \n3.Take Exam(tx) \t4.See Exams Scores(se) \n3.Choose lesson(cl) \t4.Main Menu(m)");
                                    studentOption = Console.ReadLine();
                                    switch (studentOption)
                                    {
                                        case "sl":
                                            s1.showLetter();
                                            break;
                                        case "go":
                                            s1.GoToHagowartz();
                                            break;
                                        case "cl":
                                            s1.ChooseLessons();
                                            break;
                                        case "se":
                                            s1.SeeExamsScores();
                                            break;
                                        case "tx":
                                            Random rand = new Random();
                                            Console.WriteLine(rand.Next(7, 20));
                                            s1.TakeExam(rand.Next(7,20));
                                            break;
                                        case "m":
                                            Console.Write("Sending you to main menu => ");
                                            break;
                                        default:
                                            Console.WriteLine("INCORRECT INPUT");
                                            break;
                                    }
                                    if (studentOption != "m")
                                    {
                                        Console.WriteLine("Enter to continue");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            }

                        }
                        if (!finded)
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;
                    case "t":
                        String teacherOption = "";
                        Console.Write("Enter teacher username :");
                        username = Console.ReadLine();
                        Console.Write("Enter teacher password :");
                        password = Console.ReadLine();
                         finded = false;
                        for (i = 0; i < Dumbledore.Instance.teacherList.Count(); i++)
                        {
                            if (username == Dumbledore.Instance.teacherList[i].Username && password == Dumbledore.Instance.teacherList[i].Password)
                            {
                                Teacher theTeacher = Dumbledore.Instance.teacherList[i];
                                finded = true;
                                Console.WriteLine("Correct");
                                Thread.Sleep(700);
                                while (teacherOption != "m")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Teacher options choose One : \n1.Visit patient(v) \n2.Prescribe(p) \n4.Show groups(sg) \n3.Main Menu(m)");
                                    teacherOption = Console.ReadLine();
                                    switch (teacherOption)
                                    {
                                        case "p":

                                            break;
                                        case "sg":
                                            Console.WriteLine("Choose one group from :  Hufflepuff(h), Gryffindor(g), Ravenclaw(r), Slytherin(s)");
                                            string chooseOption = Console.ReadLine();
                                            switch (chooseOption)
                                            {
                                                case "h":
                                                    theTeacher.ShowGroups(EGroupType.Hufflepuff);
                                                    break;
                                                case "g":
                                                    theTeacher.ShowGroups(EGroupType.Gryffindor);
                                                    break;
                                                case "r":
                                                    theTeacher.ShowGroups(EGroupType.Ravenclaw);
                                                    break;
                                                case "s":
                                                    theTeacher.ShowGroups(EGroupType.Slytherin);
                                                    break;
                                                default:
                                                    Console.WriteLine("INCORRECT INPUT");
                                                    break;
                                            }
                                            break;
                                        case "m":
                                            Console.Write("Sending you to main menu => ");
                                            break;
                                        default:
                                            Console.WriteLine("INCORRECT INPUT");
                                            break;
                                    }
                                    if (teacherOption != "m")
                                    {
                                        Console.WriteLine("Enter to continue");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            }
                        }
                        if (!finded)
                        {
                            Console.WriteLine("Teacher not found");
                        }
                        break;
                    case "e":
                        appIsOpen = false;
                        Dumbledore.Instance.saveDataAsJson();

                        break;
                    default:
                        Console.WriteLine("INCORRECT INPUT");
                        break;
                }
                Console.WriteLine("Enter to continue");
                Console.ReadKey();
            }
        }

        public static void ConvertJsonFileToHumanList(string path)
        {
            JArray jArray = JArray.Parse(path);
            foreach (JObject result in jArray)
            {
                var deserializeObject = JsonConvert.DeserializeObject<JsonDataParser>(result.ToString());
                Human human = new Human();
                human.Name = deserializeObject.name;
                human.BirthDay = deserializeObject.dateOfBirth;
                human.FamillyName = deserializeObject.family;
                human.Father = deserializeObject.father;
                human.Username = deserializeObject.username;
                human.Password = deserializeObject.password;
                human.Father = deserializeObject.father;
                human.Type = (EType)Enum.Parse(typeof(EType), deserializeObject.type.Replace(" ", "_"), true);
                human.Gender = (EGender)Enum.Parse(typeof(EGender), deserializeObject.gender, true);

                human.Role = (EAct)Enum.Parse(typeof(EAct), deserializeObject.role, true);
                if (human.Role == EAct.Student)
                {
                    Dumbledore.Instance.studentList.Add(new Student(human));
                }
                else
                {
                    Dumbledore.Instance.teacherList.Add(new Teacher(human));

                }

                Dumbledore.Instance.humanList.Add(human);
                Console.WriteLine(human.ToString());
            }

        }

        public static int giveRandomNum(int min,int max)
        {
            Random rand = new Random();
           return rand.Next(min, max);
        }

       
    }
}
