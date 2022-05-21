using Microsoft.EntityFrameworkCore;
using PatikaWebApi.Entities;

namespace PatikaWebApi.DBOperations
{
    public class BookStoreDbContext : DbContext,IStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        //public object Where { get; internal set; }
    }
}
