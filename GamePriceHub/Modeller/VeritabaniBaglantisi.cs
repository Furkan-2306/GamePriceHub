using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace GamePriceHub.Modeller
{
    //Veritabanı bağlantısı
    public class VeritabaniBaglantisi
    {
       
        private readonly string _baglantiDizesi = "Server=localhost;Database=gamepricehub_db;Uid=root;Pwd=;";

        public MySqlConnection BaglantiGetir()
        {
            return new MySqlConnection(_baglantiDizesi);
        }
    }
}