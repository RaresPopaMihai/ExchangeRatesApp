using CursValutar_z1.Models;
using CursValutar_z1.Services;
using CursValutar_z1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursValutar_z1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConvertorPage : ContentPage
    {
        ConvertorViewModel viewModel;

       
        public ConvertorPage()
        {
            InitializeComponent();
            viewModel = new ConvertorViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
           
            //pickerValutaDest.SelectedItem = "RON";
            //pickerValutaSursa.SelectedItem = "EUR";
        }

        
    }
}