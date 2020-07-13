using GoogleMaps.Services;
using Java.Lang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GoogleMaps.Entities
{
    class Filters
    {

        public List<Establecimiento> establecimientos { get; set; }

        public List<Producto> productos { get; set; }


        public FiltersViewModel refreshData()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Filters)).Assembly;
            Assembly assem = Assembly.GetExecutingAssembly();
            Stream stream = assem.GetManifestResourceStream("GoogleMaps.Establecimiento.json");
            string text = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var resultObject = JsonConvert.DeserializeObject<FiltersViewModel>(text);

            return resultObject;
        }

    }

    public class FiltersViewModel
    {
        public Establecimiento[] Establecimientos { get; set; }
        public Producto[] Productos { get; set; }

    }


    public class Establecimiento
    {
        public int idEstablecimiento { get; set; }
        public string nombreEstablecimiento { get; set; }
        
    }

    public class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        
    }
}
