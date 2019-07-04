namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }


        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
