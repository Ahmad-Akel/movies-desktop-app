using Movies.Classes;
using Movies.ViewModel;
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
    /// 
    public sealed partial class Subscription : Page
    {
        UserViewModel userViewModel = new UserViewModel();
        public Subscription()
        {
            this.InitializeComponent();
        }

        private void MonthlyBtn_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.Subscribe(StaticFields.CurrentUser, 1);
        }

        private void AnnualBtn_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.Subscribe(StaticFields.CurrentUser, 2);

        }

        private void LifeTimeBtn_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.Subscribe(StaticFields.CurrentUser, 3);
        }
    }
}
