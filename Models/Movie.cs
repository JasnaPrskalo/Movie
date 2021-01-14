using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; } //Navigation property - navigate from one type to another

        [Display(Name = "Genre")] //Foregin key - when we don't need to load the entire Genre object, only foreign key
        [Required]
        public int GenreId { get; set; }


        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
               

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}
