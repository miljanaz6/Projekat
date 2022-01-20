using Microsoft.EntityFrameworkCore;
namespace Models
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Igrica { get; set; }
        public DbSet<Casa> Case { get; set; }
        public DbSet<TecnostBoje> Boje { get; set; }

        public GameContext(DbContextOptions options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Casa>()
                        .HasOne(p => p.TecnostBoje)
                        .WithOne(pp => pp.Casa)
                        .HasForeignKey<TecnostBoje>(pp => pp.CasaId);
        }
        


    }

}