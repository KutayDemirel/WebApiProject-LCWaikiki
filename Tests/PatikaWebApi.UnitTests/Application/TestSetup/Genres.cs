using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaWebApi.UnitTests.Application.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre() { Name = "Macera" }, 
                new Genre() { Name = "Strateji" }, 
                new Genre() { Name = "BilimKurgu" });
        }
    }
}
