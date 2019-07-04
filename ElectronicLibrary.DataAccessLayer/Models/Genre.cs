﻿using System.Collections.Generic;

namespace ElectronicLibrary.DataAccessLayer.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<BookGenre> BookGenres { get; set; }
        public Genre()
        {
            BookGenres = new List<BookGenre>();
        }
    }
}