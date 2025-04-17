using BookNooK.Services;

namespace BookNook.Views
{
    public static class LoginView
    {
        public static void Show(UserService userService)
        {
            Console.WriteLine("=== Login View ===\n");
            Console.WriteLine("Welcome to BookNook APP!\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            userService.UpdateUserName(name);
            userService.UpdateUserEmail(email);
            userService.UpdateUserBio(bio);
        }

    }
}
