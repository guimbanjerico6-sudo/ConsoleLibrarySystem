using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static ConsoleLibrarySystem.Controller;

namespace ConsoleLibrarySystem // <--- Change this name!
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryManager = new LibraryManager();

            while (true)
            {
                Console.Clear(); // Clears the screen so it looks cleaner
                Console.WriteLine("========================================");
                Console.WriteLine("      WELCOME TO THE LIBRARY SYSTEM     ");
                Console.WriteLine("========================================");
                // notice: "Add a book" is GONE from here!
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. Borrow a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. Admin Mode (Managers Only) 🔒");
                Console.WriteLine("5. Exit");
                Console.WriteLine("========================================");

                Console.Write("Please select an option (1-5): ");
                string input = Console.ReadLine();

                if (input == "1") // Was option 2
                {
                    libraryManager.ShowAllItems();
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
                else if (input == "2") // Was option 3
                {
                    Console.Write("Enter book title to borrow: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();
                    libraryManager.BorrowItem(title, author);
                    Console.ReadLine(); // Pause to see result
                }
                else if (input == "3") // Was option 4
                {
                    Console.Write("Enter book title to return: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();
                    libraryManager.ReturnItem(title, author);
                    Console.ReadLine(); // Pause to see result
                }
                else if (input == "4") // NEW ADMIN SECTION
                {
                    Console.Write("Enter Admin Password: ");
                    string pass = Console.ReadLine();

                    if (pass == "admin123")
                    {
                        // --- START OF ADMIN MENU ---
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("--- ADMIN MENU ---");
                            Console.WriteLine("1. Add a new book");
                            Console.WriteLine("2. Delete a book (Coming Soon)");
                            Console.WriteLine("3. Add Book Stock");
                            Console.WriteLine("4. Back to Main Menu");
                            Console.Write("Select option: ");
                            string adminChoice = Console.ReadLine();

                            if (adminChoice == "1")
                            {
                                // This is your OLD logic for adding a book
                                Console.Write("Enter book title: ");
                                string title = Console.ReadLine();
                                Console.Write("Enter author name: ");
                                string author = Console.ReadLine();
                                Console.Write("Enter stock quantity: ");
                                int stock = int.Parse(Console.ReadLine());
                                Console.Write("Is this a reference book? (yes/no): ");
                                bool isReference = Console.ReadLine().ToLower() == "yes";

                                libraryManager.AddItem(title, author, stock, isReference);
                                Console.WriteLine("Book added successfully! Press Enter.");
                                Console.ReadLine();
                            }
                            else if (adminChoice == "2")
                            {
                                Console.Write("Enter the title of the book to DELETE: ");
                                string titleToDelete = Console.ReadLine();

                                // Call your new function!
                                libraryManager.RemoveBook(titleToDelete);

                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                            }
                            else if (adminChoice == "3")
                            {
                                Console.Write("Enter the title of the book to restock: ");
                                string titleToRestock = Console.ReadLine();
                                Console.Write("Enter the amount to add: ");
                                int amountToAdd = int.Parse(Console.ReadLine());
                                // Call your new function!
                                libraryManager.RestockBook(titleToRestock, amountToAdd);
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                            }
                            else if (adminChoice == "4")
                            {
                                break; // Breaks the Admin loop, goes back to Main loop
                            }
                        }
                        // --- END OF ADMIN MENU ---
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password! Access Denied.");
                        Console.ReadLine();
                    }
                }
                else if (input == "5")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
    }  
}

