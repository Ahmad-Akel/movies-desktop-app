using Movies.ViewModel;
using MoviesDataLayer.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoviesDataGrid : Page
    {
        MoviesViewModel moviesViewModel = new MoviesViewModel();
        CategoriesViewModel CategoriesViewModel =new CategoriesViewModel();
        public List<MovieDto> MoviesList = new List<MovieDto>();
        public List<Categories> CategoriesList = new List<Categories>();
        public MoviesDataGrid()
        {
            this.InitializeComponent();
            MoviesList =  moviesViewModel.GetAllMoviesAsync().Result;
            CategoriesList = CategoriesViewModel.GetCategories();
        }
        private void HyperlinkButton_Click_Movie(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ControlPanel));
        }
        private void Clear()
        {
            IdTextBox.Text = String.Empty;
            NameTextBox.Text = String.Empty;
            PriceTextBox.Text = String.Empty;
          //  CategoryTextBox.Text = String.Empty;
            MoviesList = moviesViewModel.GetAllMoviesAsync().Result;
            dataGrid1.ItemsSource = MoviesList;
        }

        private  void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // create movie = 
            var category = (Categories)CategoryComboBox.SelectedItem;
            var movie = new Movie() { Title = NameTextBox.Text,Price= Convert.ToDouble(PriceTextBox.Text),Category = category, CatId= category.CatId };

          moviesViewModel.AddMovie(movie);
            Clear();
        }
        // ValidateInput 
        private void ValidateInputData()
        {
            //if(NameTextBox.Text.Length<=0||CategoryTextBox.Text.Length<=0||PriceTextBox.Text.Length<=0)
            //{
            //    //error;
            //}
        }

        private void DeteleBtn_Click(object sender, RoutedEventArgs e)
        {
            moviesViewModel.DeleteMovie(Convert.ToInt32(IdTextBox.Text));
            Clear();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var category = (Categories)CategoryComboBox.SelectedItem;

            moviesViewModel.EditMovie(new Movie() { MovieId = Convert.ToInt32(IdTextBox.Text), Title = NameTextBox.Text, Price = Convert.ToDouble(PriceTextBox.Text) ,CatId = category.CatId, Category = category });
            Clear();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedrow = (MovieDto)dataGrid1.SelectedItem;
            if (selectedrow == null) return;
            IdTextBox.Text = selectedrow.MovieId.ToString();
            NameTextBox.Text = selectedrow.Title;
            PriceTextBox.Text = selectedrow.Price.ToString();
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     
        }
    }
}
