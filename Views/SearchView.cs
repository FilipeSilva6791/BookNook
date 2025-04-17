using BookNooK.Services;

namespace BookNook.Views
{
    public static class SearchView
    {
        public static void Show(BookService bookService, UserService userService)
        {
            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Search View ===\n");
                Console.WriteLine("1) Search a book");
                Console.WriteLine("2) Exit");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter a book title or author to search: ");
                        var query = Console.ReadLine();

                        var results = bookService.SearchBooks(query);

                        Console.Clear();
                        Console.WriteLine("=== Search Results ===\n");

                        if (results.Any())
                        {
                            for (int i = 0; i < results.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {results[i].Title} by {results[i].Author}");
                            }

                            Console.WriteLine("\nSelect a book to add to your shelf (or 0 to cancel):");
                            int.TryParse(Console.ReadLine(), out int selection);

                            if (selection > 0 && selection <= results.Count)
                            {
                                var selectedBook = results[selection - 1];
                                userService.AddBookToShelf(selectedBook);
                                Console.WriteLine($"\n'{selectedBook.Title}' was added to your shelf!");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found. Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                }

            } while (option != 2);
        }
    }
}
