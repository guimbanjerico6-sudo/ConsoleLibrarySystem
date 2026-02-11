namespace ConsoleLibrarySystem
{
    
    public class LibraryItem
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }

        public LibraryItem(string bookTitle, string author, int stock)
        {
            this.BookTitle = bookTitle;
            this.Author = author;
            this.Stock = stock; 
        }

        public virtual void Borrow()
        {
            if (this.Stock > 0)
            {
                this.Stock--; 
                Console.WriteLine($"Success! You borrowed: {this.BookTitle}");
                Console.WriteLine($"Remaining quantity: {this.Stock}");
            }
            else
            {
                Console.WriteLine($"Sorry, {this.BookTitle} is currently out of stock.");
            }
        }

        public void Return()
        {
            this.Stock++;
            Console.WriteLine($"You returned: {this.BookTitle}");
            Console.WriteLine($"Current quantity: {this.Stock}");
        }
    }
    public class Novel : LibraryItem
    {
        public Novel(string title, string author, int stock) : base(title, author, stock) { }
    }

    // 3. The Strict Child
    public class ReferenceBook : LibraryItem
    {
        public ReferenceBook(string title, string author, int stock) : base(title, author, stock) { }

        // OVERRIDE: Change the behavior!
        public override void Borrow()
        {
            Console.WriteLine($"Error: '{this.BookTitle}' is a Reference Book and cannot be borrowed.");
        }
    }
}