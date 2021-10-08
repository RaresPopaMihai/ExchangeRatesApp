using CursValutar_z1.Models;
using CursValutar_z1.Services;
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

        List<Curs> listaCurs ;

        public MainPage()
        {
            InitializeComponent();
            
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaCurs = await SursaDate.ObtineListaCursAsync();
            listViewCurs.ItemsSource = listaCurs;
        }

        private void Setari_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetariPage());
        }

        

    }
}
