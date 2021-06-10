using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminar.Model;

namespace Seminar.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Writer> Writers { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<City> Cities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string ADMIN_ID = "ff733ed8-c0ec-45a0-9f1a-35f1b9a9cf4c";
            const string ADMIN_ROLE_ID = ADMIN_ID;
            const string WRITER_ROLE_ID = "11447acb-29d5-465b-a429-3efcb0aa6315";
            const string EDITOR_ROLE_ID = "c097a117-64eb-4eee-873d-24be1bccb40f";
            const string USER_ROLE_ID = "644414f7-d093-43fa-b1bb-b208eef29f5e";
            const string GUEST_ROLE_ID = "1c390ba1-6c75-445a-b3dd-761633a70a9e";

            modelBuilder.Entity<City>().HasData(new City {ID = 1, Name = "Zagreb"});
            modelBuilder.Entity<City>().HasData(new City {ID = 2, Name = "Velika Gorica"});
            modelBuilder.Entity<City>().HasData(new City {ID = 3, Name = "New York"});
            modelBuilder.Entity<City>().HasData(new City {ID = 4, Name = "London"});
            modelBuilder.Entity<City>().HasData(new City {ID = 5, Name = "Las Vegas"});

            modelBuilder.Entity<Category>().HasData(new Category {ID = 1, Name = "Tech"});
            modelBuilder.Entity<Category>().HasData(new Category {ID = 2, Name = "Medicine"});
            modelBuilder.Entity<Category>().HasData(new Category {ID = 3, Name = "Mars"});

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "Administrator"});
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = WRITER_ROLE_ID, Name = "Writer", NormalizedName = "Writer"});
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = EDITOR_ROLE_ID, Name = "Editor", NormalizedName = "Editor"});
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = USER_ROLE_ID, Name = "User", NormalizedName = "User"});
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = GUEST_ROLE_ID, Name = "Guest", NormalizedName = "Guest"});

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "kkos1@tvz.hr",
                NormalizedUserName = "KKOS1@TVZ.HR",
                Email = "kkos1@tvz.hr",
                NormalizedEmail = "KKOS1@TVZ.HR",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEC8o+n97E/auGboF72xEtq4Q+h3POpHH4+6dSO9MbAqCTPlJlQE3qGsa7pOTKqkMqA==",
                SecurityStamp = string.Empty,
                PhoneNumber = "091 143 1325"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
