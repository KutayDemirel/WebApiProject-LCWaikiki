using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PatikaWebApi.Application.GenreOperations.Commands.CreateGenre;
using PatikaWebApi.Application.GenreOperations.Commands.DeleteGenre;
using PatikaWebApi.Application.GenreOperations.Commands.UpdateGenre;
using PatikaWebApi.Application.GenreOperations.Queries.GetGenres;
using PatikaWebApi.Application.GenreOperations.Queries.GetGenresDetail;
using PatikaWebApi.DBOperations;

namespace PatikaWebApi.Controllers
{

    [ApiController]
    [Route("/api/[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        //GET: api/Genres
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public ActionResult GetGenreById(int id)
        {
            GetGenresDetailQuery query = new GetGenresDetailQuery(_context, _mapper);
            query.GenreId = id;
            GetGenresDetailQueryValidator validator = new GetGenresDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = newGenre;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = updatedGenre;
            command.GenreId = id;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }



    }
}
