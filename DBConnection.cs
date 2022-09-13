using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBook_ADO.NET
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {
            string con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
            SqlConnection connection = new SqlConnection(con);
            return connection;
        }

    }
}
