using BookNook.Models;
using System.Text.Json;

namespace BookNooK.Services
{
    public class UserService
    {
        private const string UserFilePath = "Data/user.json";
        private User _user;

        public UserService()
        {
            LoadUser();
        }

        private void LoadUser()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dataPath = Path.Combine(basePath, "..\\..\\..\\", UserFilePath);

            if (!File.Exists(dataPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                File.WriteAllText(dataPath, "{}");
            }

            string json = File.ReadAllText(dataPath);
            _user = JsonSerializer.Deserialize<User>(json) ?? new User();
        }

        public User GetUser()
        {
            return _user;
        }

        public void UpdateUserName(string name)
        {
            _user.Name = name;
            SaveUser();
        }

        public void UpdateUserEmail(string email)
        {
            _user.Email = email;
            SaveUser();
        }

        public void UpdateUserBio(string bio)
        {
            _user.Bio = bio;
            SaveUser();
        }

        public List<Book> GetShelf()
        {
            return _user.Shelf;
        }

        public void AddBookToShelf(Book book)
        {
            if (!_user.Shelf.Any(b => b.Title == book.Title && b.Author == book.Author))
            {
                _user.Shelf.Add(book);
                SaveUser();
            }
        }

        public void RemoveBookToShelf(Book book)
        {
            if (_user.Shelf.Any(b => b.Title == book.Title && b.Author == book.Author))
            {
                _user.Shelf.Remove(book);
                SaveUser();
            }
        }

        public void UpdateBookStatus(Book book, ReadingStatus newStatus)
        {
            var existingBook = _user.Shelf.FirstOrDefault(b => b.Title == book.Title && b.Author == book.Author);
            if (existingBook != null)
            {
                existingBook.Status = newStatus;
                SaveUser();
            }
        }

        private void SaveUser()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dataPath = Path.Combine(basePath, "..\\..\\..\\", UserFilePath);

            string json = JsonSerializer.Serialize(_user, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataPath, json);
        }
    }
}
