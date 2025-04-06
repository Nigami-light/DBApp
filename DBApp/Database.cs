using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBApp
{
    public class Database
    {
        readonly MySqlConnection connection = new("user=root; password=goydaDB1337; port=3306; server=localhost; database=collegedb");
    }
}
