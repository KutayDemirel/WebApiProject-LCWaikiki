using AutoMapper;
using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.Application.AuthorOperations.Queries.GetAuthorsDetail
{
    public class GetAuthorsDetailQuery
    {
        private readonly IStoreDbContext _context;
        public int AuthorId { get; set; }
        private readonly IMapper _mapper;


        public GetAuthorsDetailQuery(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(author => author.Id == AuthorId).SingleOrDefault();
            if (author == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı.");
            }
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
            return vm;

        }
    }

    public class AuthorDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
