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
    public sealed partial class OwnedMovies : Page
    {
        public List<MovieDto> OwnedMoviesList { get; set; } = new List<MovieDto>();
        MoviesViewModel moviesViewModel = new MoviesViewModel();
        public OwnedMovies()
        {
            this.InitializeComponent();
            OwnedMoviesList = moviesViewModel.GetOwnedMovies(StaticFields.CurrentUser);

        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movie = (MovieDto)e.ClickedItem;
            InfoTextBlock.Text = "Name: " + movie.Title + "\n" + "Price: " + movie.Price + "$" + "\n" + "Category: " + movie.Category;
        }
    }
}
