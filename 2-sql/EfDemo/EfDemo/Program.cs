using System;
using System.Linq;
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

            // to connect to the database, you need an instance of your context class.
            // it's very much IDisposable
            using (var context = new PersonContext())
            {
                // quick and dirty way to create the database with all the tables, columns, etc.
                //     which the context expects to see. but if the DB already exists, does nothing.
                context.Database.EnsureCreated();
                // (watch out, if you change the structure of the objects your context uses,
                //  then EF might fail at runtime. delete the db file to fix this with a new database.)

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
