using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminar.Model;

namespace Seminar.DAL
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Writer> Writers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Article> Articles { get; set; }

        public new DbSet<AppRole> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City {ID = 1, Name = "Zagreb"});
            modelBuilder.Entity<City>().HasData(new City {ID = 2, Name = "Velika Gorica"});
            modelBuilder.Entity<City>().HasData(new City {ID = 3, Name = "New York"});
            modelBuilder.Entity<City>().HasData(new City {ID = 4, Name = "London"});
            modelBuilder.Entity<City>().HasData(new City {ID = 5, Name = "Las Vegas"});

            modelBuilder.Entity<Category>().HasData(new Category {ID = 1, Name = "Tech"});
            modelBuilder.Entity<Category>().HasData(new Category {ID = 2, Name = "Medicine"});
            modelBuilder.Entity<Category>().HasData(new Category {ID = 3, Name = "Mars"});

            modelBuilder.Entity<AppRole>().HasData(new AppRole("Admin") {NormalizedName = "Administrator"});
            modelBuilder.Entity<AppRole>().HasData(new AppRole("Writer") {NormalizedName = "Writer"});
            modelBuilder.Entity<AppRole>().HasData(new AppRole("Editor") {NormalizedName = "Editor"});
            modelBuilder.Entity<AppRole>().HasData(new AppRole("Reviewer") {NormalizedName = "Reviewer"});
            modelBuilder.Entity<AppRole>().HasData(new AppRole("User") {NormalizedName = "User"});
            modelBuilder.Entity<AppRole>().HasData(new AppRole("Guest") {NormalizedName = "Visitor"});
        }
    }
}
