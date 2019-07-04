using System.Collections.Generic;

namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string email { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public List<Vote> Votes { get; set; }
        public List<BookCatalogue> BookCatalogues { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
