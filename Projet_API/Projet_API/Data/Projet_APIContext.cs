using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet_API.Models;

namespace Projet_API.Data
{
    public class Projet_APIContext : DbContext
    {
        public Projet_APIContext (DbContextOptions<Projet_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Projet_API.Models.Constructeur> Constructeur { get; set; } = default!;
        public DbSet<Projet_API.Models.ConsoledeJeux> Console { get; set; } = default!;
        public DbSet<Projet_API.Models.ChiffresVentes> ChiffresVentes { get; set; } = default!;

 


    }
}
