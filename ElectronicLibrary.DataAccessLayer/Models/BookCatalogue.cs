﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class BookCatalogue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Book> Books { get; set; }
    }
}
