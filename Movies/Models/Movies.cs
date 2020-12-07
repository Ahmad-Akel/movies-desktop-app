using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    class Movies
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public int[] Cat_ID { get; set; }
        public float price { get; set; }
    }
}
