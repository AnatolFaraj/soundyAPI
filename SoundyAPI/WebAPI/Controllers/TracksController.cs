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

        [HttpPost("")]
        public async Task<ActionResult<GetTrackByIdDTO>> CreateTrack(CreateTrackDTO createTrackDTO)
        {
            var newTrackDTO = await _trackRepo.CreateTrack(createTrackDTO);

            return Created(HttpContext.Request.PathBase, newTrackDTO);
        }

    }
}
