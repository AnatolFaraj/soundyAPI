using Core.DTOs.Albums;
using Core.DTOs.Tracks;
using Core.Exceptions;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Albums
{
    public class AlbumsManager : IAlbumRepository
    {
        private readonly SoundyContext _dbContext;

        public AlbumsManager(SoundyContext context)
        {
            _dbContext = context;
        }

        public async Task<ArtistAlbumDTO> CreateAlbum(long artistID, CreateAlbumDTO createAlbumDTO)
        {
            var artistModel = await _dbContext.Artists
                .Where(x => x.Id == artistID)
                .FirstOrDefaultAsync();

            if(artistModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Artist with id {artistID} doesn't exist."
                };
            }

            var categoryModel = await _dbContext.Categories
                .Where(x => x.Id == createAlbumDTO.CategoryId)
                .FirstOrDefaultAsync();

            if(categoryModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Category with id {createAlbumDTO.CategoryId} doesn't exist."
                };
            }

            var albumModel = new AlbumModel()
            {
                ArtistId = artistID,
                CategoryId = createAlbumDTO.CategoryId,
                Name = createAlbumDTO.Name,
                Picture = createAlbumDTO.Picture,
                ReleaseDate = createAlbumDTO.ReleaseDate,
                Category = categoryModel,
                Artist = artistModel
            };

            _dbContext.Add(albumModel);
            await _dbContext.SaveChangesAsync();

            return albumModel.ToDTO();

        }

        public async Task DeleteAlbum(long artistId, long albumId)
        {
           var albumModel = await _dbContext.Albums
                .Where(x => x.ArtistId == artistId && x.Id == albumId)
                .Include(x => x.Tracks)
                .FirstOrDefaultAsync();

            if(albumModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Artist with id {artistId} doesn't have an album with id {albumId}"
                };
            }

            _dbContext.Remove(albumModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ArtistAlbumDTO> EditAlbum(long artistId, long albumId, CreateAlbumDTO createAlbumDTO)
        {
            var albumModel = await _dbContext.Albums
                .Where(x => x.ArtistId == artistId && x.Id == albumId)
                .Include(x => x.Tracks)
                .ThenInclude(x => x.TrackDetail)
                .FirstOrDefaultAsync();

            if(albumModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Artist with id {artistId} doesn't have an album with id {albumId}."
                };
            }

            var categoryModel = await _dbContext.Categories
                .Where(x => x.Id == createAlbumDTO.CategoryId)
                .FirstOrDefaultAsync();

            if (categoryModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Category with id {createAlbumDTO.CategoryId} doesn't exist."
                };
            }

            albumModel.FromDTO(createAlbumDTO, categoryModel);
            await _dbContext.SaveChangesAsync();

            return albumModel.ToDTO();



        }

        public async Task<GetAlbumByIdDTO> GetAlbumById(long artistId, long albumId)
        {

            var albumDTO = await _dbContext.Albums
                .Where(x => x.ArtistId == artistId)
                .Where(x => x.Id == albumId)
                .Select(x => new GetAlbumByIdDTO()
                {
                    Name = x.Name,
                    ArtistName = x.Artist.Name,
                    CategoryName = x.Category.Name,
                    ReleaseDate = x.ReleaseDate,
                    Picture = x.Picture,
                    TotalListenings = x.Listenings,
                    Tracks = x.Tracks.OrderBy(t => t.Id).Select(t => new AlbumTrackDTO()
                    {
                        Title = t.Title,
                        TrackFile = t.TrackFile

                    }).ToList()

                }).FirstOrDefaultAsync();

            if(albumDTO is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    ErrorDescription = $"Artist with id {artistId} doesn't have an album with id {albumId}."
                };
            }


            return albumDTO;
        }

        public async Task<List<ArtistAlbumDTO>> GetAllArtistsAlbums(long artistId)
        {
            var albumDTOList = await _dbContext.Albums
                .Where(x => x.ArtistId == artistId)
                .OrderBy(x => x.ReleaseDate)
                .Select(x => new ArtistAlbumDTO()
                { 
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    ReleaseDate = x.ReleaseDate,
                    Picture = x.Picture,
                    TotalListenings = x.Listenings
                
                }).ToListAsync();

            if(!albumDTOList.Any())
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    ErrorDescription = $"Artist with Id {artistId} doesn't exist or has no albums."
                };
            }

            return albumDTOList;
        }
    }
}
