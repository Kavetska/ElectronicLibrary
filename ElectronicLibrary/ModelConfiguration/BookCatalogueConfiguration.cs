namespace DAL.ModelConfiguration
{
    using Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
