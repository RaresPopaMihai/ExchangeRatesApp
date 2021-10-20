using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursValutar_z1.Models
{
    class Curs
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Valuta { get; set; }
        public double Valoare { get; set; }
        public int Multiplicator { get; set; }
        public string Data { get; set; }  //2021-10-06

        [Ignore]
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

        public Curs(string Valuta, double Valoare, int Multiplicator)
        {
            this.Valuta = Valuta;
            this.Valoare = Valoare;
            this.Multiplicator = Multiplicator;
           
        }
        
        public static DateTime ObtineDataReferinta()
        {
            DateTime now = DateTime.Now;
            
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return DateTime.Today.AddDays(-1);
                    
                case DayOfWeek.Sunday:
                    return DateTime.Today.AddDays(-2);
                    
                case DayOfWeek.Monday:
                    if(now.Hour < 13)
                        return DateTime.Today.AddDays(-3);
                    break;
            }

            
            return now.ToUniversalTime().Hour < 10 ? now.AddDays(-1) : now;
        }

        public static DateTime ObtineDataReferinta(DateTime date)
        {

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return date.AddDays(-1);

                case DayOfWeek.Sunday:
                    return date.AddDays(-2);

                case DayOfWeek.Monday:
                    if (date.Hour < 13)
                        return date.AddDays(-3);
                    break;
            }

            
            return date.ToUniversalTime().Hour < 10 ? date.AddDays(-1) : date;
        }

        public override string ToString()
        {
            return Valuta;
        }


    }

}
