using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickerClicker.DB;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClickerClicker.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private User user;
        private int[] upgradeLevels;
        private bool onPage = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Timer()
        {
            while (onPage)
            {
                await Task.Delay(1000);

                int autoClickPerSecond = upgradeLevels[1] + (upgradeLevels[2] * 2) + (upgradeLevels[3] * 4) + (upgradeLevels[4] * 8);

                user.Balance += autoClickPerSecond;
                user.EarnCount += autoClickPerSecond;

                UpdateFooter();
                App.Db.UpdateUser(user);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            user = App.Db.GetUser(App.userID);
            upgradeLevels = Array.ConvertAll(user.UpgradeLevels.Split(','), s => int.Parse(s));
            UpdateFooter();

            onPage = true;
            Timer();
        }

        private void UpdateFooter()
        {
            ClickCount.Text = user.Clicks.ToString();
            Balance.Text = user.Balance.ToString();
        }

        private async void OnShopButtonPressed(object sender, EventArgs e)
        {
            onPage = false;
            await Navigation.PushAsync(new ShopPage());
        }

        private async void OnProfileButtonPressed(object sender, EventArgs e)
        {
            onPage = false;
            await Navigation.PushAsync(new ProfilePage());
        }

        private void OnClickButtonPressed(object sender, EventArgs e)
        {
            user.Clicks++;
            user.Balance += upgradeLevels[0];
            user.EarnCount += upgradeLevels[0];

            UpdateFooter();
            App.Db.UpdateUser(user);
        }
    }
}