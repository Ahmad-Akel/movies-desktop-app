using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDataLayer.UWP.Controllers;
using MoviesDataLayer.UWP.Models;

namespace Movies.ViewModel
{
  public  class UserViewModel
    {
        private UsersController users = new UsersController();

        public  bool CrateUser(string username , string pass)
        {

            return users.AddNewUser(new User { UserName = username, Password = pass });
        }
        public bool UserLogin(string username, string pass)
        {
            return users.UserLogin(new User { UserName = username, Password = pass });
        }
    }
}
