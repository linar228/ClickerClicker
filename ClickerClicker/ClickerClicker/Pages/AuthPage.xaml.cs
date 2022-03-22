using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClickerClicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void CreateAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
        {
            var allUsers = App.Db.GetUsers();

            if (EmailEntry.Text == null && PasswordEntry.Text == null)
                await DisplayAlert("Alert!", "Не правилный логин или пароль", "OK");
            else
            {
                bool haveUser = false;

                foreach (var user in allUsers)
                {
                    if (user.Email == EmailEntry.Text && user.Password == PasswordEntry.Text)
                    {
                        App.userID = user.Id;
                        await Navigation.PushAsync(new MainPage());
                        haveUser = true;
                    }
                }

                if (!haveUser)
                    await DisplayAlert("Alert!", "Не правилный логин или пароль", "OK");
            }
        }
    }
}