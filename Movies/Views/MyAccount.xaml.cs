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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyAccount : Page
    {
        public List<User> UsersList { get; set; } = new List<User>();
        public List<Subsecribe> subList { get; set; } = new List<Subsecribe>();
        public MyAccount()
        {

            this.InitializeComponent();
            UsersList.Add(new User { UserName = "Ahmad Akel", Email = "ahmad.oudai1999@gmail.com", Password = "12345" });
            subList.Add(new Subsecribe { Type = "Monthly" });
            User user = new User();
            Subsecribe sub = new Subsecribe();
            NameInfo.Text = "u" + user.UserName;
            PassInfo.Text = "p" + user.Password;
            EmailInfo.Text = "e" + user.Email;
            SubInfo.Text = "s" + sub.Type;
        }
        private void SubView(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Subscription));
        }
        private void OwnedMovie(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OwnedMovies));
        }
    }
}
