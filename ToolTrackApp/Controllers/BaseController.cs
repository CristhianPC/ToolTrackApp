using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ToolTrackApp.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {

        }

        /// <summary>
        /// Función que permite copiar las propiedades de un objeto en otro, las propiedades que tengan el mismo nombre seran igualadas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj">Objeto el cual quiere ser llenado</param>
        /// <param name="Map">Objeto del cual se tomaran los valores para asignarles al objeto del parametro "Obj"</param>
        /// <param name="format">Formato que se aplicacara a las propiedades de tipo fecha cuando la propiedad destino es string y la propiedad origen es DateTime</param>
        internal void ExtendObject<T>(T Obj, object Map, string format = null)
        {
            Map.GetType().GetProperties().ToList().ForEach(delegate (PropertyInfo p)
            {
                PropertyInfo Pi = Obj.GetType().GetProperty(p.Name);
                if (Pi != null && Pi.CanWrite)
                {
                    object Valor = p.GetValue(Map, null);
                    if (Valor == null || Pi.PropertyType.IsPrimitive || Pi.PropertyType.Equals(typeof(decimal)) || Pi.PropertyType.Equals(typeof(string)) || Valor.GetType().Namespace != null)
                    {
                        if (p.PropertyType.FullName == "System.DateTime" && Pi.PropertyType.FullName == "System.String")
                            Valor = ((DateTime)Valor).ToString(format ?? "dd-MM-yyyy HH:mm:ss");
                        else if (p.PropertyType.FullName == "System.String" && Pi.PropertyType.FullName == "System.DateTime")
                            Valor = Convert.ToDateTime(Valor);
                        Pi.SetValue(Obj, Valor, null);
                    }
                }
            });
        }

    }
}