using Bookstore.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookstore.Services
{
    public class BookstoreService
    {
        static int nextAuthorId = 4;
        static List<Author> Authors { get; }

        static int nextBookId = 10;
        static List<Book> Books { get; }


        static BookstoreService()
        {
            Authors = new List<Author>
            {
                new Author{ Id = 1, FirstName = "Dan", LastName = "Brown" },
                new Author{ Id = 2, FirstName = "Stephenie", LastName = "Meyer" },
                new Author{ Id = 3, FirstName = "E. L.", LastName = "James" }
            };

            Books = new List<Book>
            {
                new Book{ Id = 1, Title = "The Da Vinci Code", Author = Authors.ElementAt(0) },
                new Book{ Id = 2, Title = "Angels and Demons", Author = Authors.ElementAt(0) },
                new Book{ Id = 3, Title = "Digital Fortress", Author = Authors.ElementAt(0) },
                new Book{ Id = 4, Title = "Twilight", Author = Authors.ElementAt(1) },
                new Book{ Id = 5, Title = "Midnight Sun", Author = Authors.ElementAt(1) },
                new Book{ Id = 6, Title = "Breaking Dawn", Author = Authors.ElementAt(1) },
                new Book{ Id = 7, Title = "Fifty Shades of Grey", Author = Authors.ElementAt(2) },
                new Book{ Id = 8, Title = "The Mister", Author = Authors.ElementAt(2) },
                new Book{ Id = 9, Title = "Master of the Universe", Author = Authors.ElementAt(2) }
            };
        }

        public static List<Book> GetAllBooks() => Books;

        public static Book? GetBook(int id) => Books.FirstOrDefault( book => book.Id == id);

        public static List<Author> GetAllAuthors() => Authors;

        public static Author? GetAuthor(int id) => Authors.FirstOrDefault(author => author.Id == id);

        public static void AddBook(Book book)
        {
            book.Id = nextBookId++;
            Books.Add(book);
        }

        public static void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book is null) return;

            Books.Remove(book);
        }

        public static void UpdateBook(Book book)
        {
            var index = Books.FindIndex(b => b.Id == book.Id);

            if (index < 0) return;

            Books[index] = book;
        }

        public static void AddAuthor(Author author)
        {
            author.Id = nextAuthorId++;
            Authors.Add(author);
        }

        public static void DeleteAuthor(int id)
        {
            var author = GetAuthor(id);
            if (author is null) return;

            Authors.Remove(author);
        }

        public static void UpdateAuthor(Author author)
        {
            var index = Authors.FindIndex(a => a.Id == author.Id);

            if (index < 0) return;

            Authors[index] = author;
        }
    }
}
