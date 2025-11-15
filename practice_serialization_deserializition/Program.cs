using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.Xml.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace practice_serialization_deserializition
{

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Abdo khaldi" ,Age =29 };

            // binary serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("person.bin", FileMode.Create))
            {
                formatter.Serialize(stream, person);
            }

            //binary  Deserialize  the object back
            using (FileStream stream = new FileStream("person.bin", FileMode.Open))
            {
                Person deserializedPerson = (Person)formatter.Deserialize(stream);
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
                
            }

            // XML serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (TextWriter writer = new StreamWriter("person.xml"))
            {
                serializer.Serialize(writer,person);
            }
            // deserialize xml
            using (TextReader reader = new StreamReader("person.xml"))
            {
                Person personSerilized = (Person)serializer.Deserialize(reader);
                Console.WriteLine($"Name : {personSerilized.Name} Age : {personSerilized.Age}");
            }

            
            // JSON serialization
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
            using (MemoryStream stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, person);
                string jsonString = System.Text.Encoding.UTF8.GetString(stream.ToArray());


                // Save the JSON string to a file (optional)
                File.WriteAllText("person.json", jsonString);
            }

            using (FileStream stream = new FileStream("person.json", FileMode.Open) )
            {
                Person serializedPerson2 = (Person)jsonSerializer.ReadObject(stream);
                Console.WriteLine($"Name : {serializedPerson2.Name} Age: {serializedPerson2.Age}");
            }
        }



    }
}
