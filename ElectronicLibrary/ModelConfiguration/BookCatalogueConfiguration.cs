using ElectronicLibrary.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DataAccessLayer.ModelConfiguration
{
    public class BookCatalogueConfiguration : IEntityTypeConfiguration<BookCatalogue>
    {
        public void Configure(EntityTypeBuilder<BookCatalogue> builder)
        {
            builder.HasOne(catalogue => catalogue.User)
                .WithMany(user => user.BookCatalogues)
                .HasForeignKey(catalogue => catalogue.UserId);

        }
    }
}
