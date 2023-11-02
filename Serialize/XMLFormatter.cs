using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialize
{

    [Serializable]
    public class XMLperson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            //Сериализация
            List<XMLperson> person = new List<XMLperson>
            {
                new XMLperson { Name = "Ваня", Age = 25 },
                new XMLperson { Name = "Вова", Age = 35 }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<XMLperson>));
            using (StreamWriter writer = new StreamWriter("XMLperson.xml"))
            {
                serializer.Serialize(writer, person);
            }

            //Десериализация
            using (StreamReader reader = new StreamReader("XMLperson.xml"))
            {
                List<XMLperson> deserializedPerson = (List<XMLperson>)serializer.Deserialize(reader);
                foreach (var XMLperson in deserializedPerson)
                {
                    Console.WriteLine($"Имя: {XMLperson.Name}, Возраст: {XMLperson.Age}");
                }
            }
        }
    }
}
