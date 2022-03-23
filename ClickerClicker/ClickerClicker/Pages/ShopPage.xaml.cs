using ClickerClicker.DB;
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
        private User user;
        private int[] upgradeLevels;

        public ShopPage()
        {
            InitializeComponent();

            user = App.Db.GetUser(App.userID);
            upgradeLevels = Array.ConvertAll(user.UpgradeLevels.Split(','), s => int.Parse(s));

            UpdatePageFromDB();
        }

        private void UpdatePageFromDB()
        {
            MegaClickLvl.Text = $"Уровень: {upgradeLevels[0]}";
            NeonClickLvl.Text = $"Уровень: {upgradeLevels[1]}";
            HandClickLvl.Text = $"Уровень: {upgradeLevels[2]}";
            DickClickLvl.Text = $"Уровень: {upgradeLevels[3]}";
            MagicClickLvl.Text = $"Уровень: {upgradeLevels[4]}";

            MegaClickDmg.Text = $"Урон: {upgradeLevels[0]}";
            NeonClickDmg.Text = $"Авто-Урон: {upgradeLevels[1]}";
            HandClickDmg.Text = $"Авто-Урон: {upgradeLevels[2] * 2}";
            DickClickDmg.Text = $"Авто-Урон: {upgradeLevels[3] * 4}";
            MagicClickDmg.Text = $"Авто-Урон: {upgradeLevels[4] * 8}";

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

        private void TryBuyUpdate(int cost, int index)
        {
            if (user.Balance >= cost)
            {
                user.Balance -= cost;
                upgradeLevels[index]++;
                user.UpgradeLevels = $"{upgradeLevels[0]},{upgradeLevels[1]},{upgradeLevels[2]},{upgradeLevels[3]},{upgradeLevels[4]}";
                App.Db.UpdateUser(user);
                UpdatePageFromDB();
            }
        }

        private void MegaClickBuy_Clicked(object sender, EventArgs e)
        {
            TryBuyUpdate((upgradeLevels[0] + 1) * 5, 0);
        }

        private void NeonClickBuy_Clicked(object sender, EventArgs e)
        {
            TryBuyUpdate((upgradeLevels[1] + 1) * 10, 1);
        }

        private void HandClickBuy_Clicked(object sender, EventArgs e)
        {
            TryBuyUpdate((upgradeLevels[2] + 1) * 20, 2);
        }

        private void DickClickBuy_Clicked(object sender, EventArgs e)
        {
            TryBuyUpdate((upgradeLevels[3] + 1) * 40, 3);
        }

        private void MagicClickBuy_Clicked(object sender, EventArgs e)
        {
            TryBuyUpdate((upgradeLevels[4] + 1) * 80, 4);
        }
    }
}