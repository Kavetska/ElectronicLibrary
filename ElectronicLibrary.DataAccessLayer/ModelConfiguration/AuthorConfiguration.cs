﻿using ElectronicLibrary.DataAccessLayer.Models;

namespace DAL.ModelConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(model => EF.Property<bool>(model, "IsDeleted") == false);
            builder.HasKey(obj => obj.Id);

            builder.Property(author => author.Name)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

        }


    }
}
