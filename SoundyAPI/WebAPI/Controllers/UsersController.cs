using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Users;
using Core.DTOs;
using Core.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usersManager;
        private readonly ILoggerManager _logger;

        public UsersController(IUserRepository usersManager, ILoggerManager loggerManager)
        {
            _usersManager = usersManager;
            _logger = loggerManager;
        }

        [HttpGet("")]
        public async Task<ActionResult<GetAllUsersDTO>> GetAllUsersAsync()
        {
            var allUsersDTO = await _usersManager.GetAllUsersAsync();

            if(allUsersDTO is null)
            {
                return NoContent();
            }

            return Ok(allUsersDTO);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetUserDTO>> GetUserByIdAsync(long Id)
        {
            var userDTO = await _usersManager.GetUserByIdAsync(Id);

            if(userDTO is null)
            {
                return NotFound();
            }

            return Ok(userDTO);
        }
    }
}
