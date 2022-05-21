using Microsoft.EntityFrameworkCore;
using PatikaWebApi.Entities;

namespace PatikaWebApi.DBOperations
{
    public interface IStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }

        int SaveChanges();
    }
    
}
