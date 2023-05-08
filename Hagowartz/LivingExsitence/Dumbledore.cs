using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hagowartz
{
    internal class Dumbledore:AuthorizedPersons
    {
        public static readonly Dumbledore dumbledore = new Dumbledore();

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

        public void giveLetterToStudent(Student student)
        {
            bool finded = false;
            for (int i = 0; i < studentList.Count(); i++)
            {
                if (student.Username == studentList[i].Username && student.Password == studentList[i].Password)
                {
                    finded = true;
                    if (!studentList[i].HaveLetter)
                    {
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

    }
}
