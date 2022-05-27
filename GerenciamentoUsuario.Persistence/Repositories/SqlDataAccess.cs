using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoUsuario.Persistence.Repositories
{
    public class SqlDataAccess
    {
        private String _connectionString;
        public SqlDataAccess(String connectionString)
        {
            _connectionString = connectionString;
        }

        protected IDbConnection GetChargingSqlDbConnection
        {
            get
            {
                var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
        }

    }
}
