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
    public class TrackConfiguration : IEntityTypeConfiguration<TrackModel>
    {
        public void Configure(EntityTypeBuilder<TrackModel> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.TrackDetail)
                .WithOne(x => x.Track);

            builder.HasOne(x => x.Artist)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.ArtistId);

            builder.HasOne(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.PlaylistTracks)
                .WithOne(x => x.Track);
                


                
        }
     }
}
