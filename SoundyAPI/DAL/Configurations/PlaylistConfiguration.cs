﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Configurations
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<PlaylistModel>
    {
        public void Configure(EntityTypeBuilder<PlaylistModel> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Playlists)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.PlaylistTracks)
                .WithOne(x => x.Playlist);
        }
     }
}
