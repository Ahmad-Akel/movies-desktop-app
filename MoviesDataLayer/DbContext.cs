using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MoviesDataLayer.UWP.Models;
namespace MoviesDataLayer.UWP
{
    public class MoviesContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
       // public DbSet<MoviesCard> MoviesCard { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Subsecribe> Subsecribes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavMovies> Favorites { get; set; }
        public DbSet<UserOwnedMovies> OwnedMovies { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MoviesApp.db");
        }
    }

}
