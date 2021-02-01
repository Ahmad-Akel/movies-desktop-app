using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesDataLayer.UWP.Models
{
  public  class UserDto
    {
        public int Id { get; set; }
        public string  UserName { get; set; }
        public string  Password { get; set; }
        public string Permession { get; set; }
        public bool Is_Sub { get; set; }
        public string Subscribtion { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
