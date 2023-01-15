﻿using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<GetUserDTO> GetUserByIdAsync(long userId);

        public Task<GetAllUsersDTO> GetAllUsersAsync();
    }
}
