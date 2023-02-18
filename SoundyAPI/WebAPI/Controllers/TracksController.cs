using Core.DTOs.Tracks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/tracks")]
    public class TracksController : ControllerBase
    {
        private readonly ITrackRepository _trackRepo;
        public TracksController(ITrackRepository trackRepository)
        {
            _trackRepo = trackRepository;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetTrackByIdDTO>> GetTrackById(long Id)
        {
            var trackDTO = await _trackRepo.GetTrackById(Id);

            return Ok(trackDTO);
        }

        [HttpGet("")]
        public async Task<ActionResult<GetAllTracksDTO>> GetAllTracks()
        {
            var trackDTOList = await _trackRepo.GetAllTracksDTO();

            return Ok(trackDTOList);
        }
        
        [HttpPost("")]
        public async Task<ActionResult<GetTrackByIdDTO>> CreateTrack(CreateTrackDTO createTrackDTO)
        {
            var newTrackDTO = await _trackRepo.CreateTrack(createTrackDTO);

            return Created(HttpContext.Request.PathBase, newTrackDTO);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<GetTrackByIdDTO>> EditTrack(long Id, CreateTrackDTO createTrackDTO)
        {
            var trackDTO = await _trackRepo.EditTrack(Id, createTrackDTO);

            return Ok(trackDTO);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteTrack(long Id)
        {
            await _trackRepo.DeleteTrack(Id);

            return NoContent();
        }
    }
}
