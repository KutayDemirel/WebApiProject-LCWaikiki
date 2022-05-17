using AutoMapper;
using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.Application.GenreOperations.Queries.GetGenresDetail
{
    public class GetGenresDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenresDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId && x.isActive);
            if (genre == null)
            {
                throw new InvalidOperationException("Tür bulunamadı");
            }
            GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);
            return vm;
        }

    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
