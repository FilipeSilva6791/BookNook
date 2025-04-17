using BookNook.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookNooK.Services
{
    public class BookService
    {
        private const string BooksFilePath = "Data/books.json";
        private List<Book> _books = [];

        public BookService()
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dataPath = Path.Combine(basePath, "..\\..\\..\\", BooksFilePath);

            if (File.Exists(dataPath))
            {
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter(null) }
                };

                string json = File.ReadAllText(dataPath);
                _books = JsonSerializer.Deserialize<List<Book>>(json, options) ?? [];
            }
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return _books
                .Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
