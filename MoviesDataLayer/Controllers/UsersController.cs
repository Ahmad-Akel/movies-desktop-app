using Microsoft.EntityFrameworkCore;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Controllers
{
    public class UsersController
    {
        private MoviesContext _db;

        public UsersController()
        {
            _db = new MoviesContext();
        }

        public bool AddNewUser(User user)
        {
            if (user == null) return false;

            var usr = _db.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (usr != null) return false;
            var premession = GetPermissions(user.Permissions.Role);
            user.Permissions = premession;
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;

        }

        public User GetUserById(int id)
        {
          return  _db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User UserLogin(User user)
        {
            if (user == null) return null;

            // Validate If User Exist 
            if (IsUserExist(user))
            {
                var usr = FindUser(user.UserName);
                if (usr.UserName == user.UserName && user.Password == usr.Password)
                {
                    return usr;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public bool AddMovies(List<MovieDto> movieDto, User user)
        {
            if (movieDto == null || user == null) return false;
            //Get Movies Keys
            List<int> moviesKeys = new List<int>();
            foreach (var movie in movieDto)
            {
                moviesKeys.Add(movie.MovieId);
            }
            foreach (var key in moviesKeys)
            {
              var isOwned =   _db.OwnedMovies.FirstOrDefault(m=>m.MovieId==key&&m.UserId==user.UserId)!=null;
                if(!isOwned)
                {
                    _db.OwnedMovies.Add(new UserOwnedMovies() { MovieId = key, UserId = user.UserId });
                }
            }
            _db.SaveChanges();
            return true;
        }

        public List<UserDto> GetUsers()
        {
            var users = _db.Users.ToList();
            var usersDto = new List<UserDto>();
            if(users!=null && users.Count>0)
            {
               foreach(var u in users)
                {
                    usersDto.Add(new UserDto { Id = u.UserId,
                        UserName = u.UserName,
                        Is_Sub = u.Is_Sub,
                        Password = u.Password,
                        Subscribtion = GetSubscribtion(u.SubId).Type,
                        Permession = GetPermissionById(u.PermessionId).Role,
                        EndDate = u.EndDate,
                        StartDate = u.StartDate });
                }
                return usersDto;
            }
            else
            {
                return null;
            }
        }

        public User FindUser(string username)
        {
            var usr = _db.Users.FirstOrDefault(u => u.UserName == username);
            return usr;
        }
        private bool IsUserExist(User user)
        {
            var usr = FindUser(user.UserName);
            if (usr != null)
                return true;

            return false;
        }
        private Permissions GetPermissions(string role)
        {
            var permession = _db.Permissions.FirstOrDefault(p => p.Role == role);

            return permession;
        }
        private Permissions GetPermissionById(int? id)
        {
            var permession = _db.Permissions.FirstOrDefault(p => p.PermessionId == id);
            if (permession != null)
                return permession;
            return new Permissions() { Role="No Role Assigned"};
        }
        private Subsecribe GetSubscribtion(int? id)
        {
            var sub = _db.Subsecribes.FirstOrDefault(s=> s.SubId == id);
            if (sub != null) 
            return sub;

            return new Subsecribe() { Type = "Not Subscribed!" };
        }
        public async Task<User> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            try
            {
                var _user = await _db.Users.FirstOrDefaultAsync(m => m.UserId == id);
                if (_user == null)
                {
                    return null;
                }
                _db.Users.Remove(_user);
                await _db.SaveChangesAsync();
                return _user;
            }
            catch
            {
                return null;
            }
        }
        public async Task<User> EditUser(User user)
        {
            if (user == null)
            {
                return null;
            }

                var _user = await _db.Users.FirstOrDefaultAsync(m => m.UserId == user.UserId);
                if (_user == null)
                {
                    return null;
                }
                _user.UserName = user.UserName;
            _user.Password = user.Password;
            _user.Permissions = user.Permissions;
            await _db.SaveChangesAsync();
                return _user;
          
        }
        public User SubscribeUser(User user, int subId)
        {
            if (user == null) return null;

            var _user = _db.Users.FirstOrDefault(u => u.UserId == user.UserId);
            _user.Is_Sub = true;
            _user.SubId = subId;
            switch (subId)
            {
                case 1:
                    _user.StartDate = DateTime.Today;
                    _user.EndDate = DateTime.Today.AddDays(30);
                    break;
                case 2:
                    _user.StartDate = DateTime.Today;
                    _user.EndDate = DateTime.Today.AddDays(365);
                    break;
                case 3:
                    _user.StartDate = DateTime.Today;
                    _user.EndDate = DateTime.Today.AddYears(100);
                    break;
                default:
                    return null;
            }
            _db.SaveChanges();
            return _user;
        }
    }
}
