using Microsoft.EntityFrameworkCore;

namespace M1GLSERVER.EntityE2E
{
    public class DbMemoireContextE2E : DbContext
    {
        public DbMemoireContextE2E(DbContextOptions<DbMemoireContextE2E> options)
            : base(options)
        {
        }

        public virtual DbSet<Memoire> memoires { get; set; }
        public virtual DbSet<Encadreur> Encadreurs { get; set; }
        public virtual DbSet<Etudiant> Etudiants { get; set; }
        public virtual DbSet<Filiere> Filieres { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<MemoireView>()
        //         .ToTable("vw_listememoires", "public")
        //         .HasNoKey();
            
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
