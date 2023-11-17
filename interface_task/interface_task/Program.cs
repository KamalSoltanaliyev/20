using interface_task;

class Program
{
    static void Main()
    {
        Book book = new Book(12, "Fight Club", "Palanik", 300);
        Console.WriteLine(book.Id);
        Console.WriteLine(book.Name);
        Console.WriteLine(book.AuthorName);
        Console.WriteLine(book.PageCount);
    }
}
