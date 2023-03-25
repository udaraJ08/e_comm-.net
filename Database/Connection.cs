using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horizon
{
    internal class Connection
    {
        public SqlConnection getConnection()
        {
            string connetionString = @"Data Source=SINISTER;Initial Catalog=e_comm;Integrated Security=True;MultipleActiveResultSets=true";
            return new SqlConnection(connetionString);
        }

    }
}
