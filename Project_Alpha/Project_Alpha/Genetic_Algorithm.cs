using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_Alpha
{
    class Genetic_Algorithm
    {
        public int ID_FACTORY;
        MySqlConnection CON_BD;

        public Genetic_Algorithm(int id_fac)
        {
            ID_FACTORY = id_fac;
            CON_BD = new MySqlConnection("server=127.0.0.1;user=Admin;database=Project_1;port=3306;password=root");
        }

        class Individ
        {
            public Individ()
            {

            }
        }
    }
}
