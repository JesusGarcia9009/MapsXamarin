using Android.Graphics;
using GoogleMaps.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace GoogleMaps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        Xamarin.Essentials.Location location = null;

        public Detail()
        {
            InitializeComponent();

            //obtener la localizacion
            this.GetLocation();

            //cameraf
            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(this.location.Latitude, this.location.Longitude), 15d);

            //obtener lugares segun ubicacion
            this.ListOfPlaces(this.location.Latitude, this.location.Longitude);

            // print my location
            this.PrintMyPosition(this.location.Latitude, this.location.Longitude);

            // Use this for a single pin
            //GenerateAPin();
            // Use this to generate a polyline
            //GenerateTrack();
            map.InfoWindowClicked += Map_InfoWindowClicked;


        }

        private void PrintPins(List<Lugar> listado)
        {
            List<Pin> placesList = new List<Pin>();

            foreach (Lugar lugar in listado)
            {
                Pin x = new Pin
                {
                    Type = PinType.Generic,
                    Label = lugar.ename + " " + lugar.oname,
                    Address = lugar.address,
                    Position = new Position(lugar.lat, lugar.lon)
                    //Distance = $"{GetDistance(lat1, lon1, place.geometry.location.lat, place.geometry.location.lng, DistanceUnit.Kiliometers).ToString("N2")}km",
                    //OpenNow = GetOpenHours(place?.opening_hours?.open_now)

                };
                //placesList.Add(x);
                map.Pins.Add(x);
            }
        }

        private void PrintMyPosition(double latitud, double longitud)
        {
            Pin yo = new Pin
            {
                Type = PinType.Place,
                Label = "Posicion actual",
                Address = "ver direccion",
                Icon = BitmapDescriptorFactory.DefaultMarker(System.Drawing.Color.Blue),
                //Icon = BitmapDescriptorFactory.FromBundle(place.icon),
                Position = new Position(latitud, longitud)
                //Distance = $"{GetDistance(lat1, lon1, place.geometry.location.lat, place.geometry.location.lng, DistanceUnit.Kiliometers).ToString("N2")}km",
                //OpenNow = GetOpenHours(place?.opening_hours?.open_now)
            };

            map.Pins.Add(yo);
        }

        private async void ListOfPlaces(double latitud, double longitud)
        {
            WSClient client = new WSClient();
            String url = "http://18.221.224.46:8000/v01/getentities/";
            url += latitud.ToString() + "/";
            url += longitud.ToString() + "/";
            url += "K";
            List<Lugar> result = await client.Get<List<Lugar>>(url);
            if (result.Count != 0)
            {
                PrintPins(result);
            }
        }

        private Bitmap getIconByUrl(string url)
        {
            Bitmap image = null;
            using (WebClient webClient = new WebClient())
            {
                byte[] array = webClient.DownloadData(url);
                if (array != null && array.Length > 0)
                {
                    image = BitmapFactory.DecodeByteArray(array, 0, array.Length);
                }
            }
            return image;
        }

        private void GenerateAPin()
        {
            var pin = new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.87) };
            map.Pins.Add(pin);
        }

        private void Map_InfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            //Put your code here
            Pin item = e.Pin;
            DisplayAlert(item.Label, item.Address, "Cerrar");
            //RepositionPin(e.Pin);



        }

        private async void GetLocation()
        {
            try
            {
                this.location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error verifica la wea");
            }
        }

        private void GeneratePins()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Detail)).Assembly;
            Assembly assem = Assembly.GetExecutingAssembly();
            Stream stream = assem.GetManifestResourceStream("GoogleMaps.Places.json");
            string text = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var resultObject = JsonConvert.DeserializeObject<Places>(text);


            List<Pin> placesList = new List<Pin>();

            foreach (var place in resultObject.results)
            {
                Pin x = new Pin
                {
                    Type = PinType.Place,
                    Label = place.name,
                    Address = place.vicinity,
                    //Icon = BitmapDescriptorFactory.FromBundle(place.icon),
                    Position = new Position(place.geometry.location.lat, place.geometry.location.lng)
                    //Distance = $"{GetDistance(lat1, lon1, place.geometry.location.lat, place.geometry.location.lng, DistanceUnit.Kiliometers).ToString("N2")}km",
                    //OpenNow = GetOpenHours(place?.opening_hours?.open_now)

                };
                //placesList.Add(x);
                map.Pins.Add(x);
            }
        }

    }
}