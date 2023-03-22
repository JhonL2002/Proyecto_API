using Microsoft.EntityFrameworkCore;
using Proyecto_API.Models;

namespace Proyecto_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Villa Real",
                    Detail = "Detail of the village...",
                    UrlImage = "",
                    Occupants = 2,
                    SquareMeter = 100,
                    Fee = 100,
                    Amenity = 0,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                },
                new Villa()
                {
                    Id = 2,
                    Name = "Villa Juancho",
                    Detail = "Detail of the village Juancho...",
                    UrlImage = "",
                    Occupants = 4,
                    SquareMeter = 200,
                    Fee = 200,
                    Amenity = 0,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                }
            );
        }
    }
}
