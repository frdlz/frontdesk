using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontdesk6.Models
{
    public class AppUser : IdentityUser
    {
        public string NIP { get; set; }
        public string Jabatan { get; set; }
        public string Penempatan { get; set; }
    }
}
