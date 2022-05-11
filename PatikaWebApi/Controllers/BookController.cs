using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PatikaWebApi.BookOperations.CreateBook;
using PatikaWebApi.BookOperations.DeleteBook;
using PatikaWebApi.BookOperations.GetBooks;
using PatikaWebApi.BookOperations.GetBooksDetail;
using PatikaWebApi.BookOperations.UpdateBook;
using PatikaWebApi.DBOperations;
using System;

namespace PatikaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        //GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result= query.Handle();
            return Ok(result);
        }

        //GET: api/Books/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            GetBooksDetailQuery query = new GetBooksDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBooksDetailQueryValidator validator = new GetBooksDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            return Ok(result);
        
        }

        //POST: api/Books
        [HttpPost]
        public IActionResult AddBook([FromBody]CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
           
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        //PUT: api/Books/1
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody]BookUpdateModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
                command.Model = updatedBook;
                command.BookId = id;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle(); 
            return Ok();

        }
        //DELETE: api/Books
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            return Ok();
        }
    }
}
