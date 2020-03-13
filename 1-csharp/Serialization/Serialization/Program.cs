using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static async Task Main(string[] args)
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

                try
                {
                    await WriteToFileAsync(json1, filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fatal error");
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else
            {
                // read JSON from the file
                string json3 = await ReadFromFileAsync(filePath);
                // and deserialize it
                data = JsonSerializer.Deserialize<List<Person>>(json3);
            }
            ModifyPersons(data);

            string json2 = ConvertToJson(data);

            try
            {
                await WriteToFileAsync(json2, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error");
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private async static Task<string> ReadFromFileAsync(string filePath)
        {
            // using block is the same as
            // try-finally-not null-dispose but way quicker to write and look at
            //using (var sr = new StreamReader(filePath))
            //{
            //    string text = sr.ReadToEnd();
            //    return text;
            //}

            // newer syntax for the same thing, using statement
            using var sr = new StreamReader(filePath);
            // async:
            Task<string> textTask = sr.ReadToEndAsync();
            // at this point, the operation might have already started
            string text = await textTask;

            // the await keyword pauses THIS method right here,
            // *while still letting operations in the rest of the program continue*
            // (e.g. other ongoing Tasks)

            return text;
            // (sr is disposed when this block ends, when this method returns)
        }

        private static void ModifyPersons(List<Person> data)
        {
            foreach (var person in data)
            {
                person.Id++;
            }
        }

        private async static Task WriteToFileAsync(string text, string path)
        {
            // exception handling is important for good user experience
            // as well as data correctness etc

            // opening a file is something that definitely could go wrong
            // it's code that we expect to sometimes throw an exception
            // any code like that, we should put in a try {} block.

            FileStream file = null;
            try
            {
                file = new FileStream(path, FileMode.Create);
                // convert the string into an array of binary data (in UTF-8 encoding)
                byte[] data = Encoding.UTF8.GetBytes(text);

                await file.WriteAsync(data);
            }
            //catch
            //{
            //   // we can catch ANY exception... this is bad practice
            //}
            catch (UnauthorizedAccessException ex)
            {
                // useful properties of the exception:
                // Message, StackTrace, InnerException
                Console.WriteLine($"Access to file {path} is not allowed by the OS:");
                Console.WriteLine(ex.Message);
                throw; // rethrows the exception to be caught again higher up the call stack.
            }
            finally
            {
                if (file != null)
                {
                    //file.Close();
                    file.Dispose();
                }
            }
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
