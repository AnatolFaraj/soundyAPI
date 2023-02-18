using Core.DTOs.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAlbumRepository
    {
        public Task<GetAlbumByIdDTO> GetAlbumById(long artistId, long albumId);

        public Task<List<ArtistAlbumDTO>> GetAllArtistsAlbums(long artistId);

        public Task<ArtistAlbumDTO> CreateAlbum(long artistID, CreateAlbumDTO createAlbumDTO);

        public Task<ArtistAlbumDTO> EditAlbum(long artistId, long albumId, CreateAlbumDTO createAlbumDTO);

        public Task DeleteAlbum(long artistId, long albumId);
    }
}
