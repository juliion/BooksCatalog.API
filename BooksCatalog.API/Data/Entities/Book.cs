namespace BooksCatalog.API.Data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public int Pages { get; set; }
    }
}
