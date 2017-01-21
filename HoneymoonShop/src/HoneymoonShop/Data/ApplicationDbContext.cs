using HoneymoonShop.Models;
using HoneymoonShop.Models.Bruid;
using HoneymoonShop.Models.GebruikerModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HoneymoonShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           //Database.EnsureDeleted();
          // Database.EnsureCreated();
        }
        public ApplicationDbContext()
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Product_X_Kenmerk>()
            .HasKey(pk => new { pk.ProductId, pk.KenmerkId });

            builder.Entity<Product_X_Kenmerk>()
                .HasOne(pk => pk.Product)
                .WithMany(p => p.Product_X_Kenmerk)
                .HasForeignKey(pk => pk.ProductId);


            builder.Entity<Product_X_Kenmerk>()
                .HasOne(pk => pk.Kenmerk)
                .WithMany(k => k.Product_X_Kenmerk)
                .HasForeignKey(pk => pk.KenmerkId);

            builder.Entity<Neklijn>().ToTable("Neklijn");
            builder.Entity<Silhouette>().ToTable("Silhouette");
            builder.Entity<Kleur>().ToTable("Kleur");

            builder.Entity<Neklijn>();
            builder.Entity<Silhouette>();
            builder.Entity<Kleur>();
        }


        public virtual DbSet<Gebruiker> Gebruiker { get; set; }

        public virtual DbSet<Afspraak> Afspraak { get; set; }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<Merk> Merk { get; set; }

        public virtual DbSet<Kenmerk> Kenmerk { get; set; }

        public virtual DbSet<Categorie> Categorie { get; set; }

        public virtual DbSet<Product_X_Kenmerk> Product_X_Kenmerk { get; set; }

        public virtual DbSet<Neklijn> Neklijn { get; set; }

        public virtual DbSet<Kleur> Kleur { get; set; }

        public virtual DbSet<Stijl> Stijl { get; set; }

        public virtual DbSet<Silhouette> Silhouette { get; set; }

    }
}
