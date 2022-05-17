using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
