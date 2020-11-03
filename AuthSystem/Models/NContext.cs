using AuthSystem.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AuthSystem.Areas.Identity.Data;

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
        public DbSet<Prenotazione> Prenotazioni { get; set; }
        public DbSet<Postazione> Postazioni { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;

            //Ruolo Admin
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            //Ruolo Normale
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "37c42e1d - 92e5 - 4216 - a308 - 2fa43d187bf1",
                    Name = "Normal",
                    NormalizedName = "NORMAL"

                });

            //Credenziali di accesso Admin
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,

                SecurityStamp = string.Empty
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Horsa123@");

            //Inserimento nel db
            builder.Entity<ApplicationUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            //Posti in ufficio

        }

    }


}
