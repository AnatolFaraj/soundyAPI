using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Artists
{
    public class GetAllArtistsDTO
    {
        public List<GetArtistByIdDTO> Artists { get; set; }
    }
}
