using EntityLayer.Concrete;
using FilmIncelemeMvcProject.EntityLayer.Concrete;
using System.Data.Entity;

namespace FilmIncelemeMvcProject.DataAccessLayer.Concrete
{
    internal class Context : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        


    }
}