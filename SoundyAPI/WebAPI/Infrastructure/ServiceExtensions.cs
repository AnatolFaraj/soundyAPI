using BLL.Albums;
using BLL.Artists;
using BLL.Tracks;
using BLL.Users;
using Core.Interfaces;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DAL.Data.SoundyContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SoundyDB"));
            });
        }

        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UsersManager>();
            services.AddScoped<ITrackRepository, TracksManager>();
            services.AddScoped<IArtistRepository, ArtistsManager>();
            services.AddScoped<IAlbumRepository, AlbumsManager>();
        }

        public static void AddLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
