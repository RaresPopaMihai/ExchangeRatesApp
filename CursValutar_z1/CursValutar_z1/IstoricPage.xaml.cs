using CursValutar_z1.Models;
using CursValutar_z1.Services;
using Microcharts;
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
    public partial class IstoricPage : ContentPage
    {
        public IstoricPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Curs> listaCurs = await SursaDate.ObtineListaCursAsync();
            List<ChartEntry> dateGrafic = new List<ChartEntry>();


            foreach(Curs curs in listaCurs)
            {
                dateGrafic.Add(new ChartEntry((float)curs.Valoare)
                {
                    Label = curs.Data,
                    ValueLabel = curs.Valoare.ToString(),
                    Color = new SkiaSharp.SKColor((byte)new Random().Next(0,255),
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255))
                });
                if (dateGrafic.Count >= 10)
                    break;
            }

            chart.Chart = new BarChart() { Entries = dateGrafic };
            
        }
    }
}