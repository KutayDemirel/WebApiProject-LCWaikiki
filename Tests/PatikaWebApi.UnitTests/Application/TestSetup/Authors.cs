using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaWebApi.UnitTests.Application.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author() { FirstName = "Jack", LastName = "London", DateOfBirth = new DateTime(1876, 01, 12) }, 
                new Author() { FirstName = "Sun", LastName = "Tzu", DateOfBirth = new DateTime(722, 01, 01) }, 
                new Author() { FirstName = "Jules", LastName = "Verne", DateOfBirth = new DateTime(1828, 02, 08) });
        }
    }
}
