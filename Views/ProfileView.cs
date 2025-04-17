using BookNooK.Services;

namespace BookNook.Views
{
    public static class ProfileView
    {
        public static void Show(UserService userService)
        {
            int option;

            do
            {
                var user = userService.GetUser();

                Console.Clear();
                Console.WriteLine("=== Profile View ===\n");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Bio: {user.Bio}");
                Console.WriteLine("\nWhat do you wanna do?\n");
                Console.WriteLine("1) Edit name");
                Console.WriteLine("2) Edit Email");
                Console.WriteLine("3) Edit Bio");
                Console.WriteLine("4) Exit");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Console.Write("New name: ");
                        var name = Console.ReadLine();
                        userService.UpdateUserName(name);
                        break;
                    case 2:
                        Console.Write("New email: ");
                        var email = Console.ReadLine();
                        userService.UpdateUserEmail(email);
                        break;

                    case 3:
                        Console.Write("New bio: ");
                        var bio = Console.ReadLine();
                        userService.UpdateUserBio(bio);
                        break;
                }

            } while (option != 4);
        }
    }
}
