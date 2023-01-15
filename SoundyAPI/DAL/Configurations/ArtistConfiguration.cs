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
    public class ArtistConfiguration : IEntityTypeConfiguration<ArtistModel>
    {
        public void Configure(EntityTypeBuilder<ArtistModel> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Artists)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Albums)
                .WithOne(x => x.Artist);

            builder.HasMany(x => x.Tracks)
                .WithOne(x => x.Artist);

            builder.HasMany(x => x.UserArtists)
                .WithOne(x => x.Artist);
                
        }
    }
}
