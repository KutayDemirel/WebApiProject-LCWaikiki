using AutoMapper;
using PatikaWebApi.Application.AuthorOperations.Commands.CreateAuthor;
using PatikaWebApi.Application.AuthorOperations.Queries.GetAuthors;
using PatikaWebApi.Application.AuthorOperations.Queries.GetAuthorsDetail;
using PatikaWebApi.Application.GenreOperations.Commands.CreateGenre;
using PatikaWebApi.Application.GenreOperations.Queries.GetGenres;
using PatikaWebApi.Application.GenreOperations.Queries.GetGenresDetail;
using PatikaWebApi.BookOperations.CreateBook;
using PatikaWebApi.BookOperations.GetBooks;
using PatikaWebApi.BookOperations.GetBooksDetail;
using PatikaWebApi.Entities;

namespace PatikaWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src
                => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src 
                => src.Genre.Name));
            //CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (
            //    (GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<CreateAuthorViewModel, Author>();
        }

    }
}
