using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // in .NET, for XML serialization, we have
            //   - DataContractSerializer
            //   - XMLSerializer (old, non-generic)
            //  for JSON serialization, we have
            //    - JSON.NET aka Newtonsoft JSON (third-party)
            //    - DataContractSerializer
            //    - System.Text.Json (brand new)  (we'll use this one today)

            string filePath = "../../../data.json";

            List<Person> data = null;
            if (!File.Exists(filePath))
            {
                data = GetInitialData();

                string json1 = ConvertToJson(data);

                WriteToFile(json1, filePath);
            }
            else
            {
                // read JSON from the file
                // and deserialize it
            }
            ModifyPersons(data);

            string json2 = ConvertToJson(data);

            WriteToFile(json2, filePath);

        }

        private static void ModifyPersons(List<Person> data)
        {
            // do something to the persons to change that data
        }

        private static void WriteToFile(string text, string path)
        {
            var file = new FileStream(path, FileMode.Create);
            // convert the string into an array of binary data (in UTF-8 encoding)
            byte[] data = Encoding.UTF8.GetBytes(text);

            file.Write(data);

            file.Close();
        }

        static string ConvertToJson(List<Person> data)
        {
            // uses System.Text.Json
            return JsonSerializer.Serialize(data);
        }

        static List<Person> GetInitialData()
        {
            var list = new List<Person>();
            var nick = new Person();
            nick.Id = 1;
            nick.Name = "Nick";

            var mark = new Person();
            mark.Id = 2;
            mark.Name = "Mark";
            mark.Children = new List<Person>
            {
                new Person { Id = 3, Name = "Ethan" },
                new Person { Id = 4, Name = "Hope" },
                new Person { Id = 5, Name = "Maya" }
            };

            list.Add(nick);
            list.Add(mark);
            return list;
        }
    }
}
