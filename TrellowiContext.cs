using Microsoft.EntityFrameworkCore;
using TRELLOBACK.Models;

namespace TRELLOBACK.Context{
    public class TrellowiContext : DbContext
    {

    public TrellowiContext(DbContextOptions<TrellowiContext> options) : base(options)
    {
    }
    public virtual DbSet<Projet> Projets { get; set; }
    public virtual DbSet<ProjetDTO> ProjetsDTO { get; set; }
    public virtual DbSet<Liste> Listes { get; set; }
    public virtual DbSet<ListeDTO> ListesDTO { get; set; }
    public virtual DbSet<Carte> Cartes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=tcp:trellowiwi.database.windows.net,1433;Initial Catalog=TRELLO;Persist Security Info=False;User ID=Wiwi;Password=Superwi86;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Projet>()
            .HasMany(p => p.Listes)
            .WithOne(l => l.Projet)
            .HasForeignKey(l => l.ProjetId);
            }
    }
}