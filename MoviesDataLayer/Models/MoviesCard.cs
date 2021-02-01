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


        public List<MovieDto> Movies { get; set; } = new List<MovieDto>();

        public double TotalPrice { get; set; } = 0;

        public void AddToCard (MovieDto movieDto)
        {
            if(this.Movies.Where(m=>m.MovieId == movieDto.MovieId).FirstOrDefault() == null)
            {
                Movies.Add(movieDto);
            }
        }
        public double CalculateTotalPrice()
        {
            TotalPrice = 0;
            if(Movies!=null)
            {
                foreach(var movie in Movies)
                {
                    TotalPrice += movie.Price;
                }
            }
            return TotalPrice;
        }

        public void RemoveFromCard(MovieDto movieDto)
        {
            if(Movies!=null)
            {
                Movies.Remove(movieDto);
            }
        }
    }
}
