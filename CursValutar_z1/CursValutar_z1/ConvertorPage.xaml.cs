using CursValutar_z1.Models;
using CursValutar_z1.Services;
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
        Dictionary<string, Curs> dictCurs = new Dictionary<string, Curs>();

        public ConvertorPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Curs> listaCurs = await SursaDate.ObtineListaCursAsync();
            Curs ronCurs = new Curs() { Valuta = "RON", Valoare = 1 };
            dictCurs[ronCurs.Valuta] = ronCurs; 
            foreach (Curs curs in listaCurs)
            {
                dictCurs[curs.Valuta] = curs;
            }

            pickerValutaDest.ItemsSource = dictCurs.Keys.ToList();
            pickerValutaSursa.ItemsSource = dictCurs.Keys.ToList();
            pickerValutaDest.SelectedItem = dictCurs.Keys.First();
            pickerValutaSursa.SelectedItem = dictCurs.Keys.First();
        }

        private void ConvertesteButon_Clicked(object sender, EventArgs e)
        {
            //entrySuma -> valoare de convertit 200
            //pickerValutaSursa -> selectare valuta sursa EUR
            //pickerValutaDest -> selectare valuta destinatie (conversie) USD

            //labelRezultat -> valoare rezultat
            //1. Preluare valoare de convertit (entrySuma.Text: suma) -> 200
            double suma = 0;
            double.TryParse(entrySuma.Text, out suma);

            //2. Preluare valuta sursa (pickerValutaSursa.SelectedItem) -> "EUR"

            string valutaSursa = (string)pickerValutaSursa.SelectedItem;

            //2.1 Obtinere curs asociat (cursSUrsa: obiect Curs valuta sursa) -> obiect Curs{Valuta ="EUR"}

            Curs cursSursa = dictCurs[valutaSursa];

            //3 Preluare valuta destinatie (pickerValutaSursa.SelectedItem) -> "USD"

            string valutaDest = (string)pickerValutaDest.SelectedItem;

            //3.1 Obtinere curs asociat (cursDest:obiect Curs valuta sursa ) -> obiect Curs{Valuta = "USD"}
            Curs cursDest = dictCurs[valutaDest];

            //4. Calculam rezultatul
            //Cati euro cumpar cu 200 de lei?
            //rezultat = suma * cursSursa.Multiplicator * cursSursa.Valoare / cursDest.Multiplicator * cursDest.Valoare;

            double rezultat = suma * cursDest.Multiplicator * cursSursa.Valoare / (cursSursa.Multiplicator * cursDest.Valoare);


            //Afisare rezultat
            labelRezultat.Text = rezultat.ToString();

        }
    }
}