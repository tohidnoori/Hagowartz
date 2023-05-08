using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool finded = false;
            String s = File.ReadAllText(@"E:\data.json");
            JArray jArray = JArray.Parse(s);
            int i = 0;
           
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
                human.Type = (EType)Enum.Parse(typeof(EType),deserializeObject.type.Replace(" ","_"),true);       
                human.Gender = (EGender)Enum.Parse(typeof(EGender), deserializeObject.gender, true);
                human.Role = (EAct)Enum.Parse(typeof(EAct), deserializeObject.role, true);

                Dumbledore.Instance.humanList.Add(human);    
                Console.WriteLine(human.ToString());
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
                                Console.WriteLine("Dumbledore Options Choose One : \n1.Give letter to the student(g) \n2.List of docters(d) \n3.List of nurse(n) \n4.List of patient(p) \n5.Main Menu(m)");
                                dumbledoreOption = Console.ReadLine();
                                switch (dumbledoreOption)
                                {
                                    case "g":
                                        Console.Write("Enter student username :");
                                        username = Console.ReadLine();
                                        Console.Write("Enter student password :");
                                        password = Console.ReadLine();
                                         finded = false;
                                        for (i = 0; i < Dumbledore.Instance.studentList.Count(); i++)
                                        {
                                            if (username == Dumbledore.Instance.studentList[i].Username && password == Dumbledore.Instance.studentList[i].Password)
                                            {
                                                finded = true;
                                                Console.WriteLine("Correct");
                                                Thread.Sleep(700);
                                                Console.Clear();
                                                
                                                Dumbledore.Instance.giveLetterToStudent(Dumbledore.Instance.studentList[i]);
                                                
                                                break;
                                            }

                                        }
                                        if (!finded)
                                        {
                                            Console.WriteLine("Student not found");
                                        }
                                        break;
                                    case "d":
                                        break;
                                    case "n":
                                        break;
                                    case "p":
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
                                    Console.WriteLine("Student options choose One : \n1.See letter(sl) \n2.Go to Hagowartz(p) \n3.Main Menu(m)");
                                    studentOption = Console.ReadLine();
                                    switch (studentOption)
                                    {
                                        case "sl":
                                            s1.showLetter();
                                            break;
                                        case "go":
                                            s1.GoToHagowartz();
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
                        for (i = 0; i < Dumbledore.Instance.humanList.Count(); i++)
                        {
                            if (Dumbledore.Instance.humanList[i].Role == EAct.Teacher)
                            {
                                if (username == Dumbledore.Instance.humanList[i].Username && password == Dumbledore.Instance.humanList[i].Password)
                                {
                                    finded = true;
                                    Console.WriteLine("Correct");
                                    Thread.Sleep(700);
                                    while (teacherOption != "m")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Nurse options choose One : \n1.Visit patient(v) \n2.Prescribe(p) \n3.Main Menu(m)");
                                        teacherOption = Console.ReadLine();
                                        String patienIdOrName;
                                        switch (teacherOption)
                                        {
                                            case "p":

                                                break;
                                            case "v":

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
                        }
                        if (!finded)
                        {
                            Console.WriteLine("Teacher not found");
                        }
                        break;
                    case "e":
                        appIsOpen = false;
                        break;
                    default:
                        Console.WriteLine("INCORRECT INPUT");
                        break;
                }
                Console.WriteLine("Enter to continue");
                Console.ReadKey();
            }
        }
    }
}
