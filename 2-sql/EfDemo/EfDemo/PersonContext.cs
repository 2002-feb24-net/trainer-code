using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EfDemo
{
    // this context class represents the whole database
    public class PersonContext : DbContext
    {
        // you need DbSet properties, one per table (one per type of data you want to store)
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // in order to connect to any database (or many other kinds of data source)
        // we need a "connection string"

        // we need to give each DbContext instance a connection string...
        // one clumsy hardcoded easy one is OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // there's multiple kinds of SQL
            // SQLite - lightweight, quick to set up, and can store the DB in one file
            // SQL Server - Microsoft's preferred version of SQL
            //       lowercase "SQL server" refers to any software that can provide access to SQL DB over internet
            //       "SQL Server" (capital) is Microsoft's version of that software.

            // need another package for this (Microsoft.EntityFrameworkCore.Sqlite)
            //optionsBuilder.UseSqlite("Data Source=../../../person.db");

            // need another package for this (Microsoft.EntityFrameworkCore.SqlServer)
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            // ^ this line will have a compile error when you clone it... because my SecretConfiguration
            // file is gitignored. you need to make your own if you want to run this code on your laptop,
            // like this:

            /*
namespace EfDemo
{
    internal class SecretConfiguration
    {
        internal const string ConnectionString = "(connection string here)";
    }
}
             */
        }
    }
}
