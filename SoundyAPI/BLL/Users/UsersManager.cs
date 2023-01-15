using Core.DTOs;
using Core.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Users
{
    public class UsersManager : IUserRepository
    {
        private readonly SoundyContext _dbContext;
        public UsersManager(SoundyContext context)
        {
            _dbContext = context;
        }

        public async Task<GetAllUsersDTO> GetAllUsersAsync()
        {
            var allUserDTOs = await _dbContext.Users
                .Include(x => x.Credential)
                .Select(u => new GetUserDTO
                {
                    UserId = u.Id,
                    Name = u.Name,
                    UserType = u.UserType,
                    LastLoginDate = u.Credential.LastLoginDate

                }).ToListAsync();

            return new GetAllUsersDTO
            {
                Users = allUserDTOs
            };
        }

        public async Task<GetUserDTO> GetUserByIdAsync(long userId)
        {
            var userModel = await _dbContext.Users
                .Include(x => x.Credential)
                .Where(x => x.Id == userId)
                .Select(x => new GetUserDTO
                { 
                    UserId = x.Id,
                    Name = x.Name,
                    UserType = x.UserType,
                    LastLoginDate = x.Credential.LastLoginDate
                
                }).FirstOrDefaultAsync();

            return userModel;
        }
    }
}
