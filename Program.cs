using BookNook.Views;
using BookNooK.Services;

var bookService = new BookService();
var userService = new UserService();

LoginView.Show(userService);

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
            SearchView.Show(bookService, userService);
            break;
        
        case 2:
            ShelfView.Show(userService);
            break;

        case 3:
            ProfileView.Show(userService);
            break;
    }

} while (option != 4);