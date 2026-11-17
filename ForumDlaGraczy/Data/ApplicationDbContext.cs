using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ForumDlaGraczy.Models;

namespace ForumDlaGraczy.Data
{
    public class ApplicationDbContext : IdentityDbContext<UzytkownikAplikacji>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Watek> Topics { get; set; }
        public DbSet<Odpowiedz> Posts { get; set; }
        public DbSet<KategoriaForumModel> Kategorie { get; set; }
        public DbSet<PodforumModel> Podfora { get; set; }
        public DbSet<OgloszenieModel> Ogloszenia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Odpowiedz>()
                .HasOne(p => p.Autor)
                .WithMany(u => u.Posty)
                .HasForeignKey(p => p.UzytkownikAplikacjiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Watek>()
                .HasOne(t => t.Autor)
                .WithMany(u => u.Watki)
                .HasForeignKey(t => t.UzytkownikAplikacjiId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}