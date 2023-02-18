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

        public static void FromDTO(this TrackModel trackModel, CreateTrackDTO createTrackDTO, AlbumModel trackContents)
        {
            trackModel.Album = trackContents;
            trackModel.Category = trackContents.Category;
            trackModel.Artist = trackContents.Artist;
            trackModel.AlbumId = trackContents.Id;
            trackModel.CategoryId = trackContents.CategoryId;
            trackModel.ArtistId = trackContents.ArtistId;
            trackModel.Title = createTrackDTO.Title;
            trackModel.TrackFile = createTrackDTO.TrackFile;
            trackModel.TrackDetail.Picture = trackContents.Picture;
            trackModel.TrackDetail.ReleaseDate = trackContents.ReleaseDate;

        }
    }
}
