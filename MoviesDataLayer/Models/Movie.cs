using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Models
{
   public class Movie
    {
        public Movie()
        {
            
        }
        [Key]
        public int MovieId { get; set; }
        public string  Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int? CatId { get; set; }
        public Categories Category { get; set; }
    }
}
