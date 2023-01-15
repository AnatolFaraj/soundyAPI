using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Albums)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Artists)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Tracks)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
                
        }
    }
}
