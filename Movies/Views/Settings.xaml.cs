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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
       
        public Settings()
        {
            this.InitializeComponent();
            InitValues();
        }
        #region Events

        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Favorite));
        }
        private void OwnedMovies_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OwnedMovies));
        }

        #endregion

        //Set User information; 
        private void InitValues()
        {
            if (StaticFields.CurrentUser == null)
                return;

            var currentUser = StaticFields.CurrentUser;
            NameInfo.Text = currentUser.UserName;
            PassInfo.Text = currentUser.Password;
            if (currentUser.Is_Sub)
                SubInfo.Text = "Vaild From : " + String.Format("{0:dd-MM-yyyy}", currentUser.StartDate) + " To : " + String.Format("{0:dd-MM-yyyy}", currentUser.EndDate);
            else
                SubInfo.Text = "You Are Not Subscribed to any Plan !";

        }
    }
}
