using System;
using System.Collections.Generic;
using System.Text;

namespace CursValutar_z1.Models
{
    class Curs
    {
        public string Valuta { get; set; }
        public double Valoare { get; set; }
        public int Multiplicator { get; set; }
        public string Data { get; set; }  //2021-10-06
        public string Drapel
        {
            get
            {
                return Valuta.Substring(0, 2).ToLower()+".png";
            }
        }
        //USD -> us.png

        public Curs()
        {
            Multiplicator = 1;
           
        }

        public Curs(string Valuta, double Valoare, int Multiplicator, string Data)
        {
            this.Valuta = Valuta;
            this.Valoare = Valoare;
            this.Multiplicator = Multiplicator;
            this.Data = Data;
        }


    }

}
