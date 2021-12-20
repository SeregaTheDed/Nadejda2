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
    public partial class Nod : ContentPage
    {
        public Nod()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked_Calculate(object sender, EventArgs e)
        {
            try
            {
                var nod = NumberTheory.GetNod(long.Parse(number_a.Text), long.Parse(number_b.Text));
                result.Text = "Ответ:\n";
                if (!sw.IsToggled)
                {
                    result.Text += nod.GetValue().ToString();
                }
                else
                {
                    result.Text += nod.GetSolution();
                }
                FrameResult.IsVisible= true;
            }
            catch
            {
                DisplayAlert("Уведомление", "Некорректный ввод!", "ОK");
            }
        }
    }
}