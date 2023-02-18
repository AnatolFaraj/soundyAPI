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

namespace BLL.Tracks
{
    public class TracksManager : ITrackRepository
    {
        private readonly SoundyContext _dbContext;

        public TracksManager(SoundyContext soundyContext)
        {
            _dbContext = soundyContext;
        }
        public async Task<GetTrackByIdDTO> CreateTrack(CreateTrackDTO createTrackDTO)
        {

            var trackDetailAlbumArtistCategory = await _dbContext.Albums
                .Where(x => x.Id == createTrackDTO.AlbumId)
                .Include(x => x.Artist)
                .Include(x => x.Category)
                .FirstOrDefaultAsync();

            if(trackDetailAlbumArtistCategory is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Album with id {createTrackDTO.AlbumId} doesn't exist"
                };
            }

            var newTrackDetailModel = new TrackDetailModel()
            {
                ReleaseDate = trackDetailAlbumArtistCategory.ReleaseDate,
                Picture = trackDetailAlbumArtistCategory.Picture
            };

            var newTrackModel = new TrackModel()
            {
                Title = createTrackDTO.Title,
                ArtistId = trackDetailAlbumArtistCategory.ArtistId,
                AlbumId = createTrackDTO.AlbumId,
                CategoryId = trackDetailAlbumArtistCategory.CategoryId,
                TrackFile = createTrackDTO.TrackFile,
                TrackDetail = newTrackDetailModel,
                Album = trackDetailAlbumArtistCategory,
                Artist = trackDetailAlbumArtistCategory.Artist,
                Category = trackDetailAlbumArtistCategory.Category

            };

            _dbContext.Add(newTrackDetailModel);
            _dbContext.Add(newTrackModel);
            await _dbContext.SaveChangesAsync();

            

            return newTrackModel.ToDTO();

            
        }

        public async Task DeleteTrack(long trackId)
        {
            var trackModel = await _dbContext.Tracks
                .Where(x => x.Id == trackId)
                .FirstOrDefaultAsync();

            if(trackModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Track with id {trackId} doesn't exist"
                };
            }

             _dbContext.Remove(trackModel);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<GetTrackByIdDTO> EditTrack(long trackId, CreateTrackDTO createTrackDTO)
        {
            var trackModel = await _dbContext.Tracks
                .Where(x => x.Id == trackId)
                .Include(x => x.TrackDetail)
                .FirstOrDefaultAsync();
            
            if(trackModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Track with id {trackId} doesn't exist"
                };
            }

            var trackContents = await _dbContext.Albums
                .Where(x => x.Id == createTrackDTO.AlbumId)
                .Include(x => x.Artist)
                .Include(x => x.Category)
                .FirstOrDefaultAsync();

            if(trackContents is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Album with id {createTrackDTO.AlbumId} doesn't exist"
                };
            }


            
             trackModel.FromDTO(createTrackDTO, trackContents);

             await _dbContext.SaveChangesAsync();
            

            return trackModel.ToDTO();

        }

        public async Task<GetAllTracksDTO> GetAllTracksDTO()
        {
            var trackDTO = await _dbContext.Tracks
                .Select(t => new GetTrackByIdDTO() 
                { 
                    Title = t.Title,
                    AlbumName = t.Album.Name,
                    ArtistName = t.Artist.Name,
                    CategoryName = t.Category.Name,
                    ReleaseDate = t.TrackDetail.ReleaseDate,
                    Picture = t.TrackDetail.Picture,
                    TrackFile = t.TrackFile
                
                }).ToListAsync();

            return new GetAllTracksDTO()
            { 
                AllTracks = trackDTO 
            };
        }

        public async Task<GetTrackByIdDTO> GetTrackById(long id)
        {
            var trackDTO = await _dbContext.Tracks
                .Where(x => x.Id == id)
                .Select(t => new GetTrackByIdDTO() 
                {
                    Title = t.Title,
                    AlbumName = t.Album.Name,
                    ArtistName = t.Artist.Name,
                    CategoryName = t.Category.Name,
                    ReleaseDate = t.TrackDetail.ReleaseDate,
                    Picture = t.TrackDetail.Picture,
                    TrackFile = t.TrackFile

                }).FirstOrDefaultAsync();

            if(trackDTO is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    ErrorDescription = $"Track with id {id} not found"
                };
            }

            return trackDTO;
        }
    }
}
