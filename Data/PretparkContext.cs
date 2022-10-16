using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models;

public class PretparkContext : IdentityDbContext
    {
        public PretparkContext (DbContextOptions<PretparkContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
        }

        public DbSet<Attractie> Attractie { get; set; } = default!;
        public DbSet<Gast>? Gast { get; set; }
    }
