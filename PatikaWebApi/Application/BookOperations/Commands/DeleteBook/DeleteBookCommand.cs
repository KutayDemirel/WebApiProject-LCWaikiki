using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(IStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(existBook => existBook.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamadı");
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
