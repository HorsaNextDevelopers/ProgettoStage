using AuthSystem.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthSystem.Models
{
    public class NContext : IdentityDbContext<ApplicationUser>
    {

        public NContext(DbContextOptions<NContext>options):base (options)
        {

        }

      
        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Versamento> Versamenti { get; set; }
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<ComponenteArticolo> ComponentiArticolo { get; set; }
        public DbSet<Linea> Linee { get; set; }
        public DbSet<Stazione> Stazion { get; set; }



        /* protected override void OnModelCreating(ModelBuilder builder)
         {

             base.OnModelCreating(builder);
             // Customize the ASP.NET Identity model and override the defaults if needed.
             // For example, you can rename the ASP.NET Identity table names and more.
             // Add your customizations after calling base.OnModelCreating(builder);
         }*/


    }
}
