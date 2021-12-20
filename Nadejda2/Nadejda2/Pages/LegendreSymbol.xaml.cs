using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nadejda2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LegendreSymbol : ContentPage
    {
        public LegendreSymbol()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked_Calculate(object sender, EventArgs e)
        {
            try
            {
                var legendre = NumberTheory.GetLegendreSymbol(long.Parse(number_a.Text), long.Parse(number_b.Text));
                result.Text = "Ответ:\n";
                if (!sw.IsToggled)
                {
                    result.Text += legendre.GetValue().ToString();
                }
                else
                {
                    result.Text += legendre.GetSolution();
                }
                FrameResult.IsVisible = true;
            }
            catch
            {
                DisplayAlert("Уведомление", "Некорректный ввод!", "ОK");
            }
        }
    }
}