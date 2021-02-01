using MoviesDataLayer.UWP.Controllers;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Helpers
{
   internal class MainHelper
    {
        internal static Movie ConvertMovieDtoToMovie( MovieDto movieDto)
        {
            MoviesController moviesController = new MoviesController();
            return moviesController.GetMovieById(movieDto.MovieId);
        }
        internal static User ConvertUserDtoToUser(UserDto userDto)
        {
            UsersController usersController = new UsersController();
            User user =   usersController.GetUserById(userDto.Id);
            return null;
        }
    }
}
