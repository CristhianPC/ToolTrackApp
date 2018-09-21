using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTrackApp.Model.Entities.ToolTrackAppDB;
using ToolTrackApp.Model.SqlRepository.Interfaces;
using ToolTrackApp.Model.SqlRepository.Repositories;

namespace ToolTrackApp.Model.SqlRepository.Context
{
    [Database]
    public class ToolTrackContext : BaseContext
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        public ToolTrackContext() : base(ConfigurationManager.ConnectionStrings["ToolTrackApp"].ConnectionString)
        {
            Repositories = new Dictionary<Type, object>();
        }


        private List<SqlCommand> ListSqlSentence;
        private List<Action> ListFnActions;

        public Table<Entrance> Entrances;
        public Table<Exit> Exits;
        public Table<Location> Locations;
        public Table<Part> Parts;
        public Table<Provider> Providers;
        public Table<Return> Returns;
        public Table<Role> Roles;
        public Table<State> States;
        public Table<User> Users;


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            if (!Repositories.ContainsKey(type))
                Repositories.Add(type, new Repository<TEntity>(this));

            return Repositories[type] as IRepository<TEntity>;
        }

        public void AddSentence(SqlCommand commando, Action fnAccion)
        {
            fnAccion = fnAccion ?? (() => { });
            if (ListSqlSentence == null)
            {
                ListSqlSentence = new List<SqlCommand>();
                ListFnActions = new List<Action>();
            }
            commando.Connection = DbSqlConnection;
            commando.CommandType = CommandType.Text;
            ListSqlSentence.Add(commando);
            ListFnActions.Add(fnAccion);
        }

        public void SaveChanges()
        {
            try
            {
                DbSqlConnection.Open();
                for (int i = 0; i < ListSqlSentence.Count; i++)
                {
                    ListSqlSentence[i].ExecuteNonQuery();
                    ListFnActions[i]();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (DbSqlConnection.State == ConnectionState.Open)
                    DbSqlConnection.Close();
                if (ListFnActions != null)
                    ListFnActions.Clear();
                if (ListSqlSentence != null)
                    ListSqlSentence.Clear();
            }
        }
    }
}
