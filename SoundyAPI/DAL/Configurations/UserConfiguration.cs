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
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(x => x.Credential)
                .WithOne(x => x.User);

            builder.HasMany(x => x.Playlists)
                .WithOne(x => x.User);

            builder.HasMany(x => x.UserArtists)
                .WithOne(x => x.User);

            builder.HasMany(x => x.UserAlbums)
                .WithOne(x => x.User);

        }
    }
}
