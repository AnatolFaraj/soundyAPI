using Core.DTOs.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IArtistRepository
    {
        public Task<GetArtistByIdDTO> GetArtistById(long id);

        public Task<GetAllArtistsDTO> GetAllArtistsDTO();

        public Task<GetArtistByIdDTO> CreateArtist(CreateArtistDTO createArtistDTO);

        public Task<GetArtistByIdDTO> EditArtist(long artistId, CreateArtistDTO createArtistDTO);

        public Task DeleteArtist(long ArtistId);
    }
}
