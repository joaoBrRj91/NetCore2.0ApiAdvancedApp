

using johnstore.shared.Database;
using System;
using System.Data.SqlClient;

namespace JohnStore.Infra.StoreContext.DataContext
{
    public class JohnStoreDataContext : IDisposable
    {
        public SqlConnection  Connection { get; set; }


        public JohnStoreDataContext()
        {
            Connection = new SqlConnection(DbSettings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
