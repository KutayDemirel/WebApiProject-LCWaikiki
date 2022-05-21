using AutoMapper;
using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using System;
using System.Linq;

namespace PatikaWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly IStoreDbContext _context;
        public CreateAuthorViewModel Model;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if ( author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();

        }
    }

    public class CreateAuthorViewModel {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth{ get; set; }
    }
}
