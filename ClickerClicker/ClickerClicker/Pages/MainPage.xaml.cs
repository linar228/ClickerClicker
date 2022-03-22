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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var user = App.Db.GetUser(App.userID);

            ClickCount.Text = user.Clicks.ToString();
            Balance.Text = user.Balance.ToString();
        }

        private async void OnShopButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShopPage());
        }

        private async void OnProfileButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}