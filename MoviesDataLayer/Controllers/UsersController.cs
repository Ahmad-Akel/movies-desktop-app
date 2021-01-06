using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesDataLayer.UWP.Controllers
{
   public class UsersController
    {
        private MoviesContext _db;
        private User _user;
        public UsersController()
        {
            _db = new MoviesContext();
            _user = new User();
        }
        public  bool  AddNewUser(User user)
        {
            if (user == null) return false;
            try
            {
              var usr =  _db.Users.Where(u=>u.UserName==user.UserName).FirstOrDefault();
                if (usr != null) return false;
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UserLogin(User user)
        {
            if (user == null) return false;

            // Validate If User Exist 
            if(IsUserExist(user))
            {
              var usr =   FindUser(user.UserName);
              if(usr.UserName==user.UserName&&user.Password==usr.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
             
            }else
            {
                return false;
            }
        }

        private User FindUser(string username)
        {
            var usr = _db.Users.Where(u => u.UserName == username).FirstOrDefault();
            return usr;
        }
        private bool IsUserExist(User user)
        {
            var usr = FindUser(user.UserName);
            if (usr != null)
                return true;

            return false;
        }

    }
}
