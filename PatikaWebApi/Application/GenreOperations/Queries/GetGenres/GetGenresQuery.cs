using AutoMapper;
using PatikaWebApi.DBOperations;
using System.Collections.Generic;
using System.Linq;

namespace PatikaWebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.isActive).OrderBy(x => x.Id);
            List<GenresViewModel> vm  = _mapper.Map<List<GenresViewModel>>(genres);
            return vm;
        }

    }

    public class GenresViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
