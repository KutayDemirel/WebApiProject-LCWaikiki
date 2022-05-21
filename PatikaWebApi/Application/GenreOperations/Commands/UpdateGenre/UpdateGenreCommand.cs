using AutoMapper;
using PatikaWebApi.DBOperations;
using System;
using System.Linq;

namespace PatikaWebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model;
        private readonly IStoreDbContext _context;


        public UpdateGenreCommand(IStoreDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if(genre == null)
            {
                throw new InvalidOperationException("Genre Bulunamadı");
            }

            //Update edilecek Genre daha önceden Başka bir Id ile mevcutsa hata fırlatır
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");
            }

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? Model.Name : genre.Name ;
            genre.isActive = Model.isActive;

            _context.SaveChanges();
             
        }
    }


    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
