using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontdesk6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Frontdesk6.Models.Frontdesk;

namespace Frontdesk6.Data
{
    public class Frontdesk6Context : IdentityDbContext<AppUser>
    {
        public Frontdesk6Context(DbContextOptions<Frontdesk6Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Frontdesk6.Models.Frontdesk.Appointment> Appointment { get; set; }
    }
}
