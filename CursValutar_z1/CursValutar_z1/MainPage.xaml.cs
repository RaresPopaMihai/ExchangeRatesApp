using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CursValutar_z1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Setari_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetariPage());
        }

    }
}
