using Movies.Helpers;
using MoviesDataLayer.UWP.Controllers;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.ViewModel
{
   internal class MoviesViewModel
    {
        MoviesController moviesController = new MoviesController();
        
        internal async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            var movies =    await moviesController.GetMovies();
            return movies;
        }
        internal bool AddMovie(Movie movie)
        {
            var addedmovie =  moviesController.AddMovie(movie);
            return addedmovie!=null ? true : false;
        }
        internal bool DeleteMovie (int movieId)
        {
            var DeletedMovie = moviesController.DeleteMovie(movieId);
            return DeletedMovie != null ? true : false;
        }
        internal bool EditMovie(Movie movie)
        {
            var EditMovie = moviesController.EditMovie(movie);
            return EditMovie != null ? true : false;
        }
        internal bool AddMovieToFav(MovieDto movie ,User user)
        {
            return moviesController.AddMovieToFavorite(MainHelper.ConvertMovieDtoToMovie(movie),user);
        }
        internal bool RemoveMovieFromFav(MovieDto movie, User user)
        {
            return moviesController.RemoveMovieFromFav(MainHelper.ConvertMovieDtoToMovie(movie), user);
        }
        internal List<MovieDto> GetFavoritesMovies(User user)
        {
            return moviesController.GetFavMovies(user);
        }
        internal List<MovieDto> GetOwnedMovies(User user)
        {
            return moviesController.GetOwnedMovies(user);
        }
    }
}
