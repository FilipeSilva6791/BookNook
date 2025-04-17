using BookNook.Models;
using BookNooK.Services;

namespace BookNook.Views
{
    public static class ShelfView
    {
        public static void Show(UserService userService)
        {
            int option;

            do
            {
                var shelf = userService.GetShelf();

                Console.Clear();
                Console.WriteLine("=== Your Shelf ===\n");

                if (shelf.Any())
                {
                    for (int i = 0; i < shelf.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {shelf[i].Title} by {shelf[i].Author} - Status: {shelf[i].Status}");
                    }
                }
                else
                {
                    Console.WriteLine("Your shelf is empty.\n");
                }

                Console.WriteLine("\nWhat do you want to do?\n");
                Console.WriteLine("1) Update reading status");
                Console.WriteLine("2) Remove a book from shelf");
                Console.WriteLine("3) Exit");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        if (shelf.Any())
                        {
                            Console.Write("\nEnter the number of the book to update: ");
                            int.TryParse(Console.ReadLine(), out int bookIndex);

                            if (bookIndex > 0 && bookIndex <= shelf.Count)
                            {
                                Console.WriteLine("\nSelect new status:");
                                Console.WriteLine("1) NotStarted");
                                Console.WriteLine("2) InProgress");
                                Console.WriteLine("3) Completed");

                                int.TryParse(Console.ReadLine(), out int statusOption);

                                ReadingStatus newStatus = statusOption switch
                                {
                                    1 => ReadingStatus.NotStarted,
                                    2 => ReadingStatus.InProgress,
                                    3 => ReadingStatus.Completed,
                                    _ => shelf[bookIndex - 1].Status
                                };

                                userService.UpdateBookStatus(shelf[bookIndex - 1], newStatus);
                                Console.WriteLine("\nStatus updated! Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case 2:
                        if (shelf.Any())
                        {
                            Console.Write("\nEnter the number of the book to remove: ");
                            int.TryParse(Console.ReadLine(), out int removeIndex);

                            if (removeIndex > 0 && removeIndex <= shelf.Count)
                            {
                                var bookToRemove = shelf[removeIndex - 1];
                                userService.RemoveBookToShelf(bookToRemove);
                                Console.WriteLine($"\n'{bookToRemove.Title}' was removed from your shelf!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        break;
                }

            } while (option != 3);
        }
    }

}
