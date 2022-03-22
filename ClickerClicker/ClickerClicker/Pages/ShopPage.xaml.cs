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
    public partial class ShopPage : ContentPage
    {
        public ShopPage()
        {
            InitializeComponent();

            var user = App.Db.GetUser(App.userID);
            var upgradeLevels = Array.ConvertAll(user.UpgradeLevels.Split(','), s => int.Parse(s));

            MegaClickLvl.Text = $"Уровень: {upgradeLevels[0]}";
            NeonClickLvl.Text = $"Уровень: {upgradeLevels[1]}";
            HandClickLvl.Text = $"Уровень: {upgradeLevels[2]}";
            DickClickLvl.Text = $"Уровень: {upgradeLevels[3]}";
            MagicClickLvl.Text = $"Уровень: {upgradeLevels[4]}";

            MegaClickDmg.Text = $"Урон: {upgradeLevels[0]}";
            NeonClickDmg.Text = $"Урон: {upgradeLevels[1]}";
            HandClickDmg.Text = $"Урон: {upgradeLevels[2] * 2}";
            DickClickDmg.Text = $"Урон: {upgradeLevels[3] * 4}";
            MagicClickDmg.Text = $"Урон: {upgradeLevels[4] * 8}";

            MegaClickCost.Text = $"Цена: {(upgradeLevels[0] + 1) * 5}";
            NeonClickCost.Text = $"Цена: {(upgradeLevels[1] + 1) * 10}";
            HandClickCost.Text = $"Цена: {(upgradeLevels[2] + 1) * 20}";
            DickClickCost.Text = $"Цена: {(upgradeLevels[3] + 1) * 40}";
            MagicClickCost.Text = $"Цена: {(upgradeLevels[4] + 1) * 80}";
        }

        private async void OnBackButtonPressed(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void MegaClickBuy_Clicked(object sender, EventArgs e)
        {

        }

        private void NeonClickBuy_Clicked(object sender, EventArgs e)
        {

        }

        private void HandClickBuy_Clicked(object sender, EventArgs e)
        {

        }

        private void DickClickBuy_Clicked(object sender, EventArgs e)
        {

        }

        private void MagicClickBuy_Clicked(object sender, EventArgs e)
        {

        }
    }
}