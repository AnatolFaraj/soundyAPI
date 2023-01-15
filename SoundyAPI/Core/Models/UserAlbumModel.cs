using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserAlbumModel
    {
        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long AlbumId { get; set; }
        public AlbumModel Album { get; set; }



    }
}
