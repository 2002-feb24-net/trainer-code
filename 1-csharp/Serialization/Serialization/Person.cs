using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Children { get; set; } = new List<Person>();
    }
}
