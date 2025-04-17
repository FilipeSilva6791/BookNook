namespace BookNook.Models
{
    public class User
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public List<Book>? Shelf { get; set; } = new List<Book>();
    }
}
