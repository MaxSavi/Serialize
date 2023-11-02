using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialize
{
    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public Book()
        {
        }

        public Book(string title, string author, int year, double price)
        {
            Title = title;
            Author = author;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Год: {Year}, Цена: {Price}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание и сериализация
            Book HarryPotterBook = new Book("Гарри Поттер", "Джоан Кэтлин", 1990, 999.99);
            Book MyMyBook = new Book("МуМу", "Иван Тургенев", 1854, 1138.50);

            List<Book> books = new List<Book> { HarryPotterBook, MyMyBook };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books);
            }

            // Десериализация и вывод
            using (StreamReader reader = new StreamReader("books.xml"))
            {
                List<Book> deserializedBooks = (List<Book>)serializer.Deserialize(reader);
                foreach (var book in deserializedBooks)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
}