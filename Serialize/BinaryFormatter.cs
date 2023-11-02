using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

[Serializable]
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class BinarySerialize
{
    static void Main(string[] args)
    {
        Person person = new Person { Name = "Максим", Age = 19 };

        // Сирилизация
        using (FileStream file = new FileStream("person.json", FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, person);
        }

        // Дисириализация
        using (FileStream file = new FileStream("person.json", FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Person deserializedPerson = (Person)formatter.Deserialize(file);
            Console.WriteLine($"Имя: {deserializedPerson.Name}, Возраст: {deserializedPerson.Age}");
        }
    }
}
