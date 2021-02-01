using Movies.ViewModel;
using MoviesDataLayer.UWP.Models;
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
    public sealed partial class UserDataGrid : Page
    {
        UserViewModel userViewModel = new UserViewModel();
        private List<UserDto> UsersList = new List<UserDto>();
        public UserDataGrid()
        {
            this.InitializeComponent();
         UsersList =  userViewModel.GetUsers();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ControlPanel));
        }
        private void Clear()
        {
            IdTextBox.Text = String.Empty;
            UserNameTextBox.Text = String.Empty;
            PasswordTextBox.Text = String.Empty;
            RoleTextBox.Text = String.Empty;
            UsersList = userViewModel.GetUsers();
            dataGrid1.ItemsSource = UsersList;
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                var selectedrow = (UserDto)dataGrid1.SelectedItem;
                if (selectedrow == null) return;
                IdTextBox.Text = selectedrow.Id.ToString();
                UserNameTextBox.Text = selectedrow.UserName;
                PasswordTextBox.Text = selectedrow.Password;
                RoleTextBox.Text = selectedrow.Permession;
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.CrateUser(new User() { UserName = UserNameTextBox.Text, Password = PasswordTextBox.Text, Permissions = new Permissions() { Role = RoleTextBox.Text } });
            Clear();
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.DeleteUser(Convert.ToInt32(IdTextBox.Text));
            Clear();
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            userViewModel.EditUser(new User() { UserId = Convert.ToInt32(IdTextBox.Text), UserName = UserNameTextBox.Text, Password = PasswordTextBox.Text, Permissions = new Permissions() { Role = RoleTextBox.Text } });
            Clear();
        }

    }
}
