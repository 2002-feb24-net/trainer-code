using System;
using System.Collections.Generic;
using System.Text;

namespace EfDemo
{
    public class Person
    {
        // regular simple properties like these are always loaded by EF
        public int Id { get; set; }
        public string Name { get; set; }

        // navigation properties like these are not automatically loaded.
        // we'll use "eager loading" to get them filled in.
        public List<Person> Children { get; set; }
        public Address Address { get; set; }
    }
}
