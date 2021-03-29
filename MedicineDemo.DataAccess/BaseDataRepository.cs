using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MedicineDemo.DataAccess
{
    public abstract class BaseDataRepository
    {
        public ConnectionFactory connectionFactory { get; set; }
        public BaseDataRepository()
        {

        }


        public virtual IEnumerable<T> ExecuteStoredPrc<T>(string procName, DynamicParameters paramerts = null, SqlTransaction trans = null, bool buffered = true, int? commanTimeOut = 180, CommandType commandType = CommandType.StoredProcedure)
        {
            if (trans == null) connectionFactory = new ConnectionFactory();
            try
            {
                return connectionFactory.DbConnection.Query<T>(procName, paramerts, trans, buffered, commanTimeOut, commandType);
            }
            finally
            {
                if (trans == null)
                {
                    connectionFactory?.DbConnection?.Close();
                    connectionFactory?.Dispose();
                }
            }
        }
    }
}