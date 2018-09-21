using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ToolTrackApp.Model.SqlRepository.Repositories.Base
{
    public class BaseRepository
    {
        protected internal void GetDataType(SqlParameter sqlParam, object obj)
        {
            sqlParam.SqlDbType = obj is string ? SqlDbType.VarChar : sqlParam.SqlDbType;
            sqlParam.SqlDbType = obj is int ? SqlDbType.Int : sqlParam.SqlDbType;
            sqlParam.SqlDbType = obj is XmlDocument ? SqlDbType.Xml : sqlParam.SqlDbType;
            sqlParam.SqlDbType = obj is DateTime || obj is DateTime? ? SqlDbType.VarChar : sqlParam.SqlDbType;
            sqlParam.Size = obj is string ? -1 : sqlParam.Size;
            sqlParam.Value = obj is XmlDocument ? new SqlXml(new XmlNodeReader((XmlDocument)obj)) : obj;
            sqlParam.Value = obj is DateTime || obj is DateTime? ? ((DateTime)obj).ToString("yyyyMMdd") : sqlParam.Value;
        }
    }
}
