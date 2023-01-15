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
    public class UserAlbumConfiguration : IEntityTypeConfiguration<UserAlbumModel>
    {
        public void Configure(EntityTypeBuilder<UserAlbumModel> builder)
        {
            builder.HasKey(k => new { k.UserId, k.AlbumId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserAlbums)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Album)
                .WithMany(x => x.UserAlbums)
                .HasForeignKey(x => x.AlbumId);
                
               
                
        }
    }
}
