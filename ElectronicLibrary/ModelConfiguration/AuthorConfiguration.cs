namespace DAL.ModelConfiguration
{
    using Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(author => author.Name)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

        }


    }
}
