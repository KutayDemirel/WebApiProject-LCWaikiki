using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly IStoreDbContext _context;
        public int AuthorId;
        public UpdateAuthorViewModel Model;

        public UpdateAuthorCommand(IStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author == null)
            {
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı.");
            }

            author.FirstName = string.IsNullOrEmpty(Model.FirstName) ? author.FirstName : Model.FirstName;
            author.LastName = string.IsNullOrEmpty(Model.LastName) ? author.LastName : Model.FirstName;
            author.DateOfBirth = Model.DateOfBirth == default ? author.DateOfBirth : Model.DateOfBirth;


            _context.SaveChanges();

        }
    }

    public class UpdateAuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
