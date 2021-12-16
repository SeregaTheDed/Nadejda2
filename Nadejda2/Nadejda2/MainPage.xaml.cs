using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nadejda2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked_Main_Continue(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage());
            Navigation.RemovePage(this);
        }
    }
}
