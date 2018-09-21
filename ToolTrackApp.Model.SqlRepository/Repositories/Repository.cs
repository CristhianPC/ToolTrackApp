using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolTrackApp.Model.SqlRepository.Context;
using ToolTrackApp.Model.SqlRepository.Helpers;
using ToolTrackApp.Model.SqlRepository.Interfaces;
using ToolTrackApp.Model.SqlRepository.Repositories.Base;

namespace ToolTrackApp.Model.SqlRepository.Repositories
{
    public class Repository<TEntity> : BaseRepository, IRepository<TEntity> where TEntity : class
    {
        private string TableName;
        private Type TypeEntity = typeof(TEntity);
        private Dictionary<string, ColumnAttribute> Columns;
        private ToolTrackContext Context;
        public Repository(ToolTrackContext context)
        {
            this.Context = context;
            Columns = new Dictionary<string, ColumnAttribute>();
            var tableAttr = (TableAttribute)Attribute.GetCustomAttribute(TypeEntity, typeof(TableAttribute));
            TableName = tableAttr != null ? tableAttr.Name : string.Empty;

            List<PropertyInfo> listProperties = TypeEntity.GetProperties().ToList();
            foreach (var pi in listProperties)
            {
                var columnAttr = (ColumnAttribute)Attribute.GetCustomAttribute(pi, typeof(ColumnAttribute));
                if (columnAttr != null)
                    Columns.Add(pi.Name, columnAttr);
            }
        }

        private List<string> SetColumnList(Type typeEntity, object columnsMap)
        {
            List<string> listColumnsMap = new List<string>();
            if (columnsMap == null)
                Columns.Where(c => !c.Value.IsDbGenerated).ToList().ForEach(p => listColumnsMap.Add(p.Key));
            else
            {
                var columList = columnsMap.GetType().GetProperties().ToList();
                columList.ForEach(l => listColumnsMap.Add(l.Name));
            }
            return listColumnsMap;
        }

        public List<TEntity> SelectByFilter(Func<TEntity, bool> filter)
        {
            return Context.GetTable<TEntity>().AsQueryable().Where(filter).ToList();
        }


        public void AddSingle(TEntity entity)
        {
            List<string> listaColumnasMapa = new List<string>();
            Columns.Where(c => !c.Value.IsDbGenerated).ToList().ForEach(p => listaColumnasMapa.Add(p.Key));
            AddSingle(entity, null);
        }

        private void AddSingle(TEntity entity, object columnsMap)
        {
            var listColumnsMap = this.SetColumnList(TypeEntity, columnsMap);
            var columnIdentity = Columns.Where(c => c.Value.IsDbGenerated).FirstOrDefault();
            string stringColumns = listColumnsMap.ConcatList(p => p, ",");
            string stringValues = listColumnsMap.ConcatList(p => "@" + p, ",");
            string sql = string.Format(
            @"INSERT INTO {0} ({1}) VALUES ({2})" +
            (columnIdentity.Value != null ? " SET @{3} = SCOPE_IDENTITY()" : string.Empty), TableName, stringColumns, stringValues, columnIdentity.Key);

            using (SqlCommand sqlCommand = new SqlCommand(sql, Context.DbSqlConnection))
            {
                Context.DbSqlConnection.Open();
                try
                {
                    foreach (var i in listColumnsMap)
                    {
                        var value = TypeEntity.GetProperty(i).GetValue(entity, null) ?? DBNull.Value;
                        Context.AddCommandParameter(sqlCommand, "@" + i, value);
                    }
                    if (columnIdentity.Value != null)
                    {
                        var paramIdentity = new SqlParameter("@" + columnIdentity.Key, null);
                        paramIdentity.Direction = ParameterDirection.Output;
                        paramIdentity.DbType = DbType.Int32;
                        sqlCommand.Parameters.Add(paramIdentity);
                    }
                    sqlCommand.ExecuteNonQuery();
                    var pi = TypeEntity.GetProperty(columnIdentity.Key);
                    pi.SetValue(entity, sqlCommand.Parameters["@" + columnIdentity.Key].Value);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (Context.DbSqlConnection.State == ConnectionState.Open)
                    {
                        Context.DbSqlConnection.Close();
                        //Context.DbSqlConnection.Dispose();
                    }
                }
            }
        }

        private void Add(TEntity entity)
        {
            List<string> listaColumnasMapa = new List<string>();
            Columns.Where(c => !c.Value.IsDbGenerated).ToList().ForEach(p => listaColumnasMapa.Add(p.Key));
            Add(entity, listaColumnasMapa);
        }

