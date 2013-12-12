using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Test
{
    class Publisher
    {
        public Publisher(string name)
        {
            PublisherName = name;
        }


        public void PublishFile(string filename) {
            Console.WriteLine(PublisherName+" has published "+filename+" !");
            if (OnPublished != null) { OnPublished(this); }
        }

        public string PublisherName { get; set; }
        public delegate void PublishHandler(System.Object source);
        public event PublishHandler OnPublished;
    }

    class Subscriber
    {
        public Subscriber(string name)
        {
            SubscriberName = name;
        }
        public string SubscriberName { get; set; }
        public void GetPubliserFile(System.Object source) 
        {
            Console.WriteLine(SubscriberName+" get file from publisher: "+ source);
        }
    
    }


    


    
    class F1Student
    { 
        public F1Student(){
        }

        private string _name;
        private int _age;


        public string Name 
        { 
            get { return _name; } 
            set { _name = value; OnStatusChange(_name); }
        }
        public int Age 
        { 
            get { return _age; } 
            set { _age = value; OnStatusChange(_age); } 
        }


        public delegate void StatusHanlder(System.Object source);
        public event StatusHanlder StatusChanged;
        protected void OnStatusChange(System.Object source) {
            if (StatusChanged != null) { StatusChanged(this); }
        }
    }

    class HomeSecurity
    { 
        public HomeSecurity(){}
        internal void PersonStatusChange(System.Object source) {
            Console.WriteLine("Home Security Notification: "+source+"has changed status!");
        }
    
    }

    class Colleage
    {
        public Colleage() { }
        internal void StudentStatusChange(System.Object source)
        {
            Console.WriteLine("Colleage Notification: " + source + " has changed status!");
        }

    }


    




    class Program
    {


        public delegate int CalculationDelegate(int left, int right);

        public static int Add(int left, int right) {
            return left + right;
        }

        public static int Multiply(int left, int right) {
            return left * right;
        }

        public static int Minus(int left, int right) {
            return left - right;
        }

        public static void Main(string[] args) {

            F1Student tom = new F1Student();
            HomeSecurity hs = new HomeSecurity();
            Colleage cl = new Colleage();
            tom.StatusChanged += hs.PersonStatusChange;
            tom.StatusChanged += cl.StudentStatusChange;
            tom.Name = "Tommy";
            tom.Age = 14;


            Publisher bloomberg = new Publisher("BloomBerg");
            Publisher thomasRuters = new Publisher("ThomasRuters");
            Subscriber jack= new Subscriber("Jack");
            bloomberg.OnPublished += jack.GetPubliserFile;

            bloomberg.PublishFile("July Monthly Report");
            thomasRuters.PublishFile("ThomasRuters Daily");
            bloomberg.PublishFile("August Monthly Report");
            

             CalculationDelegate add = new CalculationDelegate(Add);
             CalculationDelegate mutiply = new CalculationDelegate(Multiply);
             CalculationDelegate minus = new CalculationDelegate(Minus);
             CalculationDelegate mutiDel = add + Multiply + minus;
             int result = mutiDel(12,3);
        }
    }
}
