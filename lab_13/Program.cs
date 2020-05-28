using System;
using System.Collections.Generic;
using PersonLibrary;

namespace lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            NewCollection<Person> list = new NewCollection<Person>("Коллекция 1");
            list.Add(new Worker()); list.Add(new Employee()); list.Add(new Engineer()); list.Add(new Employee());
            NewCollection<Person> list1 = new NewCollection<Person>("Коллекция 2");
            list1.Add(new Employee()); list1.Add(new Worker()); list1.Add(new Employee()); list1.Add(new Engineer());
            foreach (Person p in list)
                p.Show();
            Console.WriteLine("");
            foreach (Person p in list1)
                p.Show();
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
            list1.Remove(1);
            list1.Add(new Worker());
            list1[0] = new Worker();
            Console.WriteLine(Environment.NewLine+"Изменения в коллекциях:");
            Console.WriteLine(j.ToString());
            Console.WriteLine("Изменения в первой коллекции:");
            Console.WriteLine(j1.ToString());

            Console.WriteLine("После изменения:");
            foreach (Person p in list)
                p.Show();
            Console.WriteLine("");
            foreach (Person p in list1)
                p.Show();
            Console.ReadLine();
        }
    }
}
