using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class PretparkContext : IdentityDbContext
    {
        public PretparkContext (DbContextOptions<PretparkContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Attractie> Attractie { get; set; } = default!;

        public DbSet<Gast>? Gast { get; set; }
        public DbSet<Medewerker>? Medewerker { get; set; }
    }
