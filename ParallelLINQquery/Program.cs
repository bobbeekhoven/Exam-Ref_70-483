using System;
using System.Linq;

namespace ParallelLINQquery
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }

        // Listing 1-10 Exceptions in queries
        public static bool CheckCity(string name)
        {
            if (name == "")
                throw new ArgumentException(name);
            return name == "Seattle";
        }

        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person { Name = "Alan", City = "Hull"},
                new Person { Name = "Beryl", City = "Seattle"},
                new Person { Name = "Charles", City = "London"},
                new Person { Name = "David", City = "Seattle"},
                new Person { Name = "Eddy", City = "Paris"},
                new Person { Name = "Fred", City = "Berlin"},
                new Person { Name = "Gordon", City = "Hull"},
                new Person { Name = "Henry", City = "Seattle"},
                new Person { Name = "Isaac", City = "Seattle"},
                new Person { Name = "James", City = "London"}
            };

            // Listing 1-8 Identifying elements of a parallel query as sequential
            //var result = (from person in people.AsParallel()
            //              where person.City == "Seattle"
            //              orderby (person.Name)
            //              select new
            //              {
            //                  Name = person.Name
            //              }).AsSequential().Take(4);

            // Listing 1-7 Using AsOrderered to preserve data ordering
            //var result = from person in
            //ParallelQuery <Person> result = from person in
            //    people.AsParallel().AsOrdered()

            // Listing 1-6 Informing Parallelization
            //var result = from person in people.AsParallel().
            //ParallelQuery<Person> result = from person in people.AsParallel().
            //             WithDegreeOfParallelism(4).
            //             WithExecutionMode(ParallelExecutionMode.ForceParallelism)

            // Listing 1-5 A parallel LINQ querry
            //var result = from person in people.AsParallel()
            //ParallelQuery<Person> result = from person in people.AsParallel()
            //where person.City == "Seattle"
            //select person;

            // foreach needed for listings 1-5 till 1-8
            //foreach (var person in result)
            //{
            //    Console.WriteLine(person.Name);
            //}

            // Listing 1-9
            //var result = from person in
            //ParallelQuery<Person> result = from person in
            //    people.AsParallel()
            //             where person.City == "Seattle"
            //             select person;
            //result.ForAll(person => Console.WriteLine(person.Name));

            try
            {
                var result = from person in
                    people.AsParallel()
                             where CheckCity(person.City)
                             select person;
                result.ForAll(Person => Console.WriteLine(Person.Name));
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + " exceptions.");
            }

            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
