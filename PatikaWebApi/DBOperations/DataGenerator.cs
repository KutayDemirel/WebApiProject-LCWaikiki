using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatikaWebApi.Entities;
using System;
using System.Linq;

namespace PatikaWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any() && context.Genres.Any())
                {
                    return;
                }

                context.Authors.AddRange(new Author()
                {
                    FirstName = "Jack",
                    LastName = "London",
                    DateOfBirth = new DateTime(1876, 01, 12)
                },
                new Author()
                {
                    FirstName = "Sun",
                    LastName = "Tzu",
                    DateOfBirth = new DateTime(722, 01, 01)
                },
                new Author()
                {
                    FirstName = "Jules",
                    LastName = "Verne",
                    DateOfBirth = new DateTime(1828, 02, 08)
                });
                
                
                context.Genres.AddRange(new Genre()
                {
                    Name = "Macera"
                },
                new Genre()
                {
                    Name = "Strateji"
                },
                new Genre()
                {
                    Name = "BilimKurgu"
                });

                context.Books.AddRange(new Book()
                {
                    Title = "Beyaz Diş",
                    GenreId = 1, // Adventure
                    PageCount = 200,
                    PublishDate = new DateTime(1906, 10, 1)
                },

                new Book()
                {
                    Title = "Savaş Sanatı",
                    GenreId = 2, // Strategy
                    PageCount = 90,
                    PublishDate = new DateTime(782, 02, 15)
                },

                new Book()
                {
                    Title = "Dünyanın Merkezine Yolculuk",
                    GenreId = 3, // Science Fiction
                    PageCount = 176,
                    PublishDate = new DateTime(1864, 11, 25)
                });

                context.SaveChanges();
            }
        }
    }
}
