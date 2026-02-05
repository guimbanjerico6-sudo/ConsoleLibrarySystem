using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleLibrarySystem // <--- Change this name!
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryManager = new Controller.LibraryManager();
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to the Library System!");
                Console.WriteLine("1. Add a book to the shelf");
                Console.WriteLine("2. Show all books on the shelf");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. Exit");

                Console.Write("Please select an option (1-5): ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter stock quantity: ");
                    int stock = int.Parse(Console.ReadLine());
                    Console.Write("Is this a reference book? (yes/no): ");
                    bool isReference = Console.ReadLine().ToLower() == "yes";
                    libraryManager.AddItem(title, author, stock, isReference);
                }
                else if (input == "2")
                {
                    libraryManager.ShowAllItems();
                }
                else if (input == "3")
                {
                    Console.Write("Enter book title to borrow: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();
                    libraryManager.BorrowItem(title, author);
                }
                else if (input == "4")
                {
                    Console.Write("Enter book title to return: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();
                    libraryManager.ReturnItem(title, author);
                }
                else if (input == "5")
                {
                    Console.WriteLine("Thank you for using the Library System. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }

            }
        }
    }  
}

