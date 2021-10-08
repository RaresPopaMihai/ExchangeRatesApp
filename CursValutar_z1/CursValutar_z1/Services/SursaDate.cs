using CursValutar_z1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CursValutar_z1.Services
{
    class SursaDate
    {
        public static async Task<List<Curs>> ObtineListaCursAsync()
        {
            /*
            List<Curs> listaCurs = new List<Curs>();
            listaCurs.Add(new Curs() { Valuta = "EUR", Valoare = 4.94, Data = "2021-01-06" });
            listaCurs.Add(new Curs() { Valuta = "USD", Valoare = 4.34, Data = "2021-01-06" });
            listaCurs.Add(new Curs() { Valuta = "GBP", Valoare = 5.44, Data = "2021-01-06" });
            listaCurs.Add(new Curs() { Multiplicator = 100, Valuta = "HUF", Valoare = 4.14, Data = "2021-01-06" });
            return listaCurs;
            */
            DaoCurs dao = new DaoCurs();
            int hour = DateTime.Now.Hour;

            List<Curs> listaCurs = dao.ObtineCursDinData(Curs.ObtineDataReferinta(DateTime.Now).ToString("yyyy-MM-dd"));
            DateTime dataDeReferinta;
            

            if(listaCurs.Count == 0)
            {
                listaCurs = await PreiaCursXML();
                dao.AdaugaListaCurs(listaCurs);
            }

            return listaCurs;

            
        }

        private static async Task<List<Curs>> PreiaCursXML()
        {
            List<Curs> listaCurs = new List<Curs>();

            HttpClient httpClient = new HttpClient();
            // httpClient.SendAsync()
            Stream stream =await httpClient.GetStreamAsync("https://bnr.ro/nbrfxrates.xml");
            using (XmlReader reader = XmlReader.Create(stream))
            {
                String data = string.Empty;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "Cube")
                        {
                            //preluare data
                            data = reader["date"];
                        }

                        if(reader.Name == "Rate")
                        {
                            //preluare curs
                            Curs curs = new Curs()
                            {
                                Valuta = reader["currency"],
                                Data = data,
                                Multiplicator = reader["multiplier"]!=null?int.Parse(reader["multiplier"]):1
                            };

                            reader.Read();

                            curs.Valoare = double.Parse((reader.Value));

                            listaCurs.Add(curs);
                            
                        }

                        
                    }
                }
            };

            return listaCurs;
        }
    }
}