        private void Add(TEntity entity, List<string> listaColumnasMapa)
        {
            var columnIdentity = Columns.Where(c => c.Value.IsDbGenerated).FirstOrDefault();
            string cadenaColumnas = listaColumnasMapa.ConcatList(p => p, ",");
            string cadenaValores = listaColumnasMapa.ConcatList(p => "@" + p, ",");
            string sql = string.Format(
            @"INSERT INTO {0} ({1}) VALUES ({2})" +
            (columnIdentity.Value != null ? " SET @{3} = SCOPE_IDENTITY()" : string.Empty), TableName, cadenaColumnas, cadenaValores, columnIdentity.Key);
            SqlCommand sqlCommand = new SqlCommand(sql);
            foreach (var i in listaColumnasMapa)
            {
                var paramValue = TypeEntity.GetProperty(i).GetValue(entity, null) ?? DBNull.Value;
                paramValue = paramValue is DateTime ? ((DateTime)paramValue) : paramValue;
                Context.AddCommandParameter(sqlCommand, "@" + i, paramValue);
            }

            if (columnIdentity.Value != null)
            {
                var paramIdentity = new SqlParameter("@" + columnIdentity.Key, null);
                paramIdentity.Direction = ParameterDirection.Output;
                paramIdentity.DbType = DbType.Int32;
                sqlCommand.Parameters.Add(paramIdentity);
            }

            Context.AddSentence(sqlCommand, delegate ()
            {
                var pi = TypeEntity.GetProperty(columnIdentity.Key);
                pi.SetValue(entity, sqlCommand.Parameters["@" + columnIdentity.Key].Value);
            });
        }

        private void Attach(TEntity entity, List<string> columnasMapa)
        {
            Dictionary<string, object> listaColumnasMapa = new Dictionary<string, object>();
            var listaColumnas = columnasMapa.GetType().GetProperties().ToList();
            foreach (var l in columnasMapa)
            {
                var value = TypeEntity.GetProperty(l).GetValue(entity, null) ?? DBNull.Value;
                if (value.ToString().ToUpper() == "TRUE")
                    value = 1;
                else if (value.ToString().ToUpper() == "FALSE")
                    value = 0;
                listaColumnasMapa.Add(l, value);
            }
            Attach(entity, listaColumnasMapa);
        }

        private void Attach(TEntity entity, Dictionary<string, object> listaColumnasMapa)
        {
            var listaColumnasPrimary = Columns.Where(c => c.Value.IsPrimaryKey || c.Value.IsDbGenerated).ToList();
            string columnasActualizar = listaColumnasMapa.ConcatList(",");
            string criterioWhere = listaColumnasPrimary.ConcatList(p => p.Key + " = " + TypeEntity.GetProperty(p.Key).GetValue(entity, null), " AND ");
            string sql = string.Format(
            @"UPDATE {0} 
            SET {1} 
            WHERE {2}", TableName, columnasActualizar, criterioWhere);
            SqlCommand sqlCommand = new SqlCommand(sql);
            Context.AddSentence(sqlCommand, null);
        }

        public void AddRange(List<TEntity> listaEntity)
        {
            foreach (var l in listaEntity)
            {
                Add(l);
            }
        }

        public void Remove(TEntity entity)
        {
            var listaColumnasPrimary = Columns.Where(c => c.Value.IsPrimaryKey).ToList();
            string criterioWhere = listaColumnasPrimary.ConcatList(p => p.Key + " = @" + p.Key, " AND ");
            string sql = string.Format(
            @"DELETE {0}
            WHERE {1}", TableName, criterioWhere);
            SqlCommand sqlCommand = new SqlCommand(sql);
            foreach (var i in listaColumnasPrimary)
            {
                var param = new SqlParameter("@" + i.Key, null);
                GetDataType(param, TypeEntity.GetProperty(i.Key).GetValue(entity, null));
                sqlCommand.Parameters.Add(param);
            }
            Context.AddSentence(sqlCommand, null);
        }

        public void AddOrAttach(TEntity entity)
        {
            List<string> listaColumnasMapa = new List<string>();
            Columns.Where(c => !c.Value.IsDbGenerated).ToList().ForEach(p => listaColumnasMapa.Add(p.Key));
            AddOrAttach(entity, listaColumnasMapa);
        }

        private void AddOrAttach(TEntity entity, List<string> columnasMapa)
        {
            bool esNuevo = false;
            var listaColumnasPrimary = Columns.Where(c => c.Value.IsPrimaryKey && c.Value.IsDbGenerated).ToList();

            if (listaColumnasPrimary.Count == 0)
                listaColumnasPrimary = Columns.Where(c => c.Value.IsDbGenerated).ToList();

            foreach (var i in listaColumnasPrimary)
            {
                int valueInt = 0;
                var value = TypeEntity.GetProperty(i.Key).GetValue(entity, null);
                if (value == null || (int.TryParse(value.ToString(), out valueInt) && valueInt == 0))
                {
                    esNuevo = true;
                    break;
                }
            }
            if (esNuevo)
            {
                Add(entity, columnasMapa);
            }
            else
            {
                Attach(entity, columnasMapa);
            }
        }
    }
}

