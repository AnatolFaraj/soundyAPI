using Core.DTOs.Albums;
using Core.DTOs.Tracks;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class AlbumExtensions
    {
        public static ArtistAlbumDTO ToDTO(this AlbumModel albumModel)
        {
            return new ArtistAlbumDTO
            {
                CategoryName = albumModel.Category.Name,
                Name = albumModel.Name,
                Picture = albumModel.Picture,
                ReleaseDate = albumModel.ReleaseDate,
                TotalListenings = albumModel.Listenings

            };
        }

        public static void FromDTO(this AlbumModel albumModel, CreateAlbumDTO createAlbumDTO, CategoryModel categoryModel)
        {
            albumModel.CategoryId = createAlbumDTO.CategoryId;
            albumModel.Category = categoryModel;
            albumModel.Name = createAlbumDTO.Name;
            albumModel.Picture = createAlbumDTO.Picture;
            albumModel.ReleaseDate = createAlbumDTO.ReleaseDate;

            foreach(var track in albumModel.Tracks)
            {
                track.TrackDetail.Picture = createAlbumDTO.Picture;
                track.TrackDetail.ReleaseDate = createAlbumDTO.ReleaseDate;
            }
        }
    }
}
