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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            var user = App.db.GetUser(App.userID);

            var upgradeLevels = Array.ConvertAll(user.UpgradeLevels.Split(','), s => int.Parse(s));
            user.MaxLvl = upgradeLevels.Max();
            user.MaxUpgrades = upgradeLevels.Sum();
            App.Db.UpdateUser(user);

            FIO.Text = user.Name;
            Phone.Text = user.PhoneNum.ToString();
            Mail.Text = user.Email;
            ClickCount.Text = $"Всего было кликнуто: {user.Clicks}";
            EarnCount.Text = $"Всего было заработано: {user.EarnCount}";
            MaxLvl.Text = $"Максимальный лвл: {user.MaxLvl}";
            MaxDmg.Text = $"Урон в секунду: {upgradeLevels[1] + (upgradeLevels[2] * 2) + (upgradeLevels[3] * 4) + (upgradeLevels[4] * 8)}";
            MaxUprade.Text = $"Максимум улучшений: {user.MaxUpgrades}";
            RegDate.Text = $"Дата регистрации: {user.RegistrationDate.ToString().Split(' ')[0]}";
        }

        private async void OnBackButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}