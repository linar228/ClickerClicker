using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClickerClicker.DB;

namespace ClickerClicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (FIOEntry.Text != null && EmailEntry.Text != null && NumberEntry.Text != null && PasswordEntry.Text != null)
                {
                    var user = new User
                    {
                        Name = FIOEntry.Text,
                        Email = EmailEntry.Text,
                        Password = PasswordEntry.Text,
                        PhoneNum = Convert.ToInt64(NumberEntry.Text),
                        Balance = 0,
                        Clicks = 0,
                    };

                    App.Db.SaveUser(user);
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Alert!", "Введите в поля данные!", "OK");
            }
            catch
            {
                await DisplayAlert("Alert!", "Проверьте введённые данные", "OK");
            }
        }
    }
}