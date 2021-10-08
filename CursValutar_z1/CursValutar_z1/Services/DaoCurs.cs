using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CursValutar_z1.Models;
using SQLite;

namespace CursValutar_z1.Services
{
    class DaoCurs
    {
        SQLiteConnection connection;


        public DaoCurs()
        {
            string cale;

            cale = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"curs_valutar.db");
            connection = new SQLiteConnection(cale);

            connection.CreateTable<Curs>();
        }

        public int AdaugaCurs(Curs curs)
        {
            return connection.Insert(curs);
        }

        public int AdaugaListaCurs(List<Curs> listaCurs)
        {
            return connection.InsertAll(listaCurs);
        }

        public List<Curs> ObtineCursDinData(string data)
        {
            return connection.Query<Curs>("SELECT * FROM Curs WHERE Data = ?", data);
        }

    }
}
