namespace DAL.Model
{
    public class Vote
    {
        public int Id { get; set; }
        public int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
