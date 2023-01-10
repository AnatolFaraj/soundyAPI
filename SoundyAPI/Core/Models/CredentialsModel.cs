using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CredentialsModel
    {
        public long UserId { get; set; }
        public UserModel User { get; set;  }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
    }
}
