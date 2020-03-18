using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // we have a desire to keep data persistent while the program is not running
            // or maybe, to share the same data source across multiple copies of the running program.

            // one way we can achieve that is with serialization to files like we coded last week, with XML, JSON, etc.

            // there are various problems with that approach.
            // it's slow: to change one thing, i have to load the whole file, deserialize the whole file,
            // reserialize the whole thing, and write it back to disk

            // way 1 to store data: C# objects (reference types, value types, fields/properties have object-to-object
            //  references... collections (convenient, works well with code, but not persistent
            // way 2 to store data: serialized as XML, JSON, or something similar (persistent, but awkward)
            // way 3: relational database (SQL database)
            // it's persistent, but it's very well optimized for querying data without having to load
            // anything beyond exactly the data you want. optimized for making changes quickly

            // how relational databases treat data, what are the basic buliding blocks
            // tables, rows, and columns.
            // one table for each kind of data
            // a table has one column for each property that kind of data can have
            // each row has some value for each column, because it represents one instance of that kind of data.

            // because tables, rows, and columns are quite different to how C# represents objects,
            // just like how we used a serializer library (System.Text.Json) to handle the translation details,
            // we'll use something called an ORM (object-relational mapper) to handle that with SQL databases.

            // in .NET, the main ORM is Entity Framework.
            //    in .NET Framework, we're up to EF 6.
            //    in .NET Core, we're up to EF Core 3.1 (same version as .NET Core itself)

            // EF Core does come from Microsoft, but it isn't part of CoreFx (the Standard Libraries)...
            // it's a handful of other assemblies, and .NET Core lets us use NuGet to automatically manage
            // any dependencies like that which we need to download and have connected to our own assemblies
            // so the CLR can run them.

            // in the command-line, we use `dotnet add <package>`
            // in VS, we can use the Package Manager GUI

            // when we run "dotnet run" or click run from visual studio...
            // 1. dotnet restore (tells nuget to download any missing packages)
            // 2. dotnet build (compiles the code to assemblies)
            // 3. dotnet run (runs the code in the CLR)

            // ---------------------------
            Setup();

            Console.WriteLine("Enter a person ID:");

            int id = int.Parse(Console.ReadLine());

            // get that Person from the DB by ID.
            using (var context = new PersonContext())
            {
                // broken code that forgot to load the Address
                //var person = context.Persons.First(p => p.Id == id);

                // correct code that uses eager loading to get the address as well.
                var person = context.Persons
                    .Include(p => p.Address)
                    .First(p => p.Id == id);
                // navigation properties are always going to be null
                // unless you tell EF to fill them in with .Include().

                // print his name and address.
                var address = person.Address; // <-- (before, using the broken code: this is null.. why)
                
                // with SQL and by extension, with EF...
                // when you load an object, you only get its simple data, string, int, etc.
                // you don't get it's object-to-object references (navigation properties) filled in. they remain null

                // you have to tell EF to fill those references in. there's three ways,
                // we'll focus on one, called eager loading.


                var addressString = person.Address.City + ", " + person.Address.State;
                Console.WriteLine($"Found person {person.Name}, in {addressString}.");

                // prompt to modify the name
                Console.Write("Enter a new name: ");
                string input = Console.ReadLine();
                person.Name = input; // because this entity is "tracked", by coming out of the DbSet...
                                    // this change is picked up by SaveChanges.

                // push those changes back to the DB.
                context.SaveChanges();
            }

            // prompt for an ID and a name to add as a new person (call your method)
            Console.Write("ID of person to add: ");
            int id2 = int.Parse(Console.ReadLine());
            Console.Write("Name of person to add: ");
            string name = Console.ReadLine();
            AddPerson(id2, name);

            // prompt for the name of a person to delete. (call your method)
            Console.Write("Name of person to delete: ");
            string name2 = Console.ReadLine();
            DeletePersonByName(name2);
        }

        public static void DeletePersonByName(string name)
        {
            using var context = new PersonContext();

            // get him out of the DbSet
            Person toBeDeleted = context.Persons.First(p => p.Name == name);

            // tell the DbSet to remove him
            context.Persons.Remove(toBeDeleted);

            // save changes
            context.SaveChanges();
        }

        public static void AddPerson(int id, string name)
        {
            using var context = new PersonContext();

            var person = new Person
            {
                Id = id,
                Name = name
            };

            context.Persons.Add(person);

            context.SaveChanges();
        }

        public static void Setup()
        {
            // to connect to the database, you need an instance of your context class.
            // it's very much IDisposable
            using (var context = new PersonContext())
            {
                // quick and dirty way to create the database with all the tables, columns, etc.
                //     which the context expects to see. but if the DB already exists, does nothing.
                //context.Database.EnsureCreated();
                // (watch out, if you change the structure of the objects your context uses,
                //  then EF might fail at runtime. delete the db file to fix this with a new database.)

                // instead of using EnsureCreated, the proper way to update the database's structure
                // based on your C# code is migrations.
                // a migration is a reversible set of changes to make to a database's structure.
                // you then apply the migration to actually make the changes to the DB.

                // if there are no persons, then add the initial data.
                if (!context.Persons.Any())
                {
                    var person = new Person
                    {
                        Id = 1,
                        Name = "Fred",
                        Address = new Address
                        {
                            Id = 1,
                            Street = "123 Main St",
                            City = "Fort Worth",
                            State = "TX"
                        }
                    };

                    // this doesn't modify the database YET.
                    context.Persons.Add(person);

                    // to apply the changes that you've "prepped" on this context instance:
                    context.SaveChanges();
                }

                // regardless, modify Fred's name

                // first, load fred from the database (First is a LINQ method)
                var fred = context.Persons.First(p => p.Name.StartsWith("Fred"));

                Console.WriteLine(fred.Name);

                fred.Name += "+";

                // the context "tracks" the ojbects you extract from it
                // and any changes you make to those objects it will pick up on and apply with SaveChanges
                context.SaveChanges();
                // yes, you can call savechanges twice on one context
            }
        }
    }
}
