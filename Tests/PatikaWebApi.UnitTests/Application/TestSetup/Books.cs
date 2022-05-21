using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaWebApi.UnitTests.Application.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
               new Book() { Title = "Beyaz Diş", GenreId = 1, PageCount = 200, PublishDate = new DateTime(1906, 10, 1) },
               new Book() { Title = "Savaş Sanatı", GenreId = 2, PageCount = 90, PublishDate = new DateTime(782, 02, 15) },
               new Book() { Title = "Dünyanın Merkezine Yolculuk", GenreId = 3, PageCount = 176, PublishDate = new DateTime(1864, 11, 25) });

        }
    }
}
