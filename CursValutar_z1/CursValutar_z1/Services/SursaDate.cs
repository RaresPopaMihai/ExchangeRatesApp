using CursValutar_z1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursValutar_z1.Services
{
    class SursaDate
    {
        public static List<Curs> ObtineListaCurs()
        {
            List<Curs> listaCurs = new List<Curs>();
            listaCurs.Add(new Curs() { Valuta = "EUR", Valoare = 4.94, Data = "2021-01-06" });
            listaCurs.Add(new Curs() { Valuta = "USD", Valoare = 4.34, Data = "2021-01-06" });
            listaCurs.Add(new Curs() { Valuta = "GBP", Valoare = 5.44, Data = "2021-01-06" });
            listaCurs.Add(new Curs() { Multiplicator = 100, Valuta = "HUF", Valoare = 4.14, Data = "2021-01-06" });
            return listaCurs;
        }
    }
}
