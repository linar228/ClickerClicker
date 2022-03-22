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