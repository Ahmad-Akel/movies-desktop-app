using Movies.ViewModel;
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
    public sealed partial class LoginPage : Page
    {
        private UserViewModel userViewModel =  new UserViewModel();
        public LoginPage()
        {
           this.InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }

        private void pageTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog message;
            if(!string.IsNullOrEmpty (Login_username_TextBox.Text) && !string.IsNullOrEmpty (Login_Password_TextBox.Password.ToString()))
            {
                bool LoggedIn = userViewModel.UserLogin(Login_username_TextBox.Text, Login_Password_TextBox.Password.ToString());
                if(LoggedIn)
                {
                    message = new MessageDialog("Welcome  " + Login_username_TextBox.Text, "Information");
                 await   message.ShowAsync();
                    this.Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    message = new MessageDialog("Cannot Login Please Check your input"); 
                    await message.ShowAsync();
                }
            }else
            {
                message = new MessageDialog("Invaild Input ");
                await message.ShowAsync();
            }
            
        }
    }
}
