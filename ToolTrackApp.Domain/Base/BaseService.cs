using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ToolTrackApp.Model.SqlRepository.Context;



namespace ToolTrackApp.Domain.Base
{
    public class BaseService
    {
        protected internal ToolTrackContext Db = null;
        public BaseService()
        {
            this.Db = new ToolTrackContext();
        }
        internal string DecodeString(string stringToDecode)
        {
            byte[] decode = Convert.FromBase64String(stringToDecode);
            return Encoding.UTF8.GetString(decode, 0, decode.ToArray().Length);
        }

        internal string Encode(string cadenaAencriptar)
        {
            byte[] encryted = System.Text.Encoding.UTF8.GetBytes(cadenaAencriptar);
            return Convert.ToBase64String(encryted);
        }

        internal string JsonSerializer<T>(T objectToSerialize) where T : class
        {
            var jsonResult = new JavaScriptSerializer().Serialize(objectToSerialize);
            return jsonResult;
        }

        internal T JsonDeserialize<T>(string jsonString) where T : class
        {
            var objectResult = new JavaScriptSerializer().Deserialize<T>(jsonString);
            return objectResult;
        }
    }
}
