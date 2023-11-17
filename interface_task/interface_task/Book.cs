namespace interface_task
{
    public class Book : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; }
        public string AuthorName { get; }
        public int PageCount { get; }
        public bool IsDeleted { get; private set; }

        public Book(int id, string name, string authorName, int pageCount)
        {
            Id = id;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            IsDeleted = false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Book Id: {Id}, Name: {Name}, Author: {AuthorName}, Page Count: {PageCount}, IsDeleted: {IsDeleted}");
        }

        public static bool operator >(Book book1, Book book2)
        {
            return book1.PageCount > book2.PageCount;
        }

        public static bool operator <(Book book1, Book book2)
        {
            return book1.PageCount < book2.PageCount;
        }
    }

}
