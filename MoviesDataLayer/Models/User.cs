using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Models
{
    public class User
    {
      
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? PermessionId { get; set; }
        public Permissions Permissions { get; set; }
        public bool Is_Sub { get; set; }

        public int? SubId { get; set; }
        public Subsecribe Subsecribtion { get; set; }


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
