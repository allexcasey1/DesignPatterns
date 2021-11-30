using System;
using static DesignPatterns.ClassElement;
using static DesignPatterns.Person;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new CodeBuilder("Test");
            builder.AddField("id", "int").AddField("name", "string");
            Console.WriteLine(builder.ToString());

            var factory = new PersonFactory();
            factory.CreatePerson("Alex");
            factory.CreatePerson("Anthony");
            factory.CreatePerson("Josiah");
            var people = factory.GetPeople();
            Console.WriteLine(factory.ToString());

        }
    }
}
