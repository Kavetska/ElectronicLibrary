using ElectronicLibrary.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DataAccessLayer.ModelConfiguration
{
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(model => EF.Property<bool>(model, "IsDeleted") == false);

            builder.HasKey(t => new { t.BookId, t.GenreId });

            builder.HasOne(bg => bg.Book)
                .WithMany(book => book.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            builder.HasOne(bg => bg.Genre)
                .WithMany(genre => genre.BookGenres)
                .HasForeignKey(bg => bg.GenreId);
        }
    }
}
