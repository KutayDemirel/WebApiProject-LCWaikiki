using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaWebApi.Common;
using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x => x.Genre).OrderBy(book => book.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PageCount = book.PageCount,
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //    });
            //}

            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }

    }
}
