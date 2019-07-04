using ElectronicLibrary.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DataAccessLayer.ModelConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(model => EF.Property<bool>(model, "IsDeleted") == false);
            builder.HasKey(obj => obj.Id);
        }
    }
}
