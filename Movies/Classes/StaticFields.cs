using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Classes
{
   static class StaticFields
    {
        public static User CurrentUser { get; set; } = null;
        public static MoviesCard MoviesCard = new MoviesCard();
    }
}
