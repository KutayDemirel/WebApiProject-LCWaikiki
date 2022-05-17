using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaWebApi.Common;
using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.BookOperations.GetBooksDetail
{
    public class GetBooksDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        //public string BookName { get; set; }

        public GetBooksDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public BookDetailViewModel Handle()
        { 
            var book = _dbContext.Books.Include(x=> x.Genre).Where(book => book.Id == BookId).SingleOrDefault();
            if( book == null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book); //new BookDetailViewModel();
            //vm.Title = book.Title;
            //vm.PageCount = book.PageCount;
            //vm.Genre = ((GenreEnum)book.GenreId).ToString();
            //vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
