using AuthSystem.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<Stazione> Stazioni { get; set; }

        /*protected override void OnModelCreating(ModelBuilder builder)
         {

             base.OnModelCreating(builder);
             // Customize the ASP.NET Identity model and override the defaults if needed.
             // For example, you can rename the ASP.NET Identity table names and more.
             // Add your customizations after calling base.OnModelCreating(builder);
         }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                NormalizedUserName = "Admin",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Horsa123@"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

    }


}
