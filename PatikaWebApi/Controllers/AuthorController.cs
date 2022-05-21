using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using PatikaWebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using PatikaWebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using PatikaWebApi.Application.AuthorOperations.Queries.GetAuthors;
using PatikaWebApi.Application.AuthorOperations.Queries.GetAuthorsDetail;
using PatikaWebApi.DBOperations;

namespace PatikaWebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET: api/Authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorsDetailQuery query = new GetAuthorsDetailQuery(_context, _mapper);
            query.AuthorId = id;

            GetAuthorsDetailQueryValidator validator = new GetAuthorsDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAuthorViewModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = model;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateAuthorViewModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = model;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId=id;

            command.Handle();
            return Ok();
        }

    }
}
