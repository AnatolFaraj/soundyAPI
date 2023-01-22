using Core.DTOs.Tracks;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class TrackExtensions
    {
        public static GetTrackByIdDTO ToDTO(this TrackModel trackModel)
        {
            return new GetTrackByIdDTO()
            {
                Title = trackModel.Title,
                ArtistName = trackModel.Artist.Name,
                AlbumName = trackModel.Album.Name,
                CategoryName = trackModel.Category.Name,
                ReleaseDate = trackModel.TrackDetail.ReleaseDate,
                Picture = trackModel.TrackDetail.Picture,
                TrackFile = trackModel.TrackFile
            };
        }
    }
}
