using System;

namespace BehaviorS
{
    class Parent
    {
        private string name;
        private int age;

        public Parent(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        
        public virtual void setNameAge(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

        public virtual void getNameAge()
        {
            Console.WriteLine("Parent Name = {0}; Age = {1}", this.name, this.age);
        }
    }

    class Child : Parent
    {
        private string c_name;
        private int c_age;
        
        public Child(string name, int age, string cname, int cage) : base(name, age)
        {
            c_name = cname;
            c_age = cage;
        }

        public override void setNameAge(string _name, int _age)
        {
            c_name = _name;
            c_age = _age;
        }

        public void getPNameAge()
        {
            base.getNameAge();
        }

        public override void getNameAge()
        {
            Console.WriteLine("Child Name = {0}; Age = {1}", this.c_name, this.c_age);
        }
        
        
    }
    
    class Start
    {
        static void Main(string[] args)
        {
            foreach (string s in args)
            {
                Console.WriteLine(s);
            }
            
            var P = new Parent("John", 33);
            var C = new Child("Johnson", 43, "Johni", 12);
            C.getNameAge();
            P.getNameAge();
            C.getPNameAge();
            C.setNameAge("Tonni", 13);
            C.getNameAge();
        }
    }
}