using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Linq;


namespace ToolTrackApp.Model.SqlRepository.Context
{
    public abstract class BaseContext : DataContext
    {
        public SqlConnection DbSqlConnection;
        protected internal Dictionary<Type, object> Repositories { get; set; }
        public BaseContext(string connectionString)
            : base(connectionString)
        {
            DbSqlConnection = new SqlConnection(connectionString);
        }

        public void AddCommandParameter(SqlCommand sqlCommand, string nameParameter, object valueParameter)
        {
            var parameter = new SqlParameter(nameParameter, valueParameter);
            sqlCommand.Parameters.Add(parameter);
        }
    }
}
