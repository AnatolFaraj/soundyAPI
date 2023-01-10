using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ArtistModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ListeningsLastMonth { get; set; }
        public ICollection<AlbumModel> Albums { get; set; }
        public ICollection<TrackModel> Tracks { get; set; }
        public ICollection<UserModel> Users { get; set; }

    }
}
