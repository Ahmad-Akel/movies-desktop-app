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
    public sealed partial class RegisterPage : Page
    {
        private UserViewModel userViewModel = new UserViewModel();
        public RegisterPage()
        {
            this.InitializeComponent();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog message;
            if (!string.IsNullOrEmpty(Reg_username_textbox.Text)&&!string.IsNullOrEmpty(Reg_Pass_textbox.Text)&& !string.IsNullOrEmpty(Reg_CoPass_textbox.Text))
            {
                // Validadte if Password is same ; 

                if(Reg_Pass_textbox.Text==Reg_CoPass_textbox.Text)
                {
                 bool userCreated =    userViewModel.CrateUser(Reg_username_textbox.Text,Reg_Pass_textbox.Text);
                    if (userCreated)
                    {
                        message = new MessageDialog("User Created !");
                    }
                    else
                    {
                        message = new MessageDialog("Cannot Create New User !");
                    }
                 
                }else
                {
                    message = new MessageDialog("Password Not Match!");
                }

            }else
            {
                message = new MessageDialog("Data Input Invaild !");
            }
            await message.ShowAsync();
        }
    }
}
