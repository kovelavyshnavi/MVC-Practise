using MVC_ActionResults.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ActionResults.ViewModels
{
    public class MovieViewModel
    {
       // public Movies Movies { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public IEnumerable<Genres> Genres { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movies movies)
        {
            Id = movies.Id;
            Name = movies.Name;
            ReleaseDate = movies.ReleaseDate;
            GenreId = movies.GenreId;
            NumberInStock = movies.NumberInStock;
        }
    }
}