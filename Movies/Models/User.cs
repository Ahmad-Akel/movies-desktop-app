using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    class User
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int permissin_Type { get; set; }
        public int subsecribe { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int[] favourites { get; set; }
        public int[] ownedMovies { get; set; }
    }
}
