using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Program
    {
        // Book class to store book details
        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }

        static List<Book> books = new List<Book>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ViewBooks();
                        break;
                    case "3":
                        SearchBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();

            books.Add(new Book { Id = nextId++, Title = title, Author = author });

            Console.WriteLine("Book added successfully!");
        }

        static void ViewBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            Console.WriteLine("\nBooks in the library:");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
            }
        }

        static void SearchBook()
        {
            Console.Write("Enter title or author to search: ");
            string query = Console.ReadLine().ToLower();

            var foundBooks = books.FindAll(b => b.Title.ToLower().Contains(query) || b.Author.ToLower().Contains(query));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            Console.WriteLine("\nSearch Results:");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
            }
        }

        static void DeleteBook()
        {
            Console.Write("Enter book ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = books.Find(b => b.Id == id);

                if (book != null)
                {
                    books.Remove(book);
                    Console.WriteLine("Book deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }
    }
}
