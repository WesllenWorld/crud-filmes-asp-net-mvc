using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCFilmes2025.Models;

namespace MVCFilmes2025.Data
{
    public class MVCFilmes2025Context : DbContext
    {
        public MVCFilmes2025Context (DbContextOptions<MVCFilmes2025Context> options)
            : base(options)
        {
        }

        public DbSet<MVCFilmes2025.Models.Filme> Filme { get; set; } = default!;
    }
}
