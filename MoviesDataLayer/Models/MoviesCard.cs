using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Models
{
   public class MoviesCard
    {
        [Key]
        public int CardId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Movie> Movies { get; set; }

        public double TotalPrice { get; set; }

    }
}
