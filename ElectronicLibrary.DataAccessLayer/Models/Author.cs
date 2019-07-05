using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }//HasComputedColumnSql
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Book> Books { get; set; }

    }
}
