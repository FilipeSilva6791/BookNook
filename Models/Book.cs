namespace BookNook.Models
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public ReadingStatus Status { get; set; }
        public string? ImagePath { get; set; }
    }
}
