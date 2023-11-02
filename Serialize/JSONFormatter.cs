using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Serialize
{
    [DataContract]
    class JSONperson
    {
        [DataMember]
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            JSONperson petr = new JSONperson { Name = "Петя", Age = 20 };
            JSONperson serega = new JSONperson { Name = "Сережа", Age = 21 };
            // Сериализация
            Dictionary<string, JSONperson> personDictionary = new Dictionary<string, JSONperson>
            {
                { "petya20", petr },
                { "sergey21", serega }
            };

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, JSONperson>));
            using (FileStream stream = new FileStream("JSONperson.json", FileMode.Create))
            {
                serializer.WriteObject(stream, personDictionary);
            }

            // Десериализация
            using (FileStream stream = new FileStream("JSONperson.json", FileMode.Open))
            {
                Dictionary<string, JSONperson> deserializedPerson = (Dictionary<string, JSONperson>)serializer.ReadObject(stream);
                foreach (var kkey in deserializedPerson)
                {
                    Console.WriteLine($"Ключ: {kkey.Key}, Имя: {kkey.Value.Name}, Возраст: {kkey.Value.Age}");
                }
            }
        }
    }
}
