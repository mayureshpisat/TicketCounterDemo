using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicketCounterDemo
{
    public class Window
    {
        public Queue<int> People = new Queue<int>();
        public string Name {  get; set; }

        
    }
    internal class Program
    {
        public static int ArrivalTime = 0;
        public static int GlobalTime = 0;

        static void Main(string[] args)
        {
            Window w1 = new Window { Name = "A"};
            Window w2 = new Window { Name = "B"};
            Window w3 = new Window { Name = "C"};
            Window w4 = new Window { Name = "D"};

            List<Window> windows = new List<Window> { w1, w2, w3, w4 };
            StreamReader sr = new StreamReader("C:\\Users\\Mayuresh Pisat\\Documents\\BurstOfPeople.txt");

            string ln;
            while ((ln = sr.ReadLine()) != null)
            {

                //if (GlobalTime % 120 == 0 && GlobalTime != 0)
                //{
                //    //Console.WriteLine($"Global Time is {GlobalTime}");
                //    //int answer = ((windows.Count - 1) / 2 * 30) + GlobalTime;
                //    foreach (var window in windows)
                //    {
                //        if (window.People.Count > 0)
                //        {
                //            Console.WriteLine($"Waiting time for last person in {window.Name} 1 is {answer} ");

                //        }
                //    }
                //}


                int Burst = Convert.ToInt32(ln);
                ArrivalTime += 1;
                Window minWindow = w1;

                while (Burst != 0)
                {
                    minWindow = windows[0];

                    for (int i = 0; i <= 3; i++)
                    {
                        if (windows[i].People.Count < minWindow.People.Count)
                        {
                            minWindow = windows[i];
                        }
                    }

                    minWindow.People.Enqueue(1);
                    Burst -= 1;
                }
                GlobalTime += 60;


                


                foreach (var window in windows)
                {
                    
                    Console.WriteLine($"People in {window.Name} before next burst {window.People.Count}");
                }

                foreach (var window in windows)
                {
                    //Console.WriteLine($"Initial {window.People.Count}");

                    
                    if(window.People.Count != 0)
                    {
                        window.People.Dequeue();
                        //Console.WriteLine($"First Deque {window.People.Count}");
                        

                    }
                    if (window.People.Count != 0)
                    {
                        window.People.Dequeue();
                        //Console.WriteLine($"Second Deque {window.People.Count}");
                    }


                    


                }
                Console.WriteLine("\n");
                Console.WriteLine("*************People in windows after burst**************");
                foreach (var window in windows)
                {
                    Console.WriteLine($" People in {window.Name} : {window.People.Count}");

                }


                Console.WriteLine("**********Arrival Time Logic************");

                if (ArrivalTime%2 == 0)
                {
                    int WaitingTimeOfAlternatePerson;

                    foreach (var window in windows)
                    {
                        WaitingTimeOfAlternatePerson = ((window.People.Count - 1) / 2) * 30;
                        Console.WriteLine($"Arrival Time is {ArrivalTime} so {window.Name}'s Last person has the waiting count of {WaitingTimeOfAlternatePerson}");

                    }


                }

                Console.WriteLine("\n");
                Console.WriteLine("\n");


            }








        }
    }
}

