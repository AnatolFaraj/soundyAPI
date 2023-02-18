using Core.DTOs.Artists;
using Core.Exceptions;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Artists
{
    public class ArtistsManager : IArtistRepository
    {
        private readonly SoundyContext _context;

        public ArtistsManager(SoundyContext soundyContext)
        {
            _context = soundyContext;
        }

        public async Task<GetArtistByIdDTO> CreateArtist(CreateArtistDTO createArtistDTO)
        {
            var categoryModel = await _context.Categories
                .Where(x => x.Id == createArtistDTO.CategoryId)
                .FirstOrDefaultAsync();

            if(categoryModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Invalid category, Id: {createArtistDTO.CategoryId}"
                };
            }

            var artistModel = new ArtistModel()
            {
                Name = createArtistDTO.Name,
                CategoryId = createArtistDTO.CategoryId,
                Description = createArtistDTO.Description,
                Category = categoryModel
            };

            _context.Add(artistModel);
            await _context.SaveChangesAsync();

            return artistModel.ToDTO();
        }

        public async Task DeleteArtist(long artistId)
        {
            var artistModel = await _context.Artists
                .Where(x => x.Id == artistId)
                .Include(x => x.Albums)
                .Include(x => x.UserArtists)
                .FirstOrDefaultAsync();

            if(artistModel is null)
            {
                throw new CustomResponseException()
                {
                    ErrorDescription = $"Artist with id {artistId} doesn't exist",
                    StatusCode = (int)HttpStatusCode.NotFound
                };
            }

            _context.Remove(artistModel);

            await _context.SaveChangesAsync();

        }

        public async Task<GetArtistByIdDTO> EditArtist(long artistId, CreateArtistDTO createArtistDTO)
        {
            var artistModel = await _context.Artists
                .Where(a => a.Id == artistId)
                .Include(x => x.Category)
                .FirstOrDefaultAsync();

            if(artistModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Artist with Id {artistId} doesn't exist."
                };
            }

            var categoryModel = await _context.Categories
                .Where(x => x.Id == createArtistDTO.CategoryId)
                .FirstOrDefaultAsync();

            if(categoryModel is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = $"Category with id {createArtistDTO.CategoryId} doesn't exist."
                };
                
            }

           
            
             artistModel.FromDTO(createArtistDTO, categoryModel);
             await _context.SaveChangesAsync();
            

            return artistModel.ToDTO();
        }

        public async Task<GetAllArtistsDTO> GetAllArtistsDTO()
        {
            var allArtistDTOs = await _context.Artists
                .Select(x => new GetArtistByIdDTO() 
                { 
                    Name = x.Name,
                    Description = x.Description,
                    Category = x.Category.Name,
                    ListeningsLastMonth = x.ListeningsLastMonth
                })
                .ToListAsync();

            return new GetAllArtistsDTO()
            {
                Artists = allArtistDTOs
            };
        }

        public async Task<GetArtistByIdDTO> GetArtistById(long id)
        {
            var artistDTO = await _context.Artists
                .Where(x => x.Id == id)
                .Select(x => new GetArtistByIdDTO()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Category = x.Category.Name,
                    ListeningsLastMonth = x.ListeningsLastMonth

                }).FirstOrDefaultAsync();

            if(artistDTO is null)
            {
                throw new CustomResponseException()
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    ErrorDescription = $"Artist with id {id} doesn't exist."
                };
            }

            return artistDTO;
        }
    }
}
