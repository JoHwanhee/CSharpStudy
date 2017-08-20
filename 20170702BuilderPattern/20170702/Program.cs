using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace _20170702
{
    public class Person
    {
        string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    
    public class PersonBuilder 
    {
        string name;
        private int age;

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public PersonBuilder() { }


        public Person Build()
        {
            return new Person(name, age);
        }

    }

    class Program
    {

        static void Main()
        {
            PersonBuilder builder = new PersonBuilder();
            builder.SetAge(20);
            builder.SetName("");
            Person p = builder.Build();
            
        }
    }
}
