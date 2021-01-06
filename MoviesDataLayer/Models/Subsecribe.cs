using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Models
{
  public  class Subsecribe
    {
        [Key]
        public int SubId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
