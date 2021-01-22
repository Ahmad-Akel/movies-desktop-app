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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
        public Main()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender,RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(OwnedMovies));
        }
        private void NavigationView_SelectionChanged(NavigationView sender,NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            switch (item.Tag.ToString())
            {
                case "favorites":
                    ContentFrame.Navigate(typeof(Favorite));
                    break;
                case "ownedmovie":
                    ContentFrame.Navigate(typeof(OwnedMovies));
                    break;
                case "movies":
                    ContentFrame.Navigate(typeof(Movies));
                    break;
                case "myaccount":
                    ContentFrame.Navigate(typeof(MyAccount));
                    break;
                case "logout":
                    this.Frame.Navigate(typeof(LoginPage));
                    break;
            }
        }
    }
}
