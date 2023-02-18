using Core.DTOs.Artists;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepo;

        public ArtistsController(IArtistRepository artistRepository)
        {
            _artistRepo = artistRepository;
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<GetArtistByIdDTO>> GetArtistById(long Id)
        {
            var artistDTO = await _artistRepo.GetArtistById(Id);


            return Ok(artistDTO);
        }

        [HttpGet("")]
        public async Task<ActionResult<GetAllArtistsDTO>> GetAllArtists()
        {
            var artistDTOs = await _artistRepo.GetAllArtistsDTO();

            return Ok(artistDTOs);
        }

        [HttpPost("")]
        public async Task<ActionResult<GetArtistByIdDTO>> CreateArtist(CreateArtistDTO createArtistDTO)
        {
            var artistDTO = await _artistRepo.CreateArtist(createArtistDTO);

            return Created(HttpContext.Request.PathBase, artistDTO);

        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GetArtistByIdDTO>> EditArtist(long Id, CreateArtistDTO createArtistDTO)
        {
            var artistDTO = await _artistRepo.EditArtist(Id, createArtistDTO);

            return Ok(artistDTO);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteArtist(long Id)
        {
            await _artistRepo.DeleteArtist(Id);

            return Ok();
        }
    }
}
