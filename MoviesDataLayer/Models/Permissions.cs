using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Models
{
   public class Permissions
    {
        [Key]
        public int PermessionId { get; set; }
        public string Role { get; set; }
    }
}
