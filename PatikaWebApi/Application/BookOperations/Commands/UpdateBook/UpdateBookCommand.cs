using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public BookUpdateModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(existBook => existBook.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Güncellenecek kitap Bulunamadı");
            }

            book.Title = Model.Title == default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            //book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            //book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;

            _dbContext.SaveChanges();
        }
    }

    public class BookUpdateModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
}
