using AutoMapper;
using FluentAssertions;
using PatikaWebApi.BookOperations.CreateBook;
using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using PatikaWebApi.UnitTests.Application.TestSetup;
using System;
using System.Linq;
using Xunit;

namespace PatikaWebApi.UnitTests.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTests : IClassFixture<CommonTextFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTextFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact] // works only on one data
        public void WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book() { Title = "WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100, PublishDate = new DateTime(1990, 01, 10), GenreId = 1, AuthorId = 2 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };
            
            //act assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
        }
        //Happy Path
        [Fact]
        public void ValidInputAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Title = "Hobbit",
                PageCount = 1000,
                PublishDate = DateTime.Now.Date.AddYears(-10),
                GenreId = 1,
                AuthorId = 2
            };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke(); // Invoke() is must or Should() to result

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
            book.PublishDate.Should().Be(model.PublishDate);
            book.AuthorId.Should().Be(model.AuthorId);

        }
    }
}
