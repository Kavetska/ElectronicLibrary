using System.Collections.Generic;

namespace ElectronicLibrary.DataAccessLayer.Model
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }//HasComputedColumnSql
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Book> Books { get; set; }

    }
}
