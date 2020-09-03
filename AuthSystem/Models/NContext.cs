using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class NContext : DbContext
    {
        public NContext(DbContextOptions<NContext>options):base (options)
        {

        }

        public DbSet<Articoli> Articolis { get; set; }
        public DbSet<Versamenti> Versamentis { get; set; }

       
    }
}
