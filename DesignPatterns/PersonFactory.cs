using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{

    public class Person 
    {
        protected readonly int ID;
        protected string Name;

        public Person(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
        public override string ToString()
        {
            string str = $"ID: {ID}, Name: {Name}";
            return str;
        }
    }
    public class PersonFactory
    {
        private List<Person> people = new List<Person>();
        public PersonFactory() { }

        int GetCount()
        {
            return people.Count;
        }
        public List<Person> GetPeople()
        {
            return this.people;
        }

        public Person CreatePerson(string name)
        {
            Person person = new Person(GetCount(), name);
            people.Add(person);
            return person;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Person person in people)
            {
                sb.Append(person.ToString());
            }
            return sb.ToString();
        }
    }

}
