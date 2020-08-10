using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace GoogleMaps
{
    public class PlaceDetail
    {
        public string PlaceName { get; set; }
        public string Address { get; set; }
        public List<MenuPlace> menuList { get; set; }
        public List<imagePlace> imagesPlace { get; set; }
    }

    public class MenuPlace
    {
        public string Name { get; set; }
        public float PrecioOriginal { get; set; }
        public string Imagen { get; set; }
    }

    public class imagePlace
    {
        public string Name { get; set; }
        public string Imagen { get; set; }
    }

}
