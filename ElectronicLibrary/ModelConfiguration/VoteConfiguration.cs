using ElectronicLibrary.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DataAccessLayer.ModelConfiguration
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasOne(vote => vote.User)
                .WithMany(user => user.Votes)
                .HasForeignKey(vote => vote.UserId);

            builder.HasOne(vote => vote.Book)
                .WithMany(book => book.Votes)
                .HasForeignKey(vote => vote.BookId);
        }


    }
}
