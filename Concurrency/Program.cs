using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concurrency
{

    class Club
    {  
        public Club(string clubname, int capacity)
        {
            ClubName = clubname;
            Capacity = capacity;
            _sem = new System.Threading.SemaphoreSlim(Capacity);
        }
        public void Enter(Person obj)
        {
            Console.WriteLine(obj.Name+" wants to enter!");
            Console.WriteLine(obj.Name+"  is in the line!");
            _sem.Wait();
            Console.WriteLine(obj.Name + "  entered!");
            System.Threading.Thread.Sleep(10);
            _sem.Release();
            Console.WriteLine(obj.Name + " has left!");
        }


        private string ClubName { get; set; }
        private int Capacity { get; set; }
        private System.Threading.SemaphoreSlim _sem; 
        
    }
    class Person
    {
        public Person(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            Club hightline = new Club("Hightline",3);
            Person A = new Person("A");
            Person B = new Person("B");
            Person C = new Person("C");
            Person D = new Person("D");
            Person E = new Person("E");
            new System.Threading.Thread(()=>hightline.Enter(A)).Start();
            new System.Threading.Thread(() => hightline.Enter(B)).Start();
            new System.Threading.Thread(() => hightline.Enter(C)).Start();
            new System.Threading.Thread(() => hightline.Enter(D)).Start();
            new System.Threading.Thread(() => hightline.Enter(E)).Start();

            System.Threading.Thread.Sleep(10000);
        }  
    }
}
