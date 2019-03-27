using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypad.Helper
{
    public class DatabaseHelper
    {
        private readonly string _connstring;

        public DatabaseHelper(string connstring)
        {
            _connstring = connstring;
        }

        public  IDbConnection GetDataBaseConnection()
        {
            try
            {
                return  new SqlConnection(_connstring);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

    }
}
