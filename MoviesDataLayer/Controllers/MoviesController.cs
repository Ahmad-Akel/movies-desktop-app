using Microsoft.EntityFrameworkCore;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataLayer.UWP.Controllers
{
   public class MoviesController
    {
        //Get ALl movies ; 
        private MoviesContext _db;
        public MoviesController()
        {
            _db = new MoviesContext();
        }

        public Movie GetMovieById(int Id)
        {
          return   _db.Movies.FirstOrDefault(m => m.MovieId == Id);
        }

        public async Task<List<MovieDto>> GetMovies()
        {
           
                var movies  =  await _db.Movies.ToListAsync();
            var moviesDto = new List<MovieDto>();
                if(movies!=null && movies.Count>0)
                {
                foreach (var movie in movies) 
                {
                    moviesDto.Add(
                        new MovieDto() { MovieId = movie.MovieId, Title = movie.Title, Price = movie.Price, Image = movie.Image, Category = GetCategoryName(movie.CatId).Name });
                }
                    return moviesDto;
                }else
                {
                    return null;
                }

        }
        //add movie 
        public async Task<Movie> AddMovie(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }
            movie.Category = GetCategoryName(movie.CatId);
            await _db.Movies.AddAsync(movie);
                await _db.SaveChangesAsync();
                return movie;
            
        }

        public bool RemoveMovieFromFav(Movie movie, User user)
        {
            if (movie == null || user == null) return false;

            try
            {
                _db.Remove(_db.Favorites.FirstOrDefault(f => f.MovieId == movie.MovieId && f.UserId == user.UserId));
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MovieDto> GetFavMovies(User user)
        {
            if (user == null) return null;
           var userfavs =    _db.Favorites.Where(f => f.UserId == user.UserId).ToList();
            List<int> MoviesKeys = new List<int>();
            foreach (var fav in userfavs)
            {
                MoviesKeys.Add(fav.MovieId);
            }
            var movies =    _db.Movies.Where(m => MoviesKeys.Contains(m.MovieId));
            var moviesDto = new List<MovieDto>();

            if (movies!=null)
            {
                foreach (var movie in movies)
                {
                    moviesDto.Add(
                       new MovieDto() { MovieId = movie.MovieId, Title = movie.Title, Price = movie.Price, Image = movie.Image, Category = GetCategoryName(movie.CatId).Name });
                }
                return moviesDto;
            }
            return null;
        }

        // edit Movie 
        public async Task<Movie> EditMovie(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }
            try
            {
               var _movie =  await _db.Movies.FirstOrDefaultAsync(m => m.MovieId == movie.MovieId);
                if(_movie == null)
                {
                    return null;
                }
                _movie.Price = movie.Price;
                _movie.Title = movie.Title;
                _movie.Category = GetCategoryName(movie.CatId);
                await _db.SaveChangesAsync();
                return _movie;
            }
            catch
            {
                return null;
            }
        }
        // Delete ;
        public async Task<Movie> DeleteMovie(int id)
        {
            if (id<=0)
            {
                return null;
            }
            try
            {
                var _movie = await _db.Movies.FirstOrDefaultAsync(m => m.MovieId ==id);
                if (_movie == null)
                {
                    return null;
                }
                _db.Movies.Remove(_movie);
                await _db.SaveChangesAsync();
                return _movie;
            }
            catch
            {
                return null;
            }
        }
        private Categories GetCategoryName(int? id)
        {
            var category = _db.Categories.FirstOrDefault(p => p.CatId == id);
            if (category != null)
                return category;
            return new Categories() { Name = "No Category" };
        }
        private Categories GetCategoryName(string name)
        {
            var category = _db.Categories.FirstOrDefault(p => p.Name == name);
            if (category != null)
                return category;
            return new Categories() { Name = "No Category" };
        }
        
        public bool AddMovieToFavorite(Movie movie , User user)
        {
            if (movie == null || user == null) return false;

            var fav = _db.Favorites.FirstOrDefault(f => f.UserId == user.UserId && f.MovieId == movie.MovieId);
            if (fav != null) return false;
            try
            {
                _db.Favorites.Add(new UserFavMovies() { MovieId = movie.MovieId, UserId = user.UserId });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }
        public List<MovieDto> GetOwnedMovies(User user)
        {
            if (user == null) return null;
            var userMovies = _db.OwnedMovies.Where(o => o.UserId == user.UserId).ToList();
            List<int> MoviesKeys = new List<int>();
            foreach (var owned in userMovies)
            {
                MoviesKeys.Add(owned.MovieId);
            }
            var movies = _db.Movies.Where(m => MoviesKeys.Contains(m.MovieId));
            var moviesDto = new List<MovieDto>();

            if (movies != null)
            {
                foreach (var movie in movies)
                {
                    moviesDto.Add(
                       new MovieDto() { MovieId = movie.MovieId, Title = movie.Title, Price = movie.Price, Image = movie.Image, Category = GetCategoryName(movie.CatId).Name });
                }
                return moviesDto;
            }
            return null;
        }
    }
}
