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
    public class PlaylistTrackConfiguration : IEntityTypeConfiguration<PlaylistTrackModel>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrackModel> builder)
        {
            builder.HasKey(k => new { k.PlaylistId, k.TrackId});

            builder.HasOne(x => x.Playlist)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId);

            builder.HasOne(x => x.Track)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.TrackId);
        }
    }
}
