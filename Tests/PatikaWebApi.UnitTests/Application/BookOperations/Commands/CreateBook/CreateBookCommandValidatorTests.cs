using AutoMapper;
using FluentAssertions;
using PatikaWebApi.BookOperations.CreateBook;
using PatikaWebApi.DBOperations;
using PatikaWebApi.Entities;
using PatikaWebApi.UnitTests.Application.TestSetup;
using System;
using Xunit;

namespace PatikaWebApi.UnitTests.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTextFixture>
    {

        [Theory]
        [InlineData("Lord Of The Rings", 0, 0, 0)]
        [InlineData("Lord Of The Rings", 0, 1, 0)]
        [InlineData("", 0, 0, 0)]
        [InlineData("", 100, 1, 0)]
        [InlineData("", 0, 1, 1)]
        [InlineData("Lor", 100, 1, 1)]
        [InlineData("Lord", 100, 1, 0)]
        [InlineData("Lord", 0, 0, 1)]
        [InlineData(" ", 150, 2, 2)]
        public void WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn(string title, int pageCount, int genreId, int authorID)
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = genreId,
                AuthorId = authorID
            };

            //act 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenDateTimeEqualsNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 1500,
                PublishDate = DateTime.Now.Date,
                GenreId = 1,
                AuthorId = 1
            };

            //act 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn_Exercise()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "",
                PageCount = 0,
                PublishDate = DateTime.Now.Date,
                GenreId = 0,
                AuthorId = 0
            };

            //act 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
        //Happy Path
        [Fact]
        public void WhenValidInputAreGiven_Valdator_ShouldNotBeReturnError()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 1500,
                PublishDate = DateTime.Now.Date.AddYears(-2),
                GenreId = 1,
                AuthorId = 1
            };

            //act 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
