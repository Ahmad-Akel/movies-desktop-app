using System;

using Movies.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Movies.Views
{
    public sealed partial class Blank1Page : Page
    {
        public Blank1ViewModel ViewModel { get; } = new Blank1ViewModel();

        public Blank1Page()
        {
            InitializeComponent();
        }
    }
}
