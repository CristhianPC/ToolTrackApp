using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.SqlRepository.Helpers
{
    public static class HelperDAL
    {
        public static string ConcatList<T>(this List<T> list, Func<T, string> fnProp, string separator)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            string cadenaRespuesta = string.Empty;
            list.ForEach(p => cadenaRespuesta += separator + fnProp(p));
            cadenaRespuesta = cadenaRespuesta.Substring(separator.Length, cadenaRespuesta.Length - separator.Length);
            return cadenaRespuesta;
        }

        public static string ConcatList(this Dictionary<string, object> list, string separator)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            var cadenaRespuesta = new StringBuilder();

            foreach (var p in list)
            {
                object value = null;
                if (p.Value is string || p.Value is DateTime)
                {
                    value = p.Value is DateTime ? ((DateTime)p.Value).ToString("yyyy-MM-dd HH:mm:ss") : p.Value;
                    value = string.Format("'{0}'", value);
                }
                else
                    value = p.Value.ToString();
                cadenaRespuesta.Append(separator + p.Key + " = " + value);
            }
            return cadenaRespuesta.ToString().Substring(separator.Length, cadenaRespuesta.Length - separator.Length);
        }
    }
}

