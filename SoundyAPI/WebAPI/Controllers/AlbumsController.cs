using Core.DTOs.Albums;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/artists/{artistId}/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepo;
        public AlbumsController(IAlbumRepository albumRepository)
        {
            _albumRepo = albumRepository;
        }

        [HttpGet("{albumId}")]
        public async Task<ActionResult<GetAlbumByIdDTO>> GetAlbumById(long artistId, long albumId)
        {
            var albumDTO = await _albumRepo.GetAlbumById(artistId, albumId);

            return Ok(albumDTO);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<ArtistAlbumDTO>>> GetAllArtistAlbums(long artistId)
        {
            var albumDTOList = await _albumRepo.GetAllArtistsAlbums(artistId);

            return Ok(albumDTOList);
        }

        [HttpPost("")]
        public async Task<ActionResult<ArtistAlbumDTO>> CreateAlbum(long artistId, CreateAlbumDTO createAlbumDTO)
        {
            var albumDTO = await _albumRepo.CreateAlbum(artistId, createAlbumDTO);

            return Created(HttpContext.Request.PathBase, albumDTO);
        }

        [HttpPut("{albumId}")]
        public async Task<ActionResult<ArtistAlbumDTO>> EditAlbum(long artistId, long albumId, CreateAlbumDTO createAlbumDTO)
        {
            var albumDTO = await _albumRepo.EditAlbum(artistId, albumId, createAlbumDTO);

            return Ok(albumDTO);
        }

        [HttpDelete("{albumId}")]
        public async Task<ActionResult> DeleteAlbum(long artistId, long albumId)
        {
            await _albumRepo.DeleteAlbum(artistId, albumId);

            return NoContent();
        }
    }
}
