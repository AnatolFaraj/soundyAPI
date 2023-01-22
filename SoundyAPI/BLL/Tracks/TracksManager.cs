using Core.DTOs.Tracks;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var newTrackDetailModel = new TrackDetailModel()
            {
                ReleaseDate = _dbContext.Albums
                .Where(x => x.Id == createTrackDTO.AlbumId)
                .Select(x => x.ReleaseDate)
                .FirstOrDefault(),

                Picture = _dbContext.Albums
                .Where(x => x.Id == createTrackDTO.AlbumId)
                .Select(x => x.Picture)
                .FirstOrDefault()
            };

            var newTrackModel = new TrackModel()
            {
                Title = createTrackDTO.Title,
                ArtistId = createTrackDTO.ArtistId,
                AlbumId = createTrackDTO.AlbumId,
                CategoryId = createTrackDTO.CategoryId,
                TrackFile = createTrackDTO.TrackFile,
                TrackDetail = newTrackDetailModel,
                Album = _dbContext.Albums.Where(x => x.Id == createTrackDTO.AlbumId).FirstOrDefault(),
                Artist = _dbContext.Artists.Where(x => x.Id == createTrackDTO.ArtistId).FirstOrDefault(),
                Category = _dbContext.Categories.Where(x => x.Id == createTrackDTO.CategoryId).FirstOrDefault()

            };

            _dbContext.Add(newTrackDetailModel);
            _dbContext.Add(newTrackModel);
            await _dbContext.SaveChangesAsync();

            

            return newTrackModel.ToDTO();

            
        }

        public Task DeleteTrack(long trackId)
        {
            throw new NotImplementedException();
        }

        public Task<CreateTrackDTO> EditTrack(long trackId, CreateTrackDTO createTrackDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllTracksDTO> GetAllTracksDTO()
        {
            throw new NotImplementedException();
        }

        public Task<GetTrackByIdDTO> GetTrackById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
