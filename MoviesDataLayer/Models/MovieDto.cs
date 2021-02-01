using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesDataLayer.UWP.Models
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }
}
