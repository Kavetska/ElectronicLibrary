namespace DAL.Model
{
    using System.Collections.Generic;
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishYear { get; set; }
        public double Price { get; set; }
        public string ReadingStatus { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<BookGenre> BookGenres { get; set; }
        public Book()
        {
            BookGenres = new List<BookGenre>();
        }
        public List<Comment> Comments { get; set; }
        public List<Vote> Votes { get; set; }

    }
}
