using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Albums
{
    public class CreateAlbumDTO
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
