using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models;

public class PretparkContext : IdentityDbContext
    {
        public PretparkContext (DbContextOptions<PretparkContext> options)
            : base(options)
        {
        }

        public DbSet<Attractie> Attractie { get; set; } = default!;

        public DbSet<Gast>? Gast { get; set; }
    }
