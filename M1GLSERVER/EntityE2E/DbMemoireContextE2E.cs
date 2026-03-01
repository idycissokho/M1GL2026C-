using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.EntityE2E
{
    public class DbMemoireContextE2E : IdentityDbContext<Utilisateur, IdentityRole<int>, int>
    {
        public DbMemoireContextE2E(DbContextOptions<DbMemoireContextE2E> options)
            : base(options)
        {
        }

        public virtual DbSet<Memoire> memoires { get; set; }
        public virtual DbSet<Filiere> Filieres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilisateur>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Etudiant>("Etudiant")
                .HasValue<Encadreur>("Encadreur");
        }
    }
}
