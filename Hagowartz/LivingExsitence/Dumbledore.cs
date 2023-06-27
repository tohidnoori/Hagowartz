using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Dumbledore: AllowedPersons
    {
        public static readonly Dumbledore dumbledore = new Dumbledore();
        private Dumbledore()
        {
            if(groupList.Count == 0)
            {
                for(int i = 0;i< 4;i++)
                {
                    Group group = new Group();
                    group.Type = (EGroupType)i;
                    groupList.Add(group);
                }
            }
        }
        public static Dumbledore Instance
        {           
            get
            {
                return dumbledore;
            }
        }
        public string Username = "admin";
        public string Password = "1234";
        public List<Dorm> DormList { get; set; } = new List<Dorm>();
        public List<Human> humanList { get; set; } = new List<Human>();
        public List<Student> studentList { get; set; } = new List<Student>();
        public List<Teacher> teacherList { get; set; } = new List<Teacher>();
        public List<Group> groupList { get; set; } = new List<Group> ();//size 4 
        public List<Message> messageList { get; set; } = new List<Message> ();
        public List<Message> readedMessages { get; set; } = new List<Message>();

        public void giveLetterToStudent()
        {
            Console.Write("Enter student username :");
            string username = Console.ReadLine();
            bool finded = false;
            for (int i = 0; i < studentList.Count(); i++)
            {
                if (username == studentList[i].Username)
                {
                    finded = true;
                    Console.WriteLine("Correct");
                    Thread.Sleep(700);
                    Console.Clear();
                    if (!studentList[i].HaveLetter)
                    {
                        Student student = studentList[i];
                        Console.WriteLine($"Writing Letter for {student.Name} {student.FamillyName}");
                        Thread.Sleep(500);
                        Console.WriteLine($"---------------------------------------");
                        Thread.Sleep(300);

                        studentList[i].Letter.Add("Ticket Time", DateTime.Now.ToLongTimeString());
                        studentList[i].Letter.Add("Cabin Number", new Random().Next(0, 100).ToString());
                        studentList[i].Letter.Add("Chair Number", new Random().Next(1, 6).ToString());
                        Thread.Sleep(400);
                        Console.WriteLine($"Hello {student.Name} {student.FamillyName} you are wellcomed to hagowartz.");
                        Thread.Sleep(400);
                        Console.WriteLine($"We are glad to see you in hagowaartz.");
                        Thread.Sleep(400);
                        Console.WriteLine($"Here you can see your letter and know more information about your trip to hagowartz:");
                        Thread.Sleep(400);
                        Console.WriteLine($"Ticket Time:{studentList[i].Letter["Ticket Time"]}\nCabin Number:{studentList[i].Letter["Cabin Number"]}\nChair Number:{studentList[i].Letter["Chair Number"]}  ");
                        Console.WriteLine($"---------------------------------------\n");
                        studentList[i].HaveLetter = true;
                    }
                    else
                    {
                        Console.WriteLine("Student already has a letter.");
                    }

                    break;
                }
            }
            if (!finded)
            {
                Console.WriteLine("Student not found");
            }
        }

        public void showListOfStudents()
        {
            Console.WriteLine($"List of Students\t\tTotal Num:{studentList.Count}");
            foreach(Student student in studentList)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public void showListOfTeachers()
        {
            Console.WriteLine($"List of Students\t\tTotal Num:{teacherList.Count}");
            foreach (Teacher teacher in teacherList)
            {
                Console.WriteLine(teacher.ToString());
            }
        }

        public void saveDataAsJson()
        {
            String studentFile = @"E:\students data.json";
            String teacherFile = @"E:\teachers data.json";
            String groupFile = @"E:\dumbledore data.json";
            //String humanFile = @"E:\humans data.json";
            //var humanJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.humanList);
            //File.WriteAllText(humanFile, humanJsonText.ToString());

            var studentJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.studentList);
            var teacherJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.teacherList);
            var groupJsonText = JsonConvert.SerializeObject(Dumbledore.Instance.groupList);
            File.WriteAllText(studentFile, studentJsonText.ToString());
            File.WriteAllText(teacherFile, teacherJsonText.ToString());
            File.WriteAllText(groupFile, groupJsonText.ToString());
        }

        public void showNewMessages()
        {
            Console.Clear();
            if (messageList.Count > 0)
            {
                for (int i = 0; i < messageList.Count(); i++)
                {
                    Console.WriteLine($"Sender-username : {messageList[i].studentUsername} \t Sender-Name : {messageList[i].studentName} \t Sent-time : {messageList[i].sendTime} \n" +
                        $"Messsage : {messageList[i].MessageText}");
                }
                foreach (Message m in messageList)
                {
                    readedMessages.Add(m);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no new messages");
            }
            
            messageList.Clear();

        }
        public void showReadedMessages()
        {
            Console.Clear();
            if (readedMessages.Count> 0)
            {
                foreach (Message m in readedMessages)
                {
                    Console.WriteLine($"Sender-username : {m.studentUsername} \t Sender-Name : {m.studentName} \t Sent-time : {m.sendTime} \n" +
                       $"Messsage : {m.MessageText}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no readed messages");
            }
        }
    }
}
