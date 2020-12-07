using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    class ShoppingCard
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int[] orders { get; set; }
        public float totalprice { get; set; }
    }
}
