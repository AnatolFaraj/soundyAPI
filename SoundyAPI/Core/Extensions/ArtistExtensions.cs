using Core.DTOs.Artists;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ArtistExtensions
    {
        public static GetArtistByIdDTO ToDTO(this ArtistModel artistModel)
        {
            return new GetArtistByIdDTO()
            {
                Name = artistModel.Name,
                Description = artistModel.Description,
                Category = artistModel.Category.Name,
                ListeningsLastMonth = artistModel.ListeningsLastMonth
            };
        }

        public static void FromDTO(this ArtistModel artistModel, CreateArtistDTO artistDTO, CategoryModel categoryModel)
        {
            artistModel.Name = artistDTO.Name;
            artistModel.Description = artistDTO.Description;
            artistModel.CategoryId = artistDTO.CategoryId;
            artistModel.Category = categoryModel;

        }
    }
}
