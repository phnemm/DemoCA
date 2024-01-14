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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

<<<<<<< HEAD
<<<<<<< HEAD
            builder.Property(x => x.Color) .IsRequired();
            builder.Property(x => x.Size).IsRequired();

=======
=======
>>>>>>> 1e929ee44c729056d68aae1287a8f73f68e6debd
            builder.HasOne(x => x.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
<<<<<<< HEAD
>>>>>>> 1e929ee (fix Migration)
=======
>>>>>>> 1e929ee44c729056d68aae1287a8f73f68e6debd
        }
    }
}
