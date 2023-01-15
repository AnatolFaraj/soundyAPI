using Core.Models;
using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class SoundyContext : DbContext
    {
        public SoundyContext(DbContextOptions<SoundyContext> options) : base(options)
        {

        }

        public DbSet<AlbumModel> Albums { get; set; }
        public DbSet<ArtistModel> Artists { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CredentialsModel> Credentials { get; set; }
        public DbSet<PlaylistModel> Playlists { get; set; }
        public DbSet<TrackDetailModel> TrackDetails { get; set; }
        public DbSet<TrackModel> Tracks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserAlbumModel> UserAlbums { get; set; }
        public DbSet<UserArtistModel> UserArtists { get; set; }
        public DbSet<PlaylistTrackModel> PlaylistTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TrackConfiguration());
            modelBuilder.ApplyConfiguration(new TrackDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistConfiguration());
            modelBuilder.ApplyConfiguration(new CredentialsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new UserAlbumConfiguration());
            modelBuilder.ApplyConfiguration(new UserArtistConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistTrackConfiguration());
        }

    }
}
