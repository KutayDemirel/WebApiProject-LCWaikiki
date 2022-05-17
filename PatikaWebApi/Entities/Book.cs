using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaWebApi.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        //foreign key
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
