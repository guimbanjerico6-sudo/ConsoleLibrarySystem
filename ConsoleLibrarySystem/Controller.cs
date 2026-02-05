using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrarySystem
{
    internal class Controller
    {
        public class LibraryManager
        {
            private List<LibraryItem> items = new List<LibraryItem>();

            public void AddItem(string title, string author, int stock, bool isReference)
            {
                // Check if an item with the same title already exists
                if (items.Any(item => item.BookTitle == title))
                {
                    // Optionally handle duplicate (e.g., throw exception or return)
                    return;
                }

                if (isReference)
                {
                    items.Add(new ReferenceBook(title, author, stock));
                }
                else
                {
                    items.Add(new Novel(title, author, stock));
                }
                Console.WriteLine("Success! Book added to the shelf.");
            }

            public void ShowAllItems()
            {
                Console.WriteLine("Books on the shelf:");
                foreach (var item in items)
                {
                    Console.WriteLine($"Title: {item.BookTitle}, Author: {item.Author}, Stock: {item.Stock}");
                }
            }

            public void BorrowItem(string title, string author)
            {
                // 1. Single Scan: Try to find the book
                var item = items.FirstOrDefault(b => b.BookTitle == title && b.Author == author);

                // 2. Check: Did we catch anything?
                if (item != null)
                {
                    // Yes, we have the book object!
                    item.Borrow();
                }
                else
                {
                    // No, item is null (empty)
                    Console.WriteLine($"Sorry, '{title}' by {author} is not available in the library.");
                }
            }

            public void ReturnItem(string title, string author)
            {
                // 1. Single Scan
                var item = items.FirstOrDefault(b => b.BookTitle == title && b.Author == author);

                // 2. Check
                if (item != null)
                {
                    item.Return();
                }
                else
                {
                    Console.WriteLine($"Sorry, '{title}' by {author} is not recognized in the library.");
                }
            }
        }
    }
}
