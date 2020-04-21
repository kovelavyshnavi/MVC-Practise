using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ActionResults.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genres Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
    }
}