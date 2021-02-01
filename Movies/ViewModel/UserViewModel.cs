using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Classes;
using MoviesDataLayer.UWP.Controllers;
using MoviesDataLayer.UWP.Models;

namespace Movies.ViewModel
{
  public  class UserViewModel
    {
        private UsersController userController;
        public UserViewModel()
        {
            userController = new UsersController();
        }
        public  bool CrateUser(User user)
        {
            return userController.AddNewUser(user);
        }
        public User UserLogin(string username, string pass)
        {
            return userController.UserLogin(new User { UserName = username, Password = pass});
        }
        public User GetUserByName(string name)
        {
           var user =  userController.FindUser(name);
            return user;
        }

        internal  List<UserDto> GetUsers()
        {
           return  userController.GetUsers();
            
        }
        internal bool DeleteUser(int id)
        {
            return userController.DeleteUser(id).Result!=null;

        }
        internal bool EditUser(User user)
        {
            return userController.EditUser(user).Result != null;

        }
        internal bool AddMoviesToUser(List<MovieDto> movieDto ,User user)
        {
            return userController.AddMovies(movieDto, user);
           
        }
        internal void Subscribe(User user , int subId)
        {
           StaticFields.CurrentUser =   userController.SubscribeUser(user, subId);
        }
        public void InitPermissions()
        {
            PermissionsController ps = new PermissionsController();
            ps.Init();
            //ps.InitCats();
            //ps.InitSubs();
        }
    }
}
