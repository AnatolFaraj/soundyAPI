using Core.DTOs.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITrackRepository
    {
        public Task<GetTrackByIdDTO> GetTrackById(long id);

        public Task<GetAllTracksDTO> GetAllTracksDTO();

        public Task<GetTrackByIdDTO> CreateTrack(CreateTrackDTO createTrackDTO);

        public Task<CreateTrackDTO> EditTrack(long trackId, CreateTrackDTO createTrackDTO);

        public Task DeleteTrack(long trackId);
    }
}
