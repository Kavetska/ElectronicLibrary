namespace DAL.ModelConfiguration
{
    using Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(comment => comment.ParentComment)
                .WithMany()
                .HasForeignKey(comment => comment.ParentCommentId);

            builder.HasOne(comment => comment.Book)
                .WithMany(book => book.Comments)
                .HasForeignKey(comment => comment.BookId);

            builder.HasOne(comment => comment.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId);
        }
    }
}
