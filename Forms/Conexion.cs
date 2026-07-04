using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto.Forms
{
    internal class Conexion
    {
        private readonly string Cadena;

        public Conexion()
        {
            Cadena = "Server=127.0.0.1; Database=puntodb; Uid=root; Pwd=; Port=3307";
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection conexion = new MySqlConnection(Cadena);
            conexion.Open();
            return conexion;
        }

    }
}
