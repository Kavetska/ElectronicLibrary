namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class BookGenre
    {
        public bool IsDeleted { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
