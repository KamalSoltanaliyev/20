using System;

namespace interface_task
{
    internal class Library : IEntity
    {
        public int Id { get; private set; }
        public int BookLimit { get; private set; }
        public Book[] Books { get; private set; }

        public Library(int id, int bookLimit)
        {
            Id = id;
            BookLimit = bookLimit;
            Books = new Book[0];
        }

        public Book[] GetBooks()
        {
            return Books;
        }

        public void AddBook(Book newBook, Book[] books)
        {
            if (newBook == null || string.IsNullOrWhiteSpace(newBook.Name) || string.IsNullOrWhiteSpace(newBook.AuthorName) || newBook.PageCount <= 0)
            {
                throw new ArgumentException("Name, AuthorName, and PageCount are required for creating a book.");
            }

            if (Array.Exists(Books, book => book != null && book.Name.Equals(newBook.Name, StringComparison.OrdinalIgnoreCase) && !book.IsDeleted))
            {
                throw new AlreadyExistsException();
            }

            if (Books.Length >= BookLimit)
            {
                throw new CapacityLimitException();
            }

            Array.Resize(array: ref books, Books.Length + 1);
            Books[Books.Length - 1] = newBook;
        }

        public Book GetBookById(int id)
        {
            Book book = Array.Find(Books, b => b != null && b.Id == id && !b.IsDeleted);

            if (book == null)
            {
                throw new NotFoundException();
            }

            return book;
        }
    }
}


