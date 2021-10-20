using CursValutar_z1.Models;
using CursValutar_z1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursValutar_z1.ViewModels
{
    class MainViewModel
    {
        public List<Curs> ListaCurs { get; set; }
        public string Data { get; set; }

        public MainViewModel()
        {
            InitializareLista();
            if(ListaCurs.Count>0)
                Data = ListaCurs[0].Data;
        }

        public async void InitializareLista()
        {
            ListaCurs = await SursaDate.ObtineListaCursAsync();
          
        }
    }
}
