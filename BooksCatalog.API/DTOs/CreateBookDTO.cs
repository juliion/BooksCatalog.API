namespace BooksCatalog.API.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }
    }
}
