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
            FIO.Text = user.Name;
            Phone.Text = user.PhoneNum.ToString();
            Mail.Text = user.Email;
            ClickCount.Text = $"Всего было кликнуто: {user.Clicks}";
            EarnCount.Text = $"Всего было заработано: {user.EarnCount}";
            MaxLvl.Text = $"Максимальный лвл: {user.MaxLvl}";
            MaxDmg.Text = $"Максимальный урон: {user.MaxDamage}";
            MaxUprade.Text = $"Максимум улучшений: {user.MaxUpgrades}";
            RegDate.Text = $"Дата регистрации: {user.RegistrationDate.ToString().Split(' ')[0]}";
        }

        private async void OnBackButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}