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
    public class UserArtistConfiguration : IEntityTypeConfiguration<UserArtistModel>
    {
        public void Configure(EntityTypeBuilder<UserArtistModel> builder)
        {
            builder.HasKey(k => new { k.UserId, k.ArtistId});

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserArtists)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Artist)
                .WithMany(x => x.UserArtists)
                .HasForeignKey(x => x.ArtistId);
        }
    }
}
