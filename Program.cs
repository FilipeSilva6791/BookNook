using BookNook.Views;
using BookNooK.Services;

namespace BookNook.Models
{
    public class Program
    {
        private static BookService bookService;
        private static UserService userService;

        public static void Main(string[] args)
        {
            bookService = new BookService();
            userService = new UserService();

            var login = new LoginView(userService);
            login.Show();

            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu ===\n");
                Console.WriteLine("What do you wanna see?\n");
                Console.WriteLine("1) SearchView");
                Console.WriteLine("2) ShelfView");
                Console.WriteLine("3) ProfileView");
                Console.WriteLine("4) Exit");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        var search = new SearchView(userService, bookService);
                        search.Show();
                        break;

                    case 2:
                        var shelf = new ShelfView(userService);
                        shelf.Show();
                        break;

                    case 3:
                        var profile = new ProfileView(userService);
                        profile.Show();
                        break;
                }

            } while (option != 4);
        }
    }
}