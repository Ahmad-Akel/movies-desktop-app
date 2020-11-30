using System;

using Movies.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Movies.Views
{
    public sealed partial class BlankPage : Page
    {
        public BlankViewModel ViewModel { get; } = new BlankViewModel();

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
