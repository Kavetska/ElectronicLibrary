using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
