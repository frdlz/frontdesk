using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontdesk6.Models
{
    public class User
    {

        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Nama")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "NIP")]
        public string NIP { get; set; }
        [Required]
        [Display(Name = "Status/Jabatan")]
        public string Jabatan { get; set; }
        [Display(Name = "Seksi")]
        public string Penempatan { get; set; }


    }
}
