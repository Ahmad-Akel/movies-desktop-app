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
using Movies.Classes;
using Movies.ViewModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyCard : Page
    {
        public List<MovieDto> ShippingCard { get; set; } = new List<MovieDto>();
        UserViewModel userViewModel = new UserViewModel();
        MovieDto selectedMovie = new MovieDto();
        public MyCard()
        {
            this.InitializeComponent();
            ShippingCard = StaticFields.MoviesCard.Movies;
            paytext.Text = "Total Price: " + StaticFields.MoviesCard.CalculateTotalPrice().ToString() ;
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movie = (MovieDto)e.ClickedItem;
            selectedMovie = movie;
            InfoTextBlock.Text = "Name: " + movie.Title + "\n" + "Price: " + movie.Price + "$" + "\n" + "Category: " + movie.Category;
            delete.Visibility = Visibility;
           
        }
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            StaticFields.MoviesCard.RemoveFromCard(selectedMovie);
            GridView.ItemsSource = StaticFields.MoviesCard.Movies;
            paytext.Text = "Total Price: " + StaticFields.MoviesCard.CalculateTotalPrice().ToString();
            deletetext.Text = "the item deleted successfully";
        }
        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.AddMoviesToUser(ShippingCard, StaticFields.CurrentUser);
            GridView.ItemsSource = StaticFields.MoviesCard.Movies = new List<MovieDto>();
            paytext.Text = "Total Price: " + StaticFields.MoviesCard.CalculateTotalPrice().ToString();
            // will Be Stored to Owned Movies;
            //Empty the Card 

        }
    }
}
