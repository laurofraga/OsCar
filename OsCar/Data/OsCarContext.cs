using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OsCar.Models;

namespace OsCar.Data
{
    public class OsCarContext : DbContext
    {
        public OsCarContext (DbContextOptions<OsCarContext> options)
            : base(options)
        {
        }

        public DbSet<OsCar.Models.Carro> Carro { get; set; } = default!;

        public DbSet<OsCar.Models.Cliente>? Cliente { get; set; }

        public DbSet<OsCar.Models.Vendedor>? Vendedor { get; set; }

        public DbSet<OsCar.Models.Nota>? Nota { get; set; }
    }
}
