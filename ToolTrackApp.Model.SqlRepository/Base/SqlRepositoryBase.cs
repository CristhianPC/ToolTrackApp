using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obd2TrackingApp.Model.SqlRepository.Base
{
    public abstract class SqlRepositoryBase
    {
        protected internal SqlConnection dbSqlConnection;
        protected internal SqlCommand dbSqlCommand;
        protected internal SqlDataReader dbSqlDataReader;
        protected internal string dbSqlConnectionString ;

        /// <summary>
        /// Constructor of base class
        /// </summary> 
        /// <param name="connectionString">String de conection</param>
        public SqlRepositoryBase(string connectionString)
        {
            dbSqlConnectionString = connectionString;
            dbSqlConnection = null;
            dbSqlCommand = null;
            dbSqlDataReader = null;
        }

        /// <summary>
        /// Fill the command to connect to the DB
        /// </summary>
        /// <param name="name">Name of procedure</param>
        /// <param name="isProcedure">Is Store Procedure</param>
        protected internal void SetUpCommand(string name, bool isProcedure)
        {
            dbSqlCommand = new SqlCommand(name, dbSqlConnection);
            dbSqlCommand.CommandType = (isProcedure) ? CommandType.StoredProcedure : CommandType.Text;
        }

        /// <summary>
        /// Add parameters to the command for the connection to the DB
        /// </summary>
        /// <param name="name">Parameter Name</param>
        /// <param name="value">Parameter Value</param>
        protected internal void AddCommandParameter(string name, object value)
        {
            SqlParameter newParameter = new SqlParameter(name, value);
            dbSqlCommand.Parameters.Add(newParameter); 
        }

        /// <summary>
        /// Fill a DataTable with the data of a DataRader
        /// </summary>
        /// <param name="dataReader">Data to fill the data table</param>
        /// <returns>DataTable</returns>
        protected internal DataTable GetDataTable(IDataReader dataReader)
        {
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            return dt;
        }

        /// <summary>
        /// Fill a dataSet with a query done
        /// </summary>
        /// <returns>DataSet</returns>
        protected internal DataSet GetDataSet()
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(dbSqlCommand);
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        protected internal void DisposeResources()
        {
            if (dbSqlDataReader != null)
            {
                dbSqlDataReader.Dispose();
                dbSqlDataReader = null;
            }
            if (dbSqlCommand != null)
            {
                dbSqlCommand.Dispose();
                dbSqlCommand = null;
            }
            if (dbSqlConnection != null)
            {
                dbSqlConnection.Dispose();
                dbSqlConnection = null;
            }
        }
    }
}

