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
    public partial class EulerFunction : ContentPage
    {
        public EulerFunction()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void Button_Clicked_Calculate(object sender, EventArgs e)
        {
            try
            {
                var euler = NumberTheory.GetEulerFunc(long.Parse(number.Text));
                result.Text = "Ответ:\n";
                if (!sw.IsToggled)
                {
                    result.Text += euler.GetValue().ToString();
                }
                else
                {
                    result.Text += euler.GetSolution();
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