using System;
using System.Collections.Generic;
using PersonLibrary;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NewCollection<Person> list = new NewCollection<Person>("Коллекция");
            list.Add(new Worker()); list.Add(new Employee());
            NewCollection<Person> list1 = new NewCollection<Person>("Коллекция1");
            list1.Add(new Employee()); list1.Add(new Worker()); 
            Journal<Person> j = new Journal<Person>();
            Journal<Person> j1 = new Journal<Person>();
            list.CollectionCountChanged += new CollectionHandler<Person>(j.CollectionCountChanged);
            list.CollectionReferenceChanged += new CollectionHandler<Person>(j.CollectionReferenceChanged);
            list1.CollectionCountChanged += new CollectionHandler<Person>(j.CollectionCountChanged);
            list1.CollectionReferenceChanged += new CollectionHandler<Person>(j.CollectionReferenceChanged);
            list.CollectionCountChanged += new CollectionHandler<Person>(j1.CollectionCountChanged);
            list.CollectionReferenceChanged += new CollectionHandler<Person>(j1.CollectionReferenceChanged);
            list.Remove(1);
            list.Add(new Engineer());
            list[0] = new Employee();
            list1.Add(new Worker());
            Console.WriteLine(j.ToString());
            Console.WriteLine();
            Console.WriteLine(j1.ToString());
            Console.ReadLine();
        }
    }
}
