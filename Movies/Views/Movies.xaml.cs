using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MoviesDataLayer.UWP.Models;
using Movies.Views;
using Movies.ViewModel;
using Movies.Classes;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Movies : Page
    {
        public List<MovieDto> MoviesList { get; set; } = new List<MovieDto>();
        public List<Movie> FavoritesList { get; set; } = new List<Movie>();
        MoviesViewModel moviesViewModel = new MoviesViewModel();
        private MovieDto selectedMovie = new MovieDto();
        public Movies() 
        {
            this.InitializeComponent();
            var movieDtos = moviesViewModel.GetAllMoviesAsync().Result;
            if (movieDtos == null || movieDtos.Count <= 0) return;
            foreach (var movie in movieDtos)
            {
                movie.Image = "/Assets/Joker.jpg";
            }

            MoviesList = movieDtos;
            //MoviesList.Add( new Movie { Title="Avengers", Categories = "Action",Price =25,Image="/Assets/Avengers.jpg"});
            //MoviesList.Add(new Movie { Title = "Joker",Categories="Drama", Price = 40, Image = "/Assets/Joker.jpg" });
            //MoviesList.Add(new Movie { Title = "Chess",Categories="Fiction", Price = 30, Image = "/Assets/Chess.jpg" });
            //MoviesList.Add(new Movie { Title = "Rick&Morty",Categories="Cartoon", Price = 25, Image = "/Assets/Rick&Morty.jpg" });
            //MoviesList.Add(new Movie { Title = "MrRobot", Categories = "Fiction", Price = 40, Image = "/Assets/MrRobot.jpg" });
            //MoviesList.Add(new Movie { Title = "Avengers", Categories = "Action", Price = 30, Image = "/Assets/Avengers.jpg" });
            //MoviesList.Add(new Movie { Title = "Chess", Categories = "Fiction", Price = 25, Image = "/Assets/Chess.jpg" });
            //MoviesList.Add(new Movie { Title = "Joker", Categories = "Drama", Price = 40, Image = "/Assets/Joker.jpg" });
            //MoviesList.Add(new Movie { Title = "Rick&Morty", Categories = "Cartoon", Price = 30, Image = "/Assets/Rick&Morty.jpg" });

        }
       
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            /// Item Clicked;
            var movie = (MovieDto)e.ClickedItem;
            selectedMovie = movie;
            InfoTextBlock.Text = "Name: " + movie.Title + "\n" + "Price: " + movie.Price + "$" + "\n" + "Category: " + movie.Category;
            addtofavorite.Visibility = Visibility;
            addtocard.Visibility = Visibility;
        }
        private void AddToCard_Click(object sender, RoutedEventArgs e)
        {
            // Add ToCard;
            StaticFields.MoviesCard.AddToCard(selectedMovie);
            addtoctextbox.Text = "added to the card successfully";
        }
        private void AddToFavorite_Click(object sender, RoutedEventArgs e)
        {
            // to fav 
            moviesViewModel.AddMovieToFav(selectedMovie, StaticFields.CurrentUser);
            addtoftextbox.Text = "added to favorites successfully";
        }

    }
}
