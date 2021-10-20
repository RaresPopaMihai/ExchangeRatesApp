using CursValutar_z1.Models;
using CursValutar_z1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursValutar_z1.ViewModels
{
    class ConvertorViewModel : INotifyPropertyChanged
    {
        private double rezultat;

        public double Suma { get; set; }

        public double Rezultat { 
            get {
                return rezultat;
            }
            set 
            {
                rezultat = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand ConvertesteCommand { get; set; }

        public List<Curs> ListaCurs { get; set; }

        public Curs CursSursa { get; set; }

        public Curs CursDest { get; set; }

        public ConvertorViewModel()
        {
            ConvertesteCommand = new Command(ConvertesteButon_Clicked);
            InitializeazaListaCurs();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void InitializeazaListaCurs()
        {
            ListaCurs = await SursaDate.ObtineListaCursAsync();
            Curs ronCurs = new Curs() { Valuta = "RON", Valoare = 1 };
            ListaCurs.Add(ronCurs);

        }

        private void ConvertesteButon_Clicked()
        {
            //entrySuma -> valoare de convertit 200
            //pickerValutaSursa -> selectare valuta sursa EUR
            //pickerValutaDest -> selectare valuta destinatie (conversie) USD

            //labelRezultat -> valoare rezultat
            //1. Preluare valoare de convertit (entrySuma.Text: suma) -> 200
            //double suma = 0;
            //double.TryParse(entrySuma.Text, out suma);
            //Suma este legata dinamic

            //2. Preluare valuta sursa (pickerValutaSursa.SelectedItem) -> "EUR"
            //CursSursa este legat dinamic cu SelectedItem
            //string valutaSursa = (string)pickerValutaSursa.SelectedItem;

            //2.1 Obtinere curs asociat (cursSUrsa: obiect Curs valuta sursa) -> obiect Curs{Valuta ="EUR"}

            //Curs cursSursa = dictCurs[valutaSursa];

            //3 Preluare valuta destinatie (pickerValutaSursa.SelectedItem) -> "USD"
            //CursDest este legat dinamic cu SelectedItem
            //string valutaDest = (string)pickerValutaDest.SelectedItem;

            //3.1 Obtinere curs asociat (cursDest:obiect Curs valuta sursa ) -> obiect Curs{Valuta = "USD"}
            //Curs cursDest = dictCurs[valutaDest];

            //4. Calculam rezultatul
            //Cati euro cumpar cu 200 de lei?
            //rezultat = suma * cursSursa.Multiplicator * cursSursa.Valoare / cursDest.Multiplicator * cursDest.Valoare;

            Rezultat = Suma * CursDest.Multiplicator * CursSursa.Valoare / (CursSursa.Multiplicator * CursDest.Valoare);


            //Afisare rezultat
            //Rezultat este legat dinamic de label
            //labelRezultat.Text = rezultat.ToString();

        }
    }
}
