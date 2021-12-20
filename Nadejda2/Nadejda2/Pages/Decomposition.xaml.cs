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
    public partial class Decomposition : ContentPage
    {
        public Decomposition()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void Button_Clicked_Calculate(object sender, EventArgs e)
        {
            try
            {
                var decomposition = NumberTheory.GetMultipliersOfNumber(long.Parse(number.Text));
                result.Text = "Ответ:\n";
                if (!sw.IsToggled)
                {
                    result.Text += String.Join(" ", decomposition.GetList());
                }
                else
                {
                    result.Text += decomposition.GetSolution();
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