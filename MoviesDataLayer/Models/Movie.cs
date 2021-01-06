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
            this.Categories = new List<Categories>();
        }
        [Key]
        public int MovieId { get; set; }
        public string  Title { get; set; }
        public double Price { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
