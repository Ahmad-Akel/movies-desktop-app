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
using Movies.ViewModel;
using Movies.Classes;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Favorite : Page
    {
        public List<MovieDto> FavoritesList { get; set; } = new List<MovieDto>();
        private MoviesViewModel moviesViewModel = new MoviesViewModel();
        MovieDto selectedMovie = new MovieDto();
        public Favorite()
        {
            this.InitializeComponent();
            FavoritesList = moviesViewModel.GetFavoritesMovies(StaticFields.CurrentUser);
            //FavoritesList.Add(new Movie { Title = "Avengers", Categories = "Action", Price = 25, Image = "/Assets/Avengers.jpg" });
            //FavoritesList.Add(new Movie { Title = "Joker", Categories = "Drama", Price = 40, Image = "/Assets/Joker.jpg" });
            //FavoritesList.Add(new Movie { Title = "Chess", Categories = "Fiction", Price = 30, Image = "/Assets/Chess.jpg" });
            //FavoritesList.Add(new Movie { Title = "Rick&Morty", Categories = "Cartoon", Price = 25, Image = "/Assets/Rick&Morty.jpg" });
            //FavoritesList.Add(new Movie { Title = "MrRobot", Categories = "Fiction", Price = 40, Image = "/Assets/MrRobot.jpg" });
            //FavoritesList.Add(new Movie { Title = "Avengers", Categories = "Action", Price = 30, Image = "/Assets/Avengers.jpg" });
            //FavoritesList.Add(new Movie { Title = "Chess", Categories = "Fiction", Price = 25, Image = "/Assets/Chess.jpg" });
            //FavoritesList.Add(new Movie { Title = "Joker", Categories = "Drama", Price = 40, Image = "/Assets/Joker.jpg" });
            //FavoritesList.Add(new Movie { Title = "Rick&Morty", Categories = "Cartoon", Price = 30, Image = "/Assets/Rick&Morty.jpg" });
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movie = (MovieDto)e.ClickedItem;
            selectedMovie = movie;
            InfoTextBlock.Text = "Name: " + movie.Title + "\n" + "Price: " + movie.Price +"$"+ "\n" + "Category: " + movie.Category;
            addtocard.Visibility = Visibility;
            delete.Visibility = Visibility;
            deletefromtextbox.Text = String.Empty;
            addtoctextbox.Text = String.Empty;

        }
        private void AddToCard_Click(object sender, RoutedEventArgs e)
        {
            StaticFields.MoviesCard.AddToCard(selectedMovie);
            addtoctextbox.Text = "Added To card Successfully";
            InfoTextBlock.Text = string.Empty;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
         var deleted =   moviesViewModel.RemoveMovieFromFav(selectedMovie, StaticFields.CurrentUser);
           if(deleted) deletefromtextbox.Text = "Deleted successfully";

            gridview1.ItemsSource =  FavoritesList = moviesViewModel.GetFavoritesMovies(StaticFields.CurrentUser);
            InfoTextBlock.Text = string.Empty;
        }

    }
}
