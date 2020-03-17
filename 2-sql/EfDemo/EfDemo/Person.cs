using System;
using System.Collections.Generic;
using System.Text;

namespace EfDemo
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Children { get; set; }
    }
}
