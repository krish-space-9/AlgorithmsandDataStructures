using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Code\NewStuff\ClassLibrary1\ConsoleApplication1\json1.json";
            using (StreamReader sr = new StreamReader(file))
            {
                string content = sr.ReadToEnd();
                List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(content);
            }


            using (StreamReader sr = new StreamReader(file))
            using (JsonTextReader reader = new JsonTextReader(sr))
            while(reader.Read())
            {
                    Console.WriteLine(reader.TokenType.ToString(), reader.Value);
            }
            Console.ReadLine();
        }
    }

    class Person
    {
        public string Name { get; set; }

        public string City { get; set; }

        public int Age { get; set; }
    }
}
