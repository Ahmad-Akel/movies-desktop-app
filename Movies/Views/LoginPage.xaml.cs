using Movies.Classes;
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
    public sealed partial class LoginPage : Page
    {
        private UserViewModel userViewModel =  new UserViewModel();
        public LoginPage()
        {
           this.InitializeComponent();
            //   userViewModel.InitPermissions();
           // userViewModel.CrateUser(new User() { UserName = "Ahmad", Password = "123", Permissions = new Permissions() { Role = "ADMIN" } });
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }

        private void pageTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        /*
         * Login  Btn 
         */
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog message;
            if(!string.IsNullOrEmpty (Login_username_TextBox.Text) && !string.IsNullOrEmpty (Login_Password_TextBox.Password.ToString()))
            {
                var loggedInUser = userViewModel.UserLogin(Login_username_TextBox.Text, Login_Password_TextBox.Password.ToString());
                bool LoggedIn = loggedInUser !=null;
                if(LoggedIn)
                {
                    message = new MessageDialog("Welcome  " + Login_username_TextBox.Text, "Information");
                    if(loggedInUser != null)
                    {
                        switch(loggedInUser.PermessionId)
                        {
                            case 1:
                                this.Frame.Navigate(typeof(ControlPanel));
                                break;
                            default:
                                 StaticFields.CurrentUser = loggedInUser;
                                 this.Frame.Navigate(typeof(Main));
                               
                                break;
                        }
                    }
                    await   message.ShowAsync();
                    
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
