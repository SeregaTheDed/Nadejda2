﻿using Nadejda2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nadejda2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked_Nod(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nod());
        }

        private async void Button_Clicked_Decomposotion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Decomposition());
        }

        private async void Button_Clicked_Reverse(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reverse());
        }

        private async void Button_Clicked_EulerFunction(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EulerFunction());
        }

        private async void Button_Clicked_LegendreSymbol(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LegendreSymbol());
        }
    }
}