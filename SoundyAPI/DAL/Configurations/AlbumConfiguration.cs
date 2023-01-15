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
    public class AlbumConfiguration : IEntityTypeConfiguration<AlbumModel>
    {
        public void Configure(EntityTypeBuilder<AlbumModel> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.Artist)
                .WithMany(x => x.Albums);
                

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Albums);
                

            builder.HasMany(x => x.UserAlbums)
                .WithOne(x => x.Album);

            builder.HasMany(x => x.Tracks)
                .WithOne(x => x.Album);

            
        }
    }
}
