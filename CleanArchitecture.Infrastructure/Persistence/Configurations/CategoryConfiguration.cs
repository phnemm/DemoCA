using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.OwnsMany(x => x.Products, ConfigureProduct);
        }

        public void ConfigureProduct(OwnedNavigationBuilder<Category, Product> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.CategoryId);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
