using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")] //Foregin key - when we don't need to load the entire Genre object, only foreign key
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()//Default constructor which will be used when creatin a NEW movie
        {
            Id = 0;//Set the Id to 0, to ensure that the HiddenField is populated
        }
        //Constructor for this ViewModel, i which we give the movie object, and the view model will be responsable for setting it initial state
        public MovieFormViewModel(Movie movie) 
        {
            //Initialiye a viewModel based on the Movie.cs
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}