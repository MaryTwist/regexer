using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace General
{
    public class SqlDbClient
    {
        public string ConnectionString { get; private set; }

        public SqlDbClient(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DataTable GetQuery(Action<SqlCommand> setup)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                setup(cmd);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public int GetNonQuery(Action<SqlCommand> setup)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                setup(cmd);

                return cmd.ExecuteNonQuery();
            }
        }

        public T GetScalar<T>(Action<SqlCommand> setup)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                setup(cmd);

                return (T)cmd.ExecuteScalar();
            }
        }
    }
}
