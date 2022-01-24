using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontdesk6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Frontdesk6.Models.Frontdesk;
using Microsoft.EntityFrameworkCore.Metadata;

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
            var keysProperties = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }

        public DbSet<Frontdesk6.Models.Frontdesk.Appointment> Appointment { get; set; }

        public DbSet<Frontdesk6.Models.Frontdesk.LayananFrontdesk> LayananFrontdesk { get; set; }
    }
}
